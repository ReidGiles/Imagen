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
    /// View for collection.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public partial class CollectionView : Form, ICollectionListener
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        // DECLARE an Action<string, int, int> to load images, call it '_loadImage':
        private Action<IList<string>, int, int> _loadImages;

        // DECLARE an Action<string, Image> to open a display view, call it '_openDisplayView':
        private Action<string, Image> _openDisplayView;

        int imageNum = 0;
        int x = 0;
        int y = 0;
        int _height = 150;
        int _width = 150;

        public CollectionView()
        {
            InitializeComponent();

            // No smaller than design time size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // No larger than design time size
            this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);
        }

        public void Initialise(ExecuteDelegate execute, Action<IList<string>, int, int> loadImages, Action<string, Image> openDisplayView)
        {
            // SET _execute:
            _execute = execute;

            // SET _loadImages:
            _loadImages = loadImages;

            // SET _openDisplayView:
            _openDisplayView = openDisplayView;

            // SET auto scroll to true on image panel to allow scrolling:
            this.imagePanel.AutoScroll = true;
        }

        /// <summary>
        /// Listener method, receives collection events.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void ICollectionListener.OnNewInput(object source, CollectionEventArgs args)
        {
            // FOREACh imageKey in image dictionary:
            foreach (string key in args.Images.Keys)
            {
                // Increment i:
                imageNum += 1;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = new Size(_width, _height);
                picture.Image = args.Images[key];
                picture.Name = key;
                picture.DoubleClick += new EventHandler(Picture_Click);
                imagePanel.Controls.Add(picture);

                if (imageNum % 3 == 0)
                {
                    x = 0;
                    y += 175;
                }
                else
                {
                    x += 175;
                }
            }
        }

        /// <summary>
        /// Loads images from the filepicker into the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoadImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Multiselect = true;
            DialogResult result = filePicker.ShowDialog();

            ICommand loadImages = new Command<IList<string>, int, int>(_loadImages, filePicker.FileNames.ToList(), _width, _height);
            _execute(loadImages);
        }

        /// <summary>
        /// Opens a display view of the image that has been double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picture_Click(object sender, EventArgs e)
        {
            Console.WriteLine((sender as PictureBox).Name);

            ICommand openDisplayView = new Command<string, Image>(_openDisplayView, (sender as PictureBox).Name, (sender as PictureBox).Image);
            _execute(openDisplayView);
        }
    }
}