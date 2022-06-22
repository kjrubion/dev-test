using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Flunt.Notifications;
using Flunt.Validations;

namespace RobotToy.Commands
{
    public class SimulateCommand : Notifiable<Notification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateCommand"/> class.
        /// </summary>
        public SimulateCommand() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateCommand"/> class.
        /// </summary>
        /// <param name="place">The place.</param>
        /// <param name="step">The step.</param>
        /// <param name="report">The report.</param>
        public SimulateCommand(string place, List<string> step, string report)
        {
            Place = place;
            Step = step;
            Report = report;
        }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        public string Place { get; set; }
        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        public List<string> Step { get; set; }
        /// <summary>
        /// Gets or sets the report.
        /// </summary>
        /// <value>
        /// The report.
        /// </value>
        public string Report { get; set; }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            AddNotifications(new Contract<SimulateCommand>()
                .Requires()
                .IsNotNullOrEmpty(Place, nameof(Place), "Place is Null or Empty")
                .IsGreaterThan(Step,1,"Steps needs to be Greater than 1")
                .IsNotNullOrEmpty(Report, nameof(Report), "Report is Null or Empty"));
        }

    }
}
