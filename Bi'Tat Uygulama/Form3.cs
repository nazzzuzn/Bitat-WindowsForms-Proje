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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=NAZ\SQLEXPRESS;Initial Catalog=nazo;Integrated Security=True");
                baglanti.Open();

                SqlCommand sqlkomut = new SqlCommand("SELECT yiyecek, icecek, tatli FROM siparis", baglanti);
                SqlDataReader sqlDR = sqlkomut.ExecuteReader();

                while (sqlDR.Read())
                {

                    string yiyecek = sqlDR[0].ToString();
                    string icecek = sqlDR[1].ToString();
                    string tatli = sqlDR[2].ToString();

                    richTextBox1.Text = richTextBox1.Text + yiyecek + Environment.NewLine + icecek + Environment.NewLine + tatli + "\n";

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(" SQL Query sırasında hata oluştu ! ");
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex == 0)
            {

                comboBox2.Items.Add("Hamburger");
                comboBox2.Items.Add("Döner");
                comboBox2.Items.Add("Pizza");
                comboBox2.Items.Add("Çiğ Köfte");
                comboBox2.Items.Add("İskender");
                comboBox2.Items.Add("Kebap");
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                comboBox2.Items.Add("Ayran");
                comboBox2.Items.Add("Su");
                comboBox2.Items.Add("Şalgam");
                comboBox2.Items.Add("Kola");
                comboBox2.Items.Add("Gazoz");
            }
            else
            {

                comboBox2.Items.Add("Sütlaç");
                comboBox2.Items.Add("Kazandibi");
                comboBox2.Items.Add("Baklava");
                comboBox2.Items.Add("Künefe");
                comboBox2.Items.Add("Tulumba");
                comboBox2.Items.Add("Güllaç");
            }
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "Hamburger 40TL" + Environment.NewLine +
                    "Döner 30TL" + Environment.NewLine +
                    "Pizza 60TL" + Environment.NewLine +
                    "Çiğ Köfte 25 TL" + Environment.NewLine +
                    "İskender 70TL" + Environment.NewLine +
                    "Kebap 65TL" + Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "Ayran 10TL" + Environment.NewLine +
                    "Su 5TL" + Environment.NewLine +
                    "Şalgam 10TL" + Environment.NewLine +
                    "Kola 20TL" + Environment.NewLine +
                    "Gazoz 15TL" + Environment.NewLine;
            }
            else
            {
                textBox1.Text = "Sütlaç 35TL" + Environment.NewLine +
                    "Kazandibi 40TL" + Environment.NewLine +
                    "Baklava 60TL" + Environment.NewLine +
                    "Künefe 55TL" + Environment.NewLine +
                    "Tulumba 25TL" + Environment.NewLine +
                    "Güllaç 30TL" + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source=NAZPC;Initial Catalog=nazo;Integrated Security=True");
                baglanti.Open();

                SqlCommand sqlkomut = new SqlCommand("SELECT yiyecek, icecek, tatli FROM siparis", baglanti);
                SqlDataReader sqlDR = sqlkomut.ExecuteReader();

                while (sqlDR.Read())
                {

                    string yiyecek = sqlDR[0].ToString();
                    string icecek = sqlDR[1].ToString();
                    string tatli = sqlDR[2].ToString();

                    listBox1.Items.Add(yiyecek);
                    listBox1.Items.Add(icecek);
                    listBox1.Items.Add(tatli);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(" SQL Query sırasında hata oluştu ! ");
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SİPARİŞİNİZ ONAYLANMIŞTIR.", "Bilgilendirme");
            Application.Exit();
        }
    }
}
