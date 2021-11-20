using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DTO;

namespace BowlingGame.DA.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        public Player Build(IPlayerDto value);
    }
}
