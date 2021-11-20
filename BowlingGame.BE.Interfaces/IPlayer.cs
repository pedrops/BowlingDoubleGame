using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BE.Interfaces
{
    public interface IPlayer : IEntityBase
    {
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
