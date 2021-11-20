using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BE.Interfaces
{
    public interface IGameSetup : IEntityBase
    {
        public int? PlayerId { get; set; }
        public int AvailablePins { get; set; }
        public bool Finished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
