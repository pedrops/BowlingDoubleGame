using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.DTO;

namespace BowlingGame.DA
{
    public class GameSqlDto : IGameDto
    {
        [Key]
        public int GameId { get; set; }
        [Key]
        public int GameSetupId { get; set; }
        public int GameAttempt { get; set; }
        public int KnockedPins { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
