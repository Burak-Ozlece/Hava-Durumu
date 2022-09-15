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

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static string gidenbilgi = "";
        public Form1()
        {
            InitializeComponent();
        }
        

        public void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Şehir Bilgisi";
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source = 192.168.47.138; Initial Catalog= City;User ID = SA;password = Password1; ");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Sehirler", baglanti);
                SqlDataReader reader = komut.ExecuteReader();
                comboBox1.Items.Add("Şehir Seç");
                comboBox1.Text = comboBox1.Items[0].ToString();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["SehirAd"].ToString());
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Şehir Seç")
            {
                gidenbilgi=comboBox1.Text;
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }

        
    }
}
