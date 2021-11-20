using BowlingGame.DA.Interfaces;
using BowlingGame.DA.MongoDB.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DA.MongoDB.Repository
{
    public class BaseMongoRepository<IEntity> : IBaseRepository<IEntity> where IEntity : class
    {
        internal IMongoDbRepository _repository;
        IMongoCollection<IEntity> Collection;
        public BaseMongoRepository(IMongoDbRepository _repository,string CollectionName)
        {
            Collection = _repository.db.GetCollection<IEntity>(CollectionName);
        }
        public void Save(IEntity entity)
        {
            var filter = Builders<IEntity>.Filter.Eq("Id", entity.ToString());
            var selectedEntity = Collection.Find(filter).FirstOrDefault();
            if (selectedEntity != null)
                Collection.ReplaceOne(filter,entity);
            else
                Collection.InsertOne(entity);
        }

        public IEntity Get(int id)
        {
            var filter = Builders<IEntity>.Filter.Eq("Id", id.ToString());
            return Collection.Find(filter).FirstOrDefault();
        }

        public async Task<IEnumerable<IEntity>> GetAll()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public void Remove(IEntity entity)
        {
            var filter = Builders<IEntity>.Filter.Eq("Id", entity.ToString());
            Collection.DeleteOne(filter);
        }
    }
}
