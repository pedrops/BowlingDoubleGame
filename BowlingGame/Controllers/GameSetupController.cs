using BowlingGame.BE;
using BowlingGame.BL.Interfaces;
using BowlingGame.DA.Interfaces;
using BowlingGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BowlingGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSetupController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        private IBowlingCache BowlingCache;
        public GameSetupController(IUnitOfWork UnitOfWork, IBowlingCache BowlingCache)
        {
            this.UnitOfWork = UnitOfWork;
            this.BowlingCache = BowlingCache;
        }
        [HttpPost]
        public void Post([FromBody] GameSetupDto gameSetupDto)
        {
            UnitOfWork.GameSetup.Save(UnitOfWork.GameSetup.Build(gameSetupDto, gameSetupDto.Player, gameSetupDto.Games));
            UnitOfWork.Complete();
        }
        [HttpGet("Score")]
        public async Task<string> GetScore(int GameSetupId,int PlayerId)
        {
            return await BowlingCache.getScore(GameSetupId,PlayerId);
        }
    }
}
