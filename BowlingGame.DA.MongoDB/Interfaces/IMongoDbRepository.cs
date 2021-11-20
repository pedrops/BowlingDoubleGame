using MongoDB.Driver;

namespace BowlingGame.DA.MongoDB.Interfaces
{
    public interface IMongoDbRepository
    {
        public IMongoDatabase db { get; set; }
    }
}