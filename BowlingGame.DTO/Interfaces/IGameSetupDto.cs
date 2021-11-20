using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DTO
{
    public interface IGameSetupDto
    {
        public int? GameSetupId { get; set; }
        public int AvailablePins { get; set; }
        public bool Finished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? PlayerId { get; set; }
    }
}
