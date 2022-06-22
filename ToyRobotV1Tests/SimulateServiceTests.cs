using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotToy.Commands;
using RobotToy.Domain.Entities;
using RobotToy.Services;

namespace ToyRobotV1Tests
{
    [TestClass]
    public class SimulateServiceTests
    {
        /// <summary>
        /// Givens the valid command should return success.
        /// </summary>
        [TestMethod]
        public void Given_valid_command_should_return_success()
        {
            var simulatorService = new SimulateService();
            var steps = new List<string>()
            {
                "MOVE"
            };
            var command = new SimulateCommand("PLACE 0,0,NORTH", steps, "REPORT");
            var testTable = new Table(5, 5);
            var simulation = new Simulator(testTable);
            simulation.Place(0,0,"NORTH");
            simulation.RobotMoves("move");
            var simulatedOutput = simulation.Toy.Report();
            var output = simulatorService.Initialize(command);

            Assert.AreEqual(output, simulatedOutput);
        }
    }
}
