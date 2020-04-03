using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Controller
{
    public class Command : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action _action;

        /// <summary>
        /// Constructor of objects of type Command
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        public Command(Action action)
        {
            // Assign action and size:
            _action = action;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action();
        }
    }

    /// <summary>
    /// Generic Command class, which provides for a single parameter of type T for Execute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action<T> _action;

        // DECLARE a variable of type T to represent the required data, call it _data:
        private T _data;

        /// <summary>
        /// Constructor of objects of type Command<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        /// <param name="data">The parameter for the action</param>
        public Command(Action<T> action, T data)
        {
            // Assign action and size:
            _action = action;
            _data = data;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action(_data);
        }
    }
}