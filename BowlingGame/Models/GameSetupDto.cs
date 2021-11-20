using BowlingGame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Models
{
    public class GameSetupDto : IGameSetupDto
    {
        public int? GameSetupId { get; set; }
        public int AvailablePins { get; set; }
        public bool Finished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? PlayerId { get; set; }
        public PlayerDto Player { get; set; }
        public List<GameDto> Games { get; set; }
        
    }
}
