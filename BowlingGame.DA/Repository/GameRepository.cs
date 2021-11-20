using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DA.Interfaces;
using BowlingGame.DTO;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.DA.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(BowlingGameDBContext dbContext) : base(dbContext)
        { }
        public Game Build(IGameDto value)
        {
            return new Game()
            {
                Id = value.GameId,
                GameSetupId = value.GameSetupId,
                KnockedPins = value.KnockedPins,
                GameAttempt = value.GameAttempt,
                DateCreated = value.DateCreated,
                DateModified = value.DateModified
            };
        }
    }
}
