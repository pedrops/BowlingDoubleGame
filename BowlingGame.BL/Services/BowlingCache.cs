using BowlingGame.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BowlingGame.BL.Interfaces;
using System.Threading.Tasks;

namespace BowlingGame.BL.Services
{
    public class BowlingCache : IBowlingCache
    {
        //private IUnitOfWork unitOfWork { get; set; }
        //private IGameSetupRepository GameSetupRepo { get; set; }
        private IBowlingCacheProvider CacheProvider { get; set; }

        private string UserScore { get; set; }
        private DateTime LastUpdated { get; set; }
        public BowlingCache(IBowlingCacheProvider CacheProvider)
        {
            this.CacheProvider = CacheProvider;
        }
        public async Task<string> getScore(int GameSetudId, int PlayerId)
        {
            
            if ((DateTime.Now - LastUpdated).TotalSeconds > 5)
            {
                UserScore = await CacheProvider.getScore(GameSetudId,PlayerId);
                LastUpdated = DateTime.Now;
            }
            return UserScore;
        }
    }
}
