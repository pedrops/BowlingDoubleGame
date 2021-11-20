using BowlingGame.BE;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingGame.DA.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameSetupRepository GameSetup { get; }
        IGameRepository Game { get; }
        IPlayerRepository Player { get; }
        int Complete();
        Task<string> GetScore(int GameSetup, int playerId);
        void SaveGame(Game Game);
        void SaveGameSetup(GameSetup GameSetup);
        void SavePlayer(Player GameSetup);
        Game GetGame(int GameId);
        GameSetup GetGameSetup(int GameId);
        Player GetPlayer(int GameId);
        Task<IEnumerable<Game>> GetAllGame();
        Task<IEnumerable<GameSetup>> GetAllGameSetup();
        Task<IEnumerable<Player>> GetAllPlayer();
        void RemoveGame(Game Game);
        void RemoveGameSetup(GameSetup GameSetup);
        void RemovePlayer(Player GameSetup);

    }
}
