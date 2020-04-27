using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /*
    * Code reference:
    * 
    * URL: https://worcesterbb.blackboard.com/bbcswebdav/pid-1419500-dt-content-rid-3803236_1/xid-3803236_1
    * Author: Marc Price
    * Date: n.d.
    */

    /// <summary>
    /// Command class, stores an action for execute.
    /// </summary>
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

    /// <summary>
    /// Generic Command class, which provides for two parameters of type T & Y for Execute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T, Y> : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action<T, Y> _action;

        // DECLARE a variable of type T to represent the required data, call it _data:
        private T _data;

        private Y _yData;

        /// <summary>
        /// Constructor of objects of type Command<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        /// <param name="data">The parameter for the action</param>
        public Command(Action<T, Y> action, T data, Y yData)
        {
            // Assign action and size:
            _action = action;
            _data = data;
            _yData = yData;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action(_data, _yData);
        }
    }

    /// <summary>
    /// Generic Command class, which provides for three parameters of type T, Y & U for Execute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T, Y, U> : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action<T, Y, U> _action;

        // DECLARE a variable of type T to represent the required data, call it _data:
        private T _data;

        // DECLARE a variable of type Y to represent the required data, call it _yData:
        private Y _yData;

        // DECLARE a variable of type U to represent the required data, call it _uData:
        private U _uData;

        /// <summary>
        /// Constructor of objects of type Command<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        /// <param name="data">The parameter for the action</param>
        public Command(Action<T, Y, U> action, T data, Y yData, U uData)
        {
            // Assign action and size:
            _action = action;
            _data = data;
            _yData = yData;
            _uData = uData;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action(_data, _yData, _uData);
        }
    }

    /// <summary>
    /// Generic Command class, which provides for four parameters of type T, Y, U & I for Execute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T, Y, U, I> : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action<T, Y, U, I> _action;

        // DECLARE a variable of type T to represent the required data, call it _data:
        private T _data;

        // DECLARE a variable of type Y to represent the required data, call it _yData:
        private Y _yData;

        // DECLARE a variable of type U to represent the required data, call it _uData:
        private U _uData;

        // DECLARE a variable of type I to represent the required data, call it _iData:
        private I _iData;

        /// <summary>
        /// Constructor of objects of type Command<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        /// <param name="data">The parameter for the action</param>
        public Command(Action<T, Y, U, I> action, T data, Y yData, U uData, I iData)
        {
            // Assign action and size:
            _action = action;
            _data = data;
            _yData = yData;
            _uData = uData;
            _iData = iData;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action(_data, _yData, _uData, _iData);
        }
    }

    /// <summary>
    /// Generic Command class, which provides for five parameters of type T, Y, U, I & O for Execute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T, Y, U, I, O> : ICommand
    {
        // DECLARE an to be executed by this command, call it _action:
        private Action<T, Y, U, I, O> _action;

        // DECLARE a variable of type T to represent the required data, call it _data:
        private T _data;

        // DECLARE a variable of type Y to represent the required data, call it _yData:
        private Y _yData;

        // DECLARE a variable of type U to represent the required data, call it _uData:
        private U _uData;

        // DECLARE a variable of type I to represent the required data, call it _iData:
        private I _iData;

        // DECLARE a variable of type O to represent the required data, call it _oData:
        private O _oData;

        /// <summary>
        /// Constructor of objects of type Command<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">The action to be executed by this command</param>
        /// <param name="data">The parameter for the action</param>
        public Command(Action<T, Y, U, I, O> action, T data, Y yData, U uData, I iData, O oData)
        {
            // Assign action and size:
            _action = action;
            _data = data;
            _yData = yData;
            _uData = uData;
            _iData = iData;
            _oData = oData;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute()
        {
            _action(_data, _yData, _uData, _iData, _oData);
        }
    }
}