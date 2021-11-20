using BowlingGame.BE;
using BowlingGame.DA;
using BowlingGame.DA.Interfaces;
using BowlingGame.DTO;
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
    public class PlayerController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        public PlayerController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public void Post([FromBody] PlayerDto value)
        {
            UnitOfWork.Player.Save(UnitOfWork.Player.Build(value));
            UnitOfWork.Complete();
        }
    }
}
