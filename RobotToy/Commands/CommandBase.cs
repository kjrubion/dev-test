using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotToy.Commands
{
    /// <summary>
    /// Abstract command base
    /// </summary>
    public abstract class CommandBase 
    {
        /// <summary>Validates this instance.</summary>
        public abstract void Validate();
    }

}
