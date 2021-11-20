using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.DTO;

namespace BowlingGame.DA
{
    public class PlayerSqlDto : IPlayerDto
    {
        [Key]
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
