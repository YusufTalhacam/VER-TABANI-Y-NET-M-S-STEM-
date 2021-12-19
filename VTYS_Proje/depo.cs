using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VTYS_Proje
{
    public partial class depo : Form
    {
        public depo()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=VTYS_PROJE;user ID=postgres; password=postgres ");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ekle_Click_1(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into depo (depoid,ad,sehir) values (@p1,@p2,@p3) ", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Depo Ekleme İşlemi Gerçekleşti");
        }

        private void button1_Click(object sender, EventArgs e) //listeleme
        {
            string sorgu = "select * from depo order by depoid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_guncelle_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update depo set ad=@p2,sehir=@p3 where depoid=@p1  ", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p2", textBox2.Text);
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Depo Güncelleme İşlemi Gerçekleşti");
        }

        private void btn_sil_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM depo where depoid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Depo Silme İşlemi Gerçekleşti");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            string sorgu = "select* from depo where depoid::text like '" + textBox4.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
