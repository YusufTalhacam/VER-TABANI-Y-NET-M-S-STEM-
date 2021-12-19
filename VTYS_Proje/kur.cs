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
    public partial class kur : Form
    {
        public kur()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=VTYS_PROJE;user ID=postgres; password=postgres ");

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into kur (kurid,ad,kisaltmasi,simgesi,degeri) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", textBox2.Text);
            komut1.Parameters.AddWithValue("@p4", textBox5.Text);
            komut1.Parameters.AddWithValue("@p5", double.Parse(textBox4.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kur Ekleme İşlemi Gerçekleşti");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update kur set ad=@p2,kisaltmasi=@p3,simgesi=@p4,degeri=@p5 where kurid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", textBox2.Text);
            komut3.Parameters.AddWithValue("@p4", textBox5.Text);
            komut3.Parameters.AddWithValue("@p5", double.Parse(textBox4.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kur Güncelleme İşlemi Gerçekleşti");

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM kur where kurid=@p1 ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kur Silme İşlemi Gerçekleşti");

        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kur order by kurid ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            string sorgu = "select * from kur where kurid::text like '" + textBox7.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string sorgu = "select dolartl('"+textBox6.Text+"'"+")";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }
    }
}
