using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DA.Interfaces;
using BowlingGame.DTO;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.DA.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BowlingGameDBContext dbContext) : base(dbContext)
        { }
        public Player Build(IPlayerDto value)
        {
            return new Player()
            {
                Id = value.PlayerId,
                NickName = value.NickName,
                FirstName = value.FirstName,
                LastName = value.LastName,
                DOB = value.DOB,
                DateCreated = value.DateCreated,
                DateModified = value.DateModified
            };
        }
    }
}
