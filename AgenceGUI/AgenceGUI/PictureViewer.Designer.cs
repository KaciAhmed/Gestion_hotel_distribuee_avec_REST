
namespace AgenceGUI
{
    partial class PictureViewer
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
            this.pictureBoxChambre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChambre)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxChambre
            // 
            this.pictureBoxChambre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxChambre.Image = global::AgenceGUI.Properties.Resources._404;
            this.pictureBoxChambre.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxChambre.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxChambre.Name = "pictureBoxChambre";
            this.pictureBoxChambre.Size = new System.Drawing.Size(997, 548);
            this.pictureBoxChambre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxChambre.TabIndex = 0;
            this.pictureBoxChambre.TabStop = false;
            this.pictureBoxChambre.Click += new System.EventHandler(this.pictureBoxChambre_Click);
            // 
            // PictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 548);
            this.Controls.Add(this.pictureBoxChambre);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PictureViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PictureViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChambre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxChambre;
    }
}