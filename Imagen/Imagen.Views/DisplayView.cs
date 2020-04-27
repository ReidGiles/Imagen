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
    /// <summary>
    /// View for display.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public partial class DisplayView : Form, IDisplayListener
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        // DECLARE an Action<string, int, int> to load images, call it '_loadImage':
        private Action<string, int, int> _loadImage;

        // DECLARE an Action<string, int, int, float> to rotate images, call it '_rotateImage':
        private Action<string, int, int, float> _rotateImage;

        // DECLARE an Action<string, int, int, bool, bool> to flip images, call it '_flipImage':
        private Action<string, int, int, bool, bool> _flipImage;

        // DECLARE an Action<string, int, int> to resize images, call it '_resizeImage':
        private Action<string, int, int> _resizeImage;

        // DECLARE an Action<Image>, call it '_saveImage':
        private Action<Image> _saveImage;

        // DECLARE a string to store the displayed image key, call it '_key':
        private string _key;

        // DECLARE a PictureBox to hold the displayed image, call it '_pictureBox':
        private PictureBox _pictureBox;

        /// <summary>
        /// Constructor for the DisplayView
        /// </summary>
        public DisplayView()
        {
            InitializeComponent();

            // no smaller than design time size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

        }

        /// <summary>
        /// Initialises the display view with an execute delegate and a collection of Actions to execute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="loadImage"></param>
        /// <param name="rotateImage"></param>
        /// <param name="flipImage"></param>
        /// <param name="resizeImage"></param>
        /// <param name="key"></param>
        public void Initialise(ExecuteDelegate execute, Action<string, int, int> loadImage, Action<string, int, int, float> rotateImage, Action<string, int, int, bool, bool> flipImage, Action<string, int, int> resizeImage, Action<Image> saveImage, string key)
        {
            // SET _execute:
            _execute = execute;

            // SET _loadImage:
            _loadImage = loadImage;

            // SET _rotateImage:
            _rotateImage = rotateImage;

            // SET _flipImage:
            _flipImage = flipImage;

            // SET _resizeImage:
            _resizeImage = resizeImage;

            // SET _saveImage:
            _saveImage = saveImage;

            // SET _key:
            _key = key;

            // SET _pictureBox:
            _pictureBox = new PictureBox();

            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);

            // Execute openImage:
            _execute(openImage);

            // SET form anchors:
            btnRotateLeft.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            btnRotateRight.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnFlipVertical.Anchor = AnchorStyles.Bottom;
            btnFlipHorizontal.Anchor = AnchorStyles.Bottom;
            lblHeight.Anchor = AnchorStyles.Bottom;
            lblWidth.Anchor = AnchorStyles.Bottom;
            txtHeight.Anchor = AnchorStyles.Bottom;
            txtWidth.Anchor = AnchorStyles.Bottom;
            btnExport.Anchor = AnchorStyles.Bottom;
            btnResize.Anchor = AnchorStyles.Bottom;
        }

        /// <summary>
        /// Listener method, receives display events.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnNewInput(object source, DisplayEventArgs args)
        {
            // Reset picture box location
            _pictureBox.Location = new Point(0, 0);
            // Reset picture box size to image size
            _pictureBox.Size = new Size(args.Image.Width, args.Image.Height);
            // Reset picture box images
            _pictureBox.Image = args.Image;
            // Add picture box to displayPanel
            displayPanel.Controls.Add(_pictureBox);
        }

        /// <summary>
        /// Dynamically resizes the display image as the form is resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayView_Resize(object sender, EventArgs e)
        {
            // Resize display pannel while leaving space for controls
            displayPanel.Width = Width - 40;
            displayPanel.Height = Height - 225;

            // Lock display panel to original aspect ratio
            if (displayPanel.Width > displayPanel.Height)
                displayPanel.Width = displayPanel.Height;
            else if (displayPanel.Height > displayPanel.Width)
                displayPanel.Height = displayPanel.Width;

            // Create a new command, give it _loadImages as an action and image key, display width and display height as parameters
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            // Execute the command
            _execute(openImage);
        }

        /// <summary>
        /// Rotates the display image left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRotateLeft_Click(object sender, EventArgs e)
        {
            // Create a new command, give it _rotateImage as an action and image key, display pannel width, height and rotation ammount as parameters
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, -90);
            // Create a new command, give it _loadImages as an action and image key, display width and display height as parameters
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            // Execute the commands
            _execute(resizeImage);
            _execute(openImage);
        }

        /// <summary>
        /// Rotates the display image right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRotateRight_Click(object sender, EventArgs e)
        {
            // Create a new command, give it _rotateImage as an action and image key, display pannel width, height and rotation ammount as parameters
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, 90);
            // Execute the command
            _execute(resizeImage);
        }

        /// <summary>
        /// Flips the display image vertically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFlipVertical_Click(object sender, EventArgs e)
        {
            // Create a new command, give it _flipImage as an action and image key, display panel width, height and flip values as parameters
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, true, false);
            // Execute the command
            _execute(flipImage);
        }

        /// <summary>
        /// Flips the display image horizontally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFlipHorizontal_Click(object sender, EventArgs e)
        {
            // Create a new command, give it _flipImage as an action and image key, display panel width, height and flip values as parameters
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, false, false);
            // Execute the command
            _execute(flipImage);
        }

        /// <summary>
        /// Resizes the image in storage using the user input size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResize_Click(object sender, EventArgs e)
        {
            // DECLARE and SET width to user input value
            int width = Convert.ToInt32(txtWidth.Text);
            // DECLARE and SET height to user input value
            int height = Convert.ToInt32(txtHeight.Text);
            // Create a new command, give it _resizeImage as an action and image key, width and height as parameters
            ICommand resizeImage = new Command<string, int, int>(_resizeImage, _key, width, height);
            // Create a new command, give it _loadImages as an action and image key, display width and display height as parameters
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            // Execute the commands
            _execute(resizeImage);
            _execute(openImage);
        }

        /// <summary>
        /// Saves a copy of the image to the user specified file path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            // Create a new command, give it _saveImage as an action and _pictureBox.Image as a parameter
            ICommand saveImage = new Command<Image>(_saveImage, _pictureBox.Image);
            // Execute the command
            _execute(saveImage);
        }      
    }
}