using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DTO;
using System.Collections.Generic;

namespace BowlingGame.DA.Interfaces
{
    public interface IGameSetupRepository : IBaseRepository<GameSetup>
    {
        public GameSetup Build(IGameSetupDto value, IPlayerDto player, IEnumerable<IGameDto> games);
    }
}
