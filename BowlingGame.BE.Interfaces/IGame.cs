using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BE.Interfaces
{
    public interface IGame : IEntityBase 
    {
        public int? GameSetupId { get; set; }
        public int GameAttempt { get; set; }
        public int KnockedPins { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
