using BowlingGame.BE;
using BowlingGame.DA.Interfaces;
using BowlingGame.DA.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.DA.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private BowlingGameDBContext dbContext;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DbContextOptions<BowlingGameDBContext> options)
        {
            this.dbContext = new BowlingGameDBContext(options);
            
            Game = new GameRepository(this.dbContext);
            Player = new PlayerRepository(this.dbContext);
            GameSetup = new GameSetupRepository(Player,Game, this.dbContext);
        }


        public IGameSetupRepository GameSetup { get; private set; }
        public IGameRepository Game { get; private set; }
        public IPlayerRepository Player { get; private set; }

        public void SaveGame(Game Game)
        {
            this.Game.Save(Game);
        }

        public void SaveGameSetup(GameSetup GameSetup)
        {
            this.GameSetup.Save(GameSetup);
        }

        public void SavePlayer(Player Player)
        {
            this.Player.Save(Player);
        }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Task<IEnumerable<Game>> GetAllGame()
        {
            return Game.GetAll();
        }

        public Task<IEnumerable<GameSetup>> GetAllGameSetup()
        {
            return GameSetup.GetAll();
        }

        public Task<IEnumerable<Player>> GetAllPlayer()
        {
            return Player.GetAll();
        }

        public Game GetGame(int GameId)
        {
            return Game.Get(GameId);
        }

        public GameSetup GetGameSetup(int GameSetupId)
        {
            return GameSetup.Get(GameSetupId);
        }

        public Player GetPlayer(int PlayerId)
        {
            return Player.Get(PlayerId);
        }

        public async Task<string> GetScore(int GameSetup, int playerId)
        {
            var currentGameSetup = this.GameSetup.Get(GameSetup);
            var Games = await Game.GetAll();
            var result = Games.Where(item => item.GameSetupId == GameSetup).Select(item => item.KnockedPins).Sum();
            return result == 0 ? "/" : (result == currentGameSetup.AvailablePins ? "X" : result.ToString());
        }

        public void RemoveGame(Game Game)
        {
            this.Game.Remove(Game);
        }

        public void RemoveGameSetup(GameSetup GameSetup)
        {
            this.GameSetup.Remove(GameSetup);
        }

        public void RemovePlayer(Player Player)
        {
            this.Player.Remove(Player);
        }
    }
}
