using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            string connection = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&mode=xml&appid=02d37b9641988c9273a91b3f657114fb&units=metric&lang=tr",Form1.gidenbilgi.ToString());
            XDocument hava = XDocument.Load(connection);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label1.Text = sicaklik.ToString();
            label3.Text = Form1.gidenbilgi.ToString().ToUpper()+",TR";
            var rüzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value.ToString();
            label5.Text = rüzgar + " m/s";
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value.ToString();
            label6.Text = durum.ToUpper();
            var hissedilen = hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value.ToString();
            label9.Text = hissedilen;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value.ToString();
            label12.Text = nem + " %";
            var icon = hava.Descendants("weather").ElementAt(0).Attribute("number").Value.ToString();
            DateTime dt = new DateTime(2022, 09, 15, 18, 00, 00);
            this.Text = "Hava durumu";
            switch (icon)
            {
                case "200":
                case "201":
                case "202":
                case "210":
                case "211":
                case "212":
                case "221":
                case "230":
                case "231":
                case "232":  
                    pictureBox1.ImageLocation= @"C:\\Users\\Burak\\Desktop\\icon\\gündüz\bulutluşimşekli.png";
                    break;
                case "300":
                case "301":
                case "302":
                case "310":
                case "311":
                case "312":
                case "313":
                case "314":
                case "321":
                case "520":
                case "521":
                case "522":
                case "531":
                    pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\karabulut yağmurlu.png";
                    break;
                case "800":
                    if (dt > DateTime.Now)
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\güneş.png";
                    }
                    else
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gece\güneş.png";
                    }
                    break;
                case "803":
                    pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\karabulut.png";
                    break;
                case "500":
                case "501":
                case "502":
                case "503":
                case "504":
                    if (dt > DateTime.Now)
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\bulutlu yağmurlu.png";
                    }
                    else
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gece\bulutlu yağmurlu.png";
                    }
                    break;
                case "600":
                case "601":
                case "602":
                case "611":
                case "612":
                case "613":
                case "615":
                case "616":
                case "620":
                case "621":
                case "622":
                    pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\karlı.png";
                    break;
                case "701":
                case "711":
                case "721":
                case "731":
                case "741":
                case "751":
                case "761":
                case "762":
                case "771":
                case "781":
                    pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\sisli.png";
                    break;
                case "801":
                    if (dt > DateTime.Now)
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gündüz\güneşli bulutlu.png";
                    }
                    else
                    {
                        pictureBox1.ImageLocation = @"C:\Users\Burak\Desktop\icon\gece\güneşli bulutlu.png";
                    }
                    break;
            }
        }
    }
}
