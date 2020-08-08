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
using System.Security.AccessControl;
using sqldeneme1.Properties;
using System.Text.RegularExpressions;

namespace sqldeneme1
{
    public partial class Form2 : Form
    {
        

        SqlConnection conn = new SqlConnection("Server=HP-AYBARK;Database=sinema;User Id=HP-AYBARK;Password=123456;");


        
        int sayac = 2; //lazim

        public Form2()
        {
            
            InitializeComponent();
            DatagridYenile();
            label2.Visible = false;


        
        }





        private void Form2_Load(object sender, EventArgs e)
        {


            label24.Visible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkMagenta;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 39, 40);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void PictureBoxAtama()
        {
            //iptal
            var MorKoltuk = new System.Drawing.Bitmap(Resources.koltuk28);
            var SiyahKoltuk = new System.Drawing.Bitmap(Resources.koltuk28black);
            Control ctrl = new PictureBox();
            if (ctrl is PictureBox)
            {
                foreach (var pb in this.Controls.OfType<PictureBox>())
                {

                    pb.Image = MorKoltuk;

                }

            }
        }




        //"Server=[HP-AYBARK];Database=[sinema];User Id=[HP-AYBARK];Password=[123456];"
        protected void DatagridYenile()
        {
            conn.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr =
                new SqlDataAdapter(
                    "Select f.Id,F_Adi,Sure,ft.TurAdi from Film f inner join FilmTur ft on f.TurID = ft.Id",
                    conn); //join sorgusu
            //string degerTur = dataGridView1.CurrentRow.Cells["TurID"].Value.ToString(); //secilen row un id degerini aliyor
            adptr.Fill(tbl);
            conn.Close();
            dataGridView1.DataSource = tbl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Seciniz.";
            conn.Open();
            DataTable tbl1 = new DataTable();
            string deger = dataGridView1.CurrentRow.Cells["Id"].Value.ToString(); //secilen row un id degerini aliyor
            SqlDataAdapter adptr1 = new SqlDataAdapter("Select SeansID from SalonSeans where FilmID=" + deger, conn);
            SeansGetir(int.Parse(deger)); //secilen film icin seanslari seciyor.
            adptr1.Fill(tbl1);
            conn.Close();

        }

        private void SeansGetir(int deger)
        {
            string sorgu = "select f_SalonSeansID from Film where Id='" + deger + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            label2.Text = a.ToString();
            //suan degerde secilen filmin salonseans id si var 
            string sorgu1 =
                "Select s.Bilgiler from SalonSeans ss  inner join Seans s on ss.SeansID=s.Id where SalonSeansID='" +
                label2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sorgu1, conn);
            string a1 = cmd1.ExecuteScalar().ToString();
            string sorgu2 =
                "Select sl.SalonAdi from SalonSeans ss inner join Salon sl on ss.SalonID=sl.Id where SalonSeansID='" +
                label2.Text + "'";
            label2.Text = a1;
            SqlCommand cmd2 = new SqlCommand(sorgu2, conn);
            string a2 = cmd2.ExecuteScalar().ToString();
            label4.Text = a2;
            comboBox1.Items.Add(a2 + "  " + a1);
            ////
            Seans2(deger);
            Seans3(deger);
        }

