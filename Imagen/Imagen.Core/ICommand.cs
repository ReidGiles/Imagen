using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Executes a command.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        void Execute();
    }
}