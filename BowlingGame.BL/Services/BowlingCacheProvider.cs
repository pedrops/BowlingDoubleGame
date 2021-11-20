using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.BL.Interfaces;
using BowlingGame.DA.Interfaces;

namespace BowlingGame.BL.Services
{
    public class BowlingCacheProvider : IBowlingCacheProvider
    {
        private IUnitOfWork unitOfWork { get; set; }
        public BowlingCacheProvider(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<string> getScore(int GameSetudId, int PlayerId)
        {
            return unitOfWork.GetScore(GameSetudId,PlayerId);
        }
    }
}
