using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace VTYS_Proje
{
    public partial class ithalatci : Form
    {
        public ithalatci()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=VTYS_PROJE;user ID=postgres; password=postgres ");

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ithalatci_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into ithalatci (ithalatciid,ad,telefon,adress,sehir,ulke) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", textBox2.Text);
            komut1.Parameters.AddWithValue("@p4", textBox5.Text);
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İthalatçı Ekleme İşlemi Gerçekleşti");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from ithalatci order by ithalatciid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            string sorgu = " select * from ithalatci where ithalatciid::text like '" + textBox7.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
