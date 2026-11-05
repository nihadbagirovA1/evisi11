using System;
using System.Windows.Forms;

namespace BombaPisik
{
    public partial class Form1 : Form
    {
        PictureBox[] xanalar;
        Random rnd = new Random();
        int bombaYeri;
        int xal;
        bool bitdi;

        public Form1()
        {
            InitializeComponent();

            xanalar = new[] { pictureBox1, pictureBox2, pictureBox3,
                              pictureBox4, pictureBox5, pictureBox6 };

            foreach (var p in xanalar)
            {
                p.Click += Xana_Click;
            }

            YeniOyun();
        }

        void YeniOyun()
        {
            xal = 0;
            bitdi = false;
            bombaYeri = rnd.Next(6);   // 0-5 arası random

            foreach (var p in xanalar)
            {
                p.Image = Properties.Resources.sual;
                p.Enabled = true;
            }

            lblXal.Text = "0";
            lblMesaj.Text = "";
        }

        void Xana_Click(object sender, EventArgs e)
        {
            if (bitdi) return;

            var p = (PictureBox)sender;
            int i = Array.IndexOf(xanalar, p);

            if (i == bombaYeri)
            {
                p.Image = Properties.Resources.bomba;
                bitdi = true;
                lblMesaj.ForeColor = System.Drawing.Color.DarkRed;
                lblMesaj.Text = "Oyun bitdi";
            }
            else
            {
                p.Image = Properties.Resources.cat;
                p.Enabled = false;   // eyni pişiyə təkrar xal verməsin
                xal++;
                lblXal.Text = xal.ToString();

                if (xal == 5)
                {
                    bitdi = true;
                    lblMesaj.ForeColor = System.Drawing.Color.DarkGreen;
                    lblMesaj.Text = "Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın";
                }
            }
        }

        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }

        private void btnCixis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
