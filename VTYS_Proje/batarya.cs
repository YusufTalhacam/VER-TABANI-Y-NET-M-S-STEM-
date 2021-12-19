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
    public partial class batarya : Form
    {
        public batarya()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=VTYS_PROJE;user ID=postgres; password=postgres ");
        private void batarya_Load(object sender, EventArgs e)
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO urunler(urunid,adi,marka,seri,kategori,ithalatci,alisfiyati,depo,personel,parabirimi,stokadedi) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11); INSERT INTO batarya(urunid,mahdegeri) VALUES(@p13,@p12)",  baglanti);
           
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(textBox9.Text));
            komut1.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut1.Parameters.AddWithValue("@p9", int.Parse(textBox10.Text));
            komut1.Parameters.AddWithValue("@p10",int.Parse(textBox7.Text));
            komut1.Parameters.AddWithValue("@p11",int.Parse(textBox11.Text));
            komut1.Parameters.AddWithValue("@p13", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p12", int.Parse(textBox13.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Batarya Ekleme İşlemi Gerçekleşti");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT batarya.urunid, batarya.mahdegeri ,adi,marka,seri,kategori,ithalatci,alisfiyati,satisfiyati(alisfiyati) ,depo,personel,parabirimi,stokadedi FROM urunler INNER JOIN batarya ON urunler.urunid =batarya.urunid ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("UPDATE  urunler set adi=@p2,marka=@p3,seri=@p4,kategori=@p5,ithalatci=@p6,alisfiyati=@p7,depo=@p8,personel=@p9,parabirimi=@p10,stokadedi=@p11 where  urunid=@p1 ; update batarya set mahdegeri=@p12 where urunid=@p13;", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(textBox9.Text));
            komut1.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut1.Parameters.AddWithValue("@p9", int.Parse(textBox10.Text));
            komut1.Parameters.AddWithValue("@p10", int.Parse(textBox7.Text));
            komut1.Parameters.AddWithValue("@p11", int.Parse(textBox11.Text));
            komut1.Parameters.AddWithValue("@p13", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p12", int.Parse(textBox13.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Batarya Güncelleme İşlemi Gerçekleşti");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM urunler where urunid=@p1; DELETE FROM batarya where urunid=@p1; ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Batarya Silme İşlemi Gerçekleşti");
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ara_Click(object sender, EventArgs e)
        {                    }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            string sorgu= "SELECT batarya.urunid, batarya.mahdegeri, adi, marka, seri, kategori, ithalatci, alisfiyati, satisfiyati(alisfiyati), depo, personel, parabirimi, stokadedi FROM urunler INNER JOIN batarya ON urunler.urunid = batarya.urunid where batarya.urunid::text like '"+ textBox14.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
    }
}
