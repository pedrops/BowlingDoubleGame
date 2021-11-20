using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.DA.Interfaces
{
    public interface IBaseRepository<IEntity> where IEntity : class
    {
        IEntity Get(int id);
        Task<IEnumerable<IEntity>> GetAll();
        void Save(IEntity entity);
        void Remove(IEntity entity);
    }
}
