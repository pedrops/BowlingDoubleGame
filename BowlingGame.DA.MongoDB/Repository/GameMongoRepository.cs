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
    public class GameMongoRepository : BaseMongoRepository<Game>, IGameRepository
    {
        public GameMongoRepository(IMongoDbRepository MongoRepository) :base(MongoRepository,"Games")
        {

        }

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
