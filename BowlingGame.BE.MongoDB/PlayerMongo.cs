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

namespace BowlingGame.BE
{
    public class PlayerMongo: IPlayer
    {
        /// <summary>
        /// Player Id
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        //[BsonId]
        //public ObjectId PlayerId
        //{
        //    //get { return Id != null && Id.ToString() !=""? new ObjectId(Id.ToString()) : ObjectId.GenerateNewId(); }
        //    get {
        //        if (Id == null || Id.ToString() == "")
        //            Id = ObjectId.GenerateNewId();
        //        else
        //            Id = new ObjectId(Id.ToString());
        //        return (ObjectId)Id;
        //        //return Id.ToString();
        //    }
        //    set { Id = PlayerId; }
        //}
        /// <summary>
        /// Nickname or User Name
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Date of Birth
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        ///  Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Date Modified
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// GameSetup 1 to 1 relation
        /// </summary>
        //public virtual GameSetup GameSetup { get; set; }
    }
}
