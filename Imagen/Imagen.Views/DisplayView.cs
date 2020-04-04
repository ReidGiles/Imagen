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
    public partial class DisplayView : Form, IDisplayListener
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        private Action<string, int, int> _loadImage;

        private Action<string, int, int, float> _rotateImage;

        private Action<string, int, int, bool, bool> _flipImage;

        private Action<string, int, int> _resizeImage;

        private string _key;

        private PictureBox _pictureBox;

        /// <summary>
        /// Constructor for the DisplayView
        /// </summary>
        public DisplayView()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate execute, Action<string, int, int> loadImage, Action<string, int, int, float> rotateImage, Action<string, int, int, bool, bool> flipImage, Action<string, int, int> resizeImage, string key)
        {
            // SET _execute:
            _execute = execute;

            _loadImage = loadImage;

            _rotateImage = rotateImage;

            _flipImage = flipImage;

            _resizeImage = resizeImage;

            _key = key;

            _pictureBox = new PictureBox();

            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(openImage);
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

        public void OnNewInput(object source, DisplayEventArgs args)
        {
            _pictureBox.Location = new Point(0, 0);
            _pictureBox.Size = new Size(args.Image.Width, args.Image.Height);
            _pictureBox.Image = args.Image;
            displayPanel.Controls.Add(_pictureBox);
        }

        private void DisplayView_Resize(object sender, EventArgs e)
        {
            displayPanel.Width = Width - 40;
            displayPanel.Height = Height - 225;
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(openImage);
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, -90);
            _execute(resizeImage);
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            ICommand resizeImage = new Command<string, int, int, float>(_rotateImage, _key, displayPanel.Width, displayPanel.Height, 90);
            _execute(resizeImage);
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, true, false);
            _execute(flipImage);
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            ICommand flipImage = new Command<string, int, int, bool, bool>(_flipImage, _key, displayPanel.Width, displayPanel.Height, false, false);
            _execute(flipImage);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(txtWidth.Text);
            int height = Convert.ToInt32(txtHeight.Text);
            ICommand resizeImage = new Command<string, int, int>(_resizeImage, _key, width, height);
            ICommand openImage = new Command<string, int, int>(_loadImage, _key, displayPanel.Width, displayPanel.Height);
            _execute(resizeImage);
            _execute(openImage);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
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