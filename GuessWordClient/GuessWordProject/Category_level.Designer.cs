
namespace GuessWordProject
{
    partial class Category_level
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_level = new System.Windows.Forms.ComboBox();
            this.comboBox_category = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Coral;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button2.Location = new System.Drawing.Point(271, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 31);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Location = new System.Drawing.Point(120, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 31);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_level
            // 
            this.comboBox_level.FormattingEnabled = true;
            this.comboBox_level.Location = new System.Drawing.Point(184, 62);
            this.comboBox_level.Name = "comboBox_level";
            this.comboBox_level.Size = new System.Drawing.Size(186, 21);
            this.comboBox_level.TabIndex = 10;
            // 
            // comboBox_category
            // 
            this.comboBox_category.FormattingEnabled = true;
            this.comboBox_category.Location = new System.Drawing.Point(184, 15);
            this.comboBox_category.Name = "comboBox_category";
            this.comboBox_category.Size = new System.Drawing.Size(186, 21);
            this.comboBox_category.TabIndex = 9;
            this.comboBox_category.SelectedIndexChanged += new System.EventHandler(this.comboBox_category_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(82, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(68, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Category";
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=Hady;Initial Catalog=Word;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "SELECT        OurWords.*, ID AS Expr1, Word AS Expr2, Level AS Expr3, Category AS" +
    " Expr4\r\nFROM            OurWords";
            this.sqlCommand1.Connection = this.sqlConnection1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(370, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Visible = false;
            // 
            // Category_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::GuessWordProject.Properties.Resources.zx;
            this.ClientSize = new System.Drawing.Size(433, 343);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_level);
            this.Controls.Add(this.comboBox_category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Category_level";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category_level";
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.Load += new System.EventHandler(this.Category_level_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_level;
        private System.Windows.Forms.ComboBox comboBox_category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.TextBox textBox1;
    }
}