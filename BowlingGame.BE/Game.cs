using BowlingGame.BE.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BE 
{
    public class Game : IGame 
    {
        /// <summary>
        /// Game id - PK
        /// </summary>
        /// 
        [BsonId] 
        [Key] 
        public int ? Id { get; set; } 
        //[Key]
        //public int GameId { 
        //    get { return Id != null? int.Parse(Id.ToString()) : 0; } 
        //    set { Id = value; } 
        //}
        [BsonIgnore] 
        public int ? GameSetupId { get; set; } 
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
        public virtual GameSetup GameSetup { get; set; } 

        public override string ToString() 
        {
            return Id.ToString();
        }
    }
}
