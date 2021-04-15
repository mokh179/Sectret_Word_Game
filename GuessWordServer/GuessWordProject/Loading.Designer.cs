
namespace GuessWordProject
{
    partial class Loading
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadLab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GuessWordProject.Properties.Resources.Loading1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadLab
            // 
            this.LoadLab.BackColor = System.Drawing.Color.Transparent;
            this.LoadLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadLab.Font = new System.Drawing.Font("Lemon", 69.74999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadLab.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LoadLab.Location = new System.Drawing.Point(0, 0);
            this.LoadLab.Name = "LoadLab";
            this.LoadLab.Size = new System.Drawing.Size(624, 453);
            this.LoadLab.TabIndex = 1;
            this.LoadLab.Text = "Loading...";
            this.LoadLab.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 8000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 453);
            this.Controls.Add(this.LoadLab);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(740, 574);
            this.MinimumSize = new System.Drawing.Size(640, 492);
            this.Name = "Loading";
            this.Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LoadLab;
        private System.Windows.Forms.Timer timer1;
    }
}