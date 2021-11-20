using BowlingGame.BE;
using BowlingGame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Models
{
    public class PlayerDto : IPlayerDto
    {
        public int? PlayerId { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
