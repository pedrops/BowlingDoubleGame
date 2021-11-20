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
    public class GameSetup : IGameSetup 
    {
        /// <summary>
        /// GameSetup id - PK
        /// </summary>
        [BsonId] 
        [Key] 
        public int? Id { get; set; } 
        //[Key]
        //public int GameSetupId
        //{
        //    get { return Id != null ? int.Parse(Id.ToString()) : 0; }
        //    set { Id = value; }
        //}
        [BsonIgnore]
        public int? PlayerId { get; set; } 

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
        public virtual Player Player { get; set; } 

        /// <summary>
        /// Game 1 to 2 relation
        /// </summary>
        public ICollection<Game> Games { get; set; } 

        public override string ToString() 
        {
            return Id.ToString(); 
        }
    }
}
