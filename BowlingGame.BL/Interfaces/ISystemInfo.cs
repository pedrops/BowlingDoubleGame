using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BL.Interfaces
{
    public interface ISystemInfo
    {
        public string ConnectionString { get; set; }
        public string Persistence { get; set; }
        public string DataBase { get; set; }
        //public string GetConnectionString();
        //public string GetDB();
        //public string GetPersistence();
        public void FillSettings();
    }
}
