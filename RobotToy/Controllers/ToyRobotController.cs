using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RobotToy.Commands;
using RobotToy.Services;

namespace RobotToy.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToyRobotController : ControllerBase
    {
        private readonly SimulateService _simulateService;
        public ToyRobotController(SimulateService simulateService)
        {
            _simulateService = simulateService;
        }

        [HttpPost]
        public IActionResult Simulate([FromBody] SimulateCommand command) => Ok(_simulateService.Initialize(command));
    }
}
