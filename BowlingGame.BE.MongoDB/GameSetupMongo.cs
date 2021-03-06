using BowlingGame.BE.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BE.MongoDB
{
    public class GameSetupMongo : IGameSetup
    {
        /// <summary>
        /// GameSetup id - PK
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        //[BsonId]
        //public ObjectId GameSetupId
        //{
        //    get { return Id != null ? new ObjectId(Id.ToString()) : new ObjectId(); }
        //    set { Id = GameSetupId; }
        //}
        public int PlayerId { get; set; }

        /// <summary>
        /// Configure the number of pins per game
        /// </summary>
        public int AvailablePins { get; set; }

        /// <summary>
        /// Verifyes if the game is finished
        /// By max of two attempts
        /// By X pins knocked down
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date Modified
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Player 1 to 1 relation
        /// </summary>
        public virtual PlayerMongo Player { get; set; }

        /// <summary>
        /// Game 1 to 2 relation
        /// </summary>
        public IEnumerable<GameMongo> Games { get; set; }

    }
}
