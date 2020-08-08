using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sqldeneme1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server=HP-AYBARK;Database=sinema;User Id=HP-AYBARK;Password=123456;");

        public Form1()
        {
            InitializeComponent();
            DatagridYenile();
            TextBoxTemizle();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("insert into Film (F_Adi,Sure,TurID,SalonID) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedIndex + "')", conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
            TextBoxTemizle();
        }
  
        private void TextBoxTemizle()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        //"Server=[HP-AYBARK];Database=[sinema];User Id=[HP-AYBARK];Password=[123456];"
        protected void DatagridYenile()
        {
            conn.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select f.Id,F_Adi,Sure,ft.TurAdi from Film f inner join FilmTur ft on f.TurID = ft.Id", conn);
            adptr.Fill(tbl);
            conn.Close();
            dataGridView1.DataSource = tbl;
            SalonGetir();
            SeansGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Remove(listBox1.SelectedItem);
            conn.Open();
            SqlCommand kmt = new SqlCommand("DELETE  Film where Id=" + dataGridView1.CurrentRow.Cells["Id"].Value.ToString(), conn);
            kmt.ExecuteNonQuery();
            conn.Close();
            DatagridYenile();
        }

        private void SalonGetir()
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Salon", conn);
            int j = Convert.ToInt32(cmd1.ExecuteScalar());
            for (int i = 1; i <= j; i++)
            {
                string sorgu = "select SalonAdi from Salon where Id= '" + i + "' ";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                string a1 = cmd.ExecuteScalar().ToString();
                comboBox2.Items.Add(a1);
            }
            conn.Close();
        }

        private void SeansGetir()
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Seans", conn);
            int j = Convert.ToInt32(cmd1.ExecuteScalar());
            for (int i = 1; i < j; i++)
            {
                string sorgu = "select Bilgiler from Seans where Id= '" + i + "' ";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                string a1 = cmd.ExecuteScalar().ToString();
                comboBox3.Items.Add(a1);
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable tbl1 = new DataTable();
            string deger1 = comboBox2.SelectedIndex.ToString();
            SqlDataAdapter sorgu1 = new SqlDataAdapter("select ss.FilmID,ss.SalonID,s.Bilgiler from SalonSeans ss inner join Seans s on ss.SeansID = s.Id where ss.SalonID=" + deger1, conn);
            sorgu1.Fill(tbl1);
            dataGridView2.DataSource = tbl1;
            conn.Close();
            if (checkBox1.Checked)
            {
                //hicbisi
            }
            else
            {
                MessageBox.Show("Seans secerken bir onceki filmin bitis saatini dikakte alin.", "Uyari!");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //

    }
}
