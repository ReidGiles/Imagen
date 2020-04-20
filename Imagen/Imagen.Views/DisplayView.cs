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
        public void Initialise(ExecuteDelegate execute, Action<string, int, int> loadImage, Action<string, int, int, float> rotateImage, Action<string, int, int, bool, bool> flipImage, Action<string, int, int> resizeImage, string key)
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
            _pictureBox.Location = new Point(0, 0);
            // here
            _pictureBox.Size = new Size(args.Image.Width, args.Image.Height);
            _pictureBox.Image = args.Image;
            displayPanel.Controls.Add(_pictureBox);
        }

        /// <summary>
        /// Dynamically resizes the display image as the form is resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayView_Resize(object sender, EventArgs e)
        {
            displayPanel.Width = Width - 40;
            displayPanel.Height = Height - 225;

            if (displayPanel.Width > displayPanel.Height)
                displayPanel.Width = displayPanel.Height;
            else if (displayPanel.Height > displayPanel.Width)
                displayPanel.Height = displayPanel.Width;

            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(openImage);
        }

        /// <summary>
        /// Rotates the display image left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, -90);
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(resizeImage);
            _execute(openImage);
        }

        /// <summary>
        /// Rotates the display image right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, 90);
            _execute(resizeImage);
        }

        /// <summary>
        /// Flips the display image vertically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, true, false);
            _execute(flipImage);
        }

        /// <summary>
        /// Flips the display image horizontally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, false, false);
            _execute(flipImage);
        }

        /// <summary>
        /// Resizes the image in storage using the user input size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResize_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(txtWidth.Text);
            int height = Convert.ToInt32(txtHeight.Text);
            ICommand resizeImage = new Command<string, int, int>(_resizeImage, _key, width, height);
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(resizeImage);
            _execute(openImage);
        }

        /// <summary>
        /// Saves a copy of the image to the user specified file path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            /*
             * Code reference:
             * 
             * URL: docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
             * Author: Microsoft
             * Date: 03/30/2017
            */

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        _pictureBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        _pictureBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        _pictureBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }      
    }
}