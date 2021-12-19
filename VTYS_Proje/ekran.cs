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
    public partial class ekran : Form
    {
        public ekran()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=VTYS_PROJE;user ID=postgres; password=postgres ");
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT ekran.urunid, ekran.inc ,adi,marka,seri,kategori,ithalatci,alisfiyati,satisfiyati(alisfiyati),depo,personel,parabirimi,stokadedi FROM urunler INNER JOIN ekran ON urunler.urunid =ekran.urunid ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("INSERT INTO urunler(urunid,adi,marka,seri,kategori,ithalatci,alisfiyati,depo,personel,parabirimi,stokadedi) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11); INSERT INTO ekran(urunid,inc) VALUES(@p13,@p12)", baglanti);

            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(textBox9.Text));
            komut1.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut1.Parameters.AddWithValue("@p9", int.Parse(textBox10.Text));
            komut1.Parameters.AddWithValue("@p10", int.Parse(textBox7.Text));
            komut1.Parameters.AddWithValue("@p11", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p13", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p12", double.Parse(textBox11.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekran Ekleme İşlemi Gerçekleşti");

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("UPDATE  urunler set adi=@p2,marka=@p3,seri=@p4,kategori=@p5,ithalatci=@p6,alisfiyati=@p7,depo=@p8,personel=@p9,parabirimi=@p10,stokadedi=@p11 where  urunid=@p1 ; update ekran set inc=@p12 where urunid=@p13;", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(textBox9.Text));
            komut1.Parameters.AddWithValue("@p8", int.Parse(textBox8.Text));
            komut1.Parameters.AddWithValue("@p9", int.Parse(textBox10.Text));
            komut1.Parameters.AddWithValue("@p10", int.Parse(textBox7.Text));
            komut1.Parameters.AddWithValue("@p11", int.Parse(textBox12.Text));
            komut1.Parameters.AddWithValue("@p13", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p12", double.Parse(textBox11.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekran Güncelleme İşlemi Gerçekleşti");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM urunler where urunid=@p1; DELETE FROM ekran where urunid=@p1; ", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekran Silme İşlemi Gerçekleşti");

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            string sorgu = "SELECT ekran.urunid, ekran.inc ,adi,marka,seri,kategori,ithalatci,alisfiyati,satisfiyati(alisfiyati),depo,personel,parabirimi,stokadedi FROM urunler INNER JOIN ekran ON urunler.urunid =ekran.urunid where ekran.urunid::text like '" + textBox13.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
