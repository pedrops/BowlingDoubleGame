using BowlingGame.BL.Interfaces;
using BowlingGame.DA.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DA.MongoDB.Repository
{
    public class MongoDbRepository : IMongoDbRepository
    {
        public MongoClient Client;
        public IMongoDatabase db { get; set; }
        public MongoDbRepository(ISystemInfo SystemInfo)
        {
            Client = new MongoClient(SystemInfo.ConnectionString);
            db = Client.GetDatabase(SystemInfo.DataBase);
        }
    }
}
