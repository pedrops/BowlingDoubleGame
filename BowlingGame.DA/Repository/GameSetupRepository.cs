using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DA.Interfaces;
using BowlingGame.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.DA.Repository
{
    public class GameSetupRepository : BaseRepository<GameSetup>, IGameSetupRepository
    {
        private IPlayerRepository PlayerRepo;
        private IGameRepository GameRepo;
        public GameSetupRepository(IPlayerRepository PlayerRepo, IGameRepository GameRepo, BowlingGameDBContext dbContext) : base(dbContext)
        {
            this.PlayerRepo = PlayerRepo;
            this.GameRepo = GameRepo;
        }
        public GameSetup Build(IGameSetupDto value, IPlayerDto player, IEnumerable<IGameDto> games)
        {
            var gamelist = games.Select(item => GameRepo.Build(item));
            return new GameSetup()
            {
                Id = value.GameSetupId,
                PlayerId = value.PlayerId,
                AvailablePins = value.AvailablePins,
                Finished = value.Finished,
                DateCreated = value.DateCreated,
                DateModified = value.DateModified,
                Player = (Player)PlayerRepo.Build(player),
                Games = gamelist.Cast<Game>().ToList()
            };
        }
    }
}
