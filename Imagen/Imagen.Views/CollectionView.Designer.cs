namespace Imagen.Views
{
    partial class CollectionView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadImages = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnLoadImages
            // 
            this.btnLoadImages.Location = new System.Drawing.Point(232, 526);
            this.btnLoadImages.Name = "btnLoadImages";
            this.btnLoadImages.Size = new System.Drawing.Size(100, 23);
            this.btnLoadImages.TabIndex = 0;
            this.btnLoadImages.Text = "Load Images";
            this.btnLoadImages.UseVisualStyleBackColor = true;
            this.btnLoadImages.Click += new System.EventHandler(this.btnLoadImages_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.Location = new System.Drawing.Point(12, 12);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(560, 508);
            this.imagePanel.TabIndex = 1;
            // 
            // CollectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.btnLoadImages);
            this.Name = "CollectionView";
            this.Text = "CollectionView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImages;
        private System.Windows.Forms.Panel imagePanel;
    }
}