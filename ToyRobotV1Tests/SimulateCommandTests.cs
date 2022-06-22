using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotToy.Commands;

namespace ToyRobotV1Tests
{
    [TestClass]
    public class SimulateCommandTests
    {
        /// <summary>Givens a command when empty should not be valid.</summary>
        [TestMethod]
        public void Given_a_command_when_empty_should_not_be_valid()
        {
            var command = new SimulateCommand("", new List<string>(), "");
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        /// <summary>Given a valid command should be valid.</summary>
        [TestMethod]
        public void Given_a_valid_command_should_be_valid()
        {
            var steps = new List<string>()
            {
                "MOVE", "MOVE", "LEFT", "MOVE"
            };
            var command = new SimulateCommand("PLACE 0,0,NORTH",steps, "REPORT");
            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
