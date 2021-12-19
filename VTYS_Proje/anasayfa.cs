using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYS_Proje
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            depo formac = new depo();
            formac.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            urunler formac = new urunler();
            formac.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           marka formac = new marka();
            formac.Show();
        }

        private void btnseri_Click(object sender, EventArgs e)
        {
            seri formac = new seri();
            formac.Show();

        }

        private void btn_kategori_Click(object sender, EventArgs e)
        {
            kategori formac = new kategori();
            formac.Show();

        }

        private void btn_ithalatci_Click(object sender, EventArgs e)
        {
            ithalatci formac = new ithalatci();
            formac.Show();

        }

        private void btn_kur_Click(object sender, EventArgs e)
        {
            kur formac = new kur();
            formac.Show();
        }

        private void btn_sehir_Click(object sender, EventArgs e)
        {
            sehir formac = new sehir();
            formac.Show();
        }

        private void btn_ulke_Click(object sender, EventArgs e)
        {
            ulke formac = new ulke();
            formac.Show();
        }

        private void btn_person_Click(object sender, EventArgs e)
        {
            personel formac = new personel();
            formac.Show();
        }
    }
}
