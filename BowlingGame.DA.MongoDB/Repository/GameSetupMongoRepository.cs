using BowlingGame.BE;
using BowlingGame.BE.Interfaces;
using BowlingGame.DA.Interfaces;
using BowlingGame.DA.MongoDB.Interfaces;
using BowlingGame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DA.MongoDB.Repository
{
    public class GameSetupMongoRepository : BaseMongoRepository<GameSetup>, IGameSetupRepository
    {
        private IPlayerRepository PlayerRepo;
        private IGameRepository GameRepo;
        public GameSetupMongoRepository(IMongoDbRepository MongoRepository,IPlayerRepository PlayerRepo, IGameRepository GameRepo) : base(MongoRepository,"GameSetups")
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
