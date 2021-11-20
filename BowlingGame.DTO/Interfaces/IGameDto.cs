using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DTO
{
    public interface IGameDto
    {
        public int? GameId { get; set; }
        public int GameAttempt { get; set; }
        public int KnockedPins { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? GameSetupId { get; set; }
    }
}