        private void Seans2(int deger)
        {
            string sorgu = "select f_SalonSeansID1 from Film where Id='" + deger + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            label2.Text = a.ToString();
            //suan degerde secilen filmin salonseans id si var 
            string sorgu1 =
                "Select s.Bilgiler from SalonSeans ss  inner join Seans s on ss.SeansID=s.Id where SalonSeansID='" +
                label2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sorgu1, conn);
            string a1 = cmd1.ExecuteScalar().ToString();
            string sorgu2 =
                "Select sl.SalonAdi from SalonSeans ss inner join Salon sl on ss.SalonID=sl.Id where SalonSeansID='" +
                label2.Text + "'";
            label2.Text = a1;
            SqlCommand cmd2 = new SqlCommand(sorgu2, conn);
            string a2 = cmd2.ExecuteScalar().ToString();
            label4.Text = a2;
            comboBox1.Items.Add(a2 + "  " + a1);
            //
        }

        private void Seans3(int deger)
        {
            string sorgu = "select f_SalonSeansID2 from Film where Id='" + deger + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            label2.Text = a.ToString();
            //suan degerde secilen filmin salonseans id si var 
            string sorgu1 =
                "Select s.Bilgiler from SalonSeans ss  inner join Seans s on ss.SeansID=s.Id where SalonSeansID='" +
                label2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sorgu1, conn);
            string a1 = cmd1.ExecuteScalar().ToString();
            string sorgu2 =
                "Select sl.SalonAdi from SalonSeans ss inner join Salon sl on ss.SalonID=sl.Id where SalonSeansID='" +
                label2.Text + "'";
            label2.Text = a1;
            SqlCommand cmd2 = new SqlCommand(sorgu2, conn);
            string a2 = cmd2.ExecuteScalar().ToString();
            label4.Text = a2;
            comboBox1.Items.Add(a2 + "  " + a1);
            //
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string salonsecim = comboBox1.Text.Substring(0, 7);
            label25.Text = salonsecim;
            label4.Text = salonsecim;
            conn.Open();
            string sorgu =
                "select ss.SalonSeansID from Salon s inner join SalonSeans ss on s.Id=ss.SalonID where SalonAdi='" +
                salonsecim + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            int salonseansid = Convert.ToInt32(cmd.ExecuteScalar());
            //Salonseansid
            
            //
            
            //
            
            DataTable tbl1 = new DataTable();
            SqlDataAdapter adptr1 =
                new SqlDataAdapter(
                    "select s_KoltukID,s_KoltukID1,s_KoltukID2,s_KoltukID3,s_KoltukID4 from Satis where s_SalonSeansID= " + salonseansid, conn); 
            
            adptr1.Fill(tbl1);
            conn.Close();
            label25.Text = tbl1;





            //
            // conn.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("???");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatagridYenile();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void koltuk10_Click(object sender, EventArgs e)
        {
            //           Koltuk Koltukd = new Koltuk();
            //  Koltukd.KoltukDurum = KoltukDurum.Bos;


            koltuksecme(sender);

            //


        }

        private void koltuksecme(object sender)
        {
            
            Koltuk TiklananKoltuk = (Koltuk)sender;
            
            if (sayac == 2)
            {
                TiklananKoltuk.KoltukDurum = KoltukDurum.Satildi;
                sayac = sayac - 1;
            }
            else
            {
                TiklananKoltuk.KoltukDurum = KoltukDurum.Bos;
                sayac = sayac + 1;
            }
            
            string Koltukno = Regex.Replace(TiklananKoltuk.Name, @"\D", "");
            

        }










        private void koltuk10_MouseDown(object sender, EventArgs e)
        {

        }
        private void koltuk10_MouseUp(object sender, EventArgs e)
        {

        }

        private void koltuk1_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk2_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk3_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk4_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk5_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk6_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk7_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk8_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk9_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk11_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk12_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk13_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk14_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk15_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk16_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk17_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk18_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk19_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk20_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk21_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk22_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk23_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk24_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk25_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk26_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk27_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk28_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk29_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk30_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk31_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk32_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk33_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk34_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk35_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk36_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk37_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk38_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk39_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk40_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk41_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk42_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk43_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk44_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk45_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk46_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk47_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk48_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk49_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk50_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk51_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk52_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk53_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk54_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk55_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk57_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk56_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk58_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk59_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk60_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk61_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk62_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk63_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk64_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk65_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk66_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk67_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk68_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk69_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk70_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk71_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk72_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk73_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk74_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk75_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk76_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk77_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk78_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk79_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk80_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk81_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk82_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk83_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk84_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk85_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk86_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk87_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk88_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk89_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk90_Click(object sender, EventArgs e)
        {
            koltuksecme(sender);
        }

        private void koltuk10_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void koltuk10_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
