using BowlingGame.BE;
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
    public class GameController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        public GameController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        [HttpPost]
        public void Save([FromBody] GameDto value)
        {

            UnitOfWork.SaveGame(UnitOfWork.Game.Build(value));
            UnitOfWork.Complete();
        }
    }
}
