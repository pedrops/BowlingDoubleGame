using BowlingGame.BE;
using BowlingGame.DA.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.DA.MongoDB.UoW
{
    public class UnitOfWorkMongo : IUnitOfWork
    {

        public UnitOfWorkMongo(IGameSetupRepository GameSetup, IGameRepository Game, IPlayerRepository Player)
        {
            this.GameSetup = GameSetup;
            this.Game = Game;
            this.Player = Player;
        }


        public IGameSetupRepository GameSetup { get; private set; }
        public IGameRepository Game { get; private set; }
        public IPlayerRepository Player { get; private set; }

        public void SaveGame(BE.Game Game)
        {
            var currentGame = GetGame(Game.Id.GetValueOrDefault());
            var currentGameSetup = GetGameSetup(Game.GameSetupId.GetValueOrDefault());
            if (currentGameSetup.Games.Any(item => item.Id == Game.Id))
                currentGameSetup.Games.Remove(currentGame);
            currentGameSetup.Games.Add(Game);
            this.GameSetup.Save(currentGameSetup);
        }

        public void SaveGameSetup(BE.GameSetup GameSetup)
        {
            this.GameSetup.Save(GameSetup);
        }

        public void SavePlayer(BE.Player Player)
        {
            var GameSetupList = GetAllGameSetup().Result;

            var currentGameSetup = GameSetupList.FirstOrDefault(item => item.Player!=null && item.Player.Id == Player.Id);
            if (currentGameSetup!=null)
                currentGameSetup.Player = Player;
            this.GameSetup.Save(currentGameSetup);
        }

        public int Complete()
        {
            return 1;
        }

        public void Dispose(){}

        public async Task<string> GetScore(int GameSetupId, int playerId)
        {
            var PlayerGameSetup = GameSetup.Get(GameSetupId);
            var result = PlayerGameSetup.Games.Select(item => item.KnockedPins).Sum();
            return result == 0 ? "/" : (result == PlayerGameSetup.AvailablePins ? "X" : result.ToString());
        }

        public async Task<IEnumerable<BE.Game>> GetAllGame()
        {
            var GameSetupDocuments = await GameSetup.GetAll();
            List<Game> result = new List<Game>();
            GameSetupDocuments.ToList().ForEach(item => result.AddRange(item.Games.ToList()));
            return result;
        }

        public Task<IEnumerable<BE.GameSetup>> GetAllGameSetup()
        {
            return GameSetup.GetAll();
        }

        public async Task<IEnumerable<BE.Player>> GetAllPlayer()
        {
            var GameSetupDocuments = await GameSetup.GetAll();
            List<Player> result = new List<Player>();
            GameSetupDocuments.ToList().ForEach(item => result.Add(item.Player));
            return result;
        }

        public BE.Game GetGame(int GameId)
        {
            var GameList = GetAllGame().Result;
            return GameList.FirstOrDefault(item=>item.Id == GameId);
        }

        public BE.GameSetup GetGameSetup(int GameSetupId)
        {
            return GameSetup.Get(GameSetupId);
        }

        public BE.Player GetPlayer(int GameId)
        {
            var PlayerList = GetAllPlayer().Result;
            return PlayerList.FirstOrDefault(item=>item.Id == GameId);
        }

        

        public void RemoveGame(BE.Game Game)
        {
            var currentGame = GetGame(Game.Id.GetValueOrDefault());
            var currentGameSetup = GetGameSetup(currentGame.GameSetupId.GetValueOrDefault());
            currentGameSetup.Games.Remove(Game);
            this.GameSetup.Save(currentGameSetup);
        }

        public void RemoveGameSetup(BE.GameSetup GameSetup)
        {
            this.GameSetup.Remove(GameSetup);
        }

        public void RemovePlayer(BE.Player Player)
        {
            var GameSetupList = GetAllGameSetup().Result;
            var currentGameSetup = GameSetupList.FirstOrDefault(item => item.PlayerId == Player.Id);
            this.GameSetup.Remove(currentGameSetup);
        }
    }
}
