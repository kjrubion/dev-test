using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RobotToy.Commands;
using RobotToy.Domain.Entities;
using static System.Int32;

namespace RobotToy.Services
{
    public class SimulateService
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage = "Prerequisite failed";
        /// <summary>
        /// Initializes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public string Initialize(SimulateCommand command)
        {
            var testTable = new Table(5, 5);
            var simulation = new Simulator(testTable);
            return ExecuteCommand(command, simulation);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="simulator">The simulator.</param>
        /// <returns></returns>
        private string ExecuteCommand(SimulateCommand command, Simulator simulator)
        {
            string message;
            if (!string.IsNullOrEmpty(command.Place))
            {
                var coordinates = command.Place.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {
                    var eastTest = TryParse(coordinates[1], out var east);
                    var northTest = TryParse(coordinates[2], out var north);
                    if (eastTest && northTest)
                    {
                        simulator.Place(east, north, coordinates[3]);
                    }
                }
                if (simulator.Toy == null)
                {
                    message = ErrorMessage;
                }
            }
            if (command.Step.Contains("MOVE") || command.Step.Contains("RIGHT") || command.Step.Contains("LEFT"))
            {
                foreach (var step in command.Step)
                {
                    simulator.RobotMoves(step.ToLower());
                }
            }
            message = !string.IsNullOrEmpty(command.Report) ? simulator.Report() : ErrorMessage;
            return message;
        }
    }
}
