using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DTO
{
    public interface IPlayerDto
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
