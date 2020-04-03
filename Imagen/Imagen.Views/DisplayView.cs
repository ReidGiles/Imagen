using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imagen.Core;

namespace Imagen.Views
{
    public partial class DisplayView : Form
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        /// <summary>
        /// Constructor for the DisplayView
        /// </summary>
        public DisplayView()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate execute)
        {
            // SET _execute:
            _execute = execute;
        }
    }
}