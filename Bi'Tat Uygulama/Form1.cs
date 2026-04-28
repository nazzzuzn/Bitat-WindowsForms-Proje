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

namespace Bi_Tat_Uygulama
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_ad, kullanici_soyad, kullanici_sifre, kullanici_no;
            kullanici_ad = textBox1.Text;
            kullanici_soyad = textBox2.Text;
            kullanici_sifre = textBox4.Text;
            kullanici_no = textBox3.Text;

            con = new SqlConnection("Data Source=NAZ\\SQLEXPRESS;Initial Catalog=nazo;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM GİRİS WHERE ad ='" + textBox1.Text + "' AND soyad = '" + textBox2.Text + "'AND telefon = '" + textBox3.Text + "'AND sifre = '" + textBox4.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı.", "Bilgilendirme", MessageBoxButtons.OK);
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş.Lütfen daha tekrar deneyiniz.", "Hata", MessageBoxButtons.OK);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
