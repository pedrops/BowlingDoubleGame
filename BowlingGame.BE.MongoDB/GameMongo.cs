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
    public class GameMongo : IGame
    {
        /// <summary>
        /// Game id - PK
        /// </summary>
        /// 
        [BsonId]
        public int Id { get; set; }
        //[BsonId]
        //public ObjectId GameId {
        //    get { return Id != null ? new ObjectId(Id.ToString()) : new ObjectId(); }
        //    set { Id = GameId; }
        //}
        public int GameSetupId { get; set; }
        /// <summary>
        /// Game Attempt, first or second - PK
        /// </summary>
        public int GameAttempt { get; set; }

        /// <summary>
        /// Knocked Pins Number
        /// </summary>
        public int KnockedPins { get; set; }

        /// <summary>
        /// Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date Modified
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Game Setup relation
        /// </summary>
        public virtual GameSetupMongo GameSetup { get; set; }
    }
}
