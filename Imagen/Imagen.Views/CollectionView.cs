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
    public partial class CollectionView : Form, ICollectionListener
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        private Action<IList<string>, int, int> _loadImages;

        private Action<string, Image> _openDisplayView;

        int imageNum = 0;
        int x = 0;
        int y = 0;
        int _height = 150;
        int _width = 150;

        public CollectionView()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate execute, Action<IList<string>, int, int> loadImages, Action<string, Image> openDisplayView)
        {
            // SET _execute:
            _execute = execute;

            _loadImages = loadImages;

            _openDisplayView = openDisplayView;

            this.imagePanel.AutoScroll = true;
        }

        void ICollectionListener.OnNewInput(object source, CollectionEventArgs args)
        {
            foreach (string key in args.Images.Keys)
            {
                imageNum += 1;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = new Size(_width, _height);
                picture.Image = args.Images[key];
                picture.Name = key;
                picture.DoubleClick += new EventHandler(picture_Click);
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

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Multiselect = true;
            DialogResult result = filePicker.ShowDialog();

            ICommand loadImages = new Command<IList<string>, int, int>(_loadImages, filePicker.FileNames.ToList(), _width, _height);
            _execute(loadImages);
        }

        private void picture_Click(object sender, EventArgs e)
        {
            Console.WriteLine((sender as PictureBox).Name);

            ICommand openDisplayView = new Command<string, Image>(_openDisplayView, (sender as PictureBox).Name, (sender as PictureBox).Image);
            _execute(openDisplayView);
        }
    }
}