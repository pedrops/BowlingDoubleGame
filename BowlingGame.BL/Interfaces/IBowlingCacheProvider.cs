﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BL.Interfaces
{
    public interface IBowlingCacheProvider
    {
        public Task<string> getScore(int GameSetudId, int PlayerId);
    }
}
