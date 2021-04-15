using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessWordProject
{
    public partial class Category_level : Form
    {
        public Category_level()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SqlDataReader reader;
            string select_category = "select top 1 Word  from OurWords  where Category='" + comboBox_category.Text + "' and Level='" + comboBox_level.Text + "'order by NEWID() ";
            sqlCommand1.CommandText = select_category;

            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
                textBox = reader[0].ToString();
            }
            reader.Close();
            sqlConnection1.Close();
        }

        public string textBox
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public int MyProperty { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Category_level_Load(object sender, EventArgs e)
        {
            SqlDataReader reader;
            string select_category = "select distinct Category from OurWords ";
            sqlCommand1.CommandText = select_category;

            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();
            while (reader.Read())
            {
                comboBox_category.Items.Add(reader["Category"]);
            }
            reader.Close();
            sqlConnection1.Close();


            SqlDataReader reader1;
            string select_level = "select distinct Level from OurWords ";
            sqlCommand1.CommandText = select_level;

            sqlConnection1.Open();
            reader1 = sqlCommand1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox_level.Items.Add(reader1[0]);
            }
            reader1.Close();
            sqlConnection1.Close();
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
