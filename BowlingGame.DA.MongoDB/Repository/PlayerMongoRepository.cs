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
    public class PlayerMongoRepository : BaseMongoRepository<Player>, IPlayerRepository
    {
        public PlayerMongoRepository(IMongoDbRepository MongoRepository) : base(MongoRepository,"Players")
        {

        }

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
