
using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DTO;

namespace BowlingGame.DA.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        public Game Build(IGameDto value);
    }
}
