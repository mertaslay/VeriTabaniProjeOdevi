using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıUygulama
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;  Database=proje.; user ID=postgres; password=MERTaslay1907 ");
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnListele1_Click(object sender, EventArgs e)
        {
            string sorgu1 = "Select*from hastaneler ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu1, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hastaneler(\"hastaneİd\",\"hastaneAdi\",telefon,\"ilceİd\") values(@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", TxtHastaneİd.Text);
            komut1.Parameters.AddWithValue("@p2", TxtHastaneAdı.Text);
            komut1.Parameters.AddWithValue("@p3", TxtTelefon.Text);
            komut1.Parameters.AddWithValue("@p4", textBox1.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("hastane ekleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete From hastaneler where \"hastaneİd\"=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtHastaneİd.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hastane silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void BtnGüncelle2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update hastaneler set \"hastaneAdi\"=@p2,\"telefon\"=@p3 where \"hastaneİd\"=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtHastaneİd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtHastaneAdı.Text);
            komut4.Parameters.AddWithValue("@p3", TxtTelefon.Text);
            komut4.ExecuteNonQuery();
            MessageBox.Show("Hastane güncelleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataSet dt = new DataSet();
            string sorgu = "select*from hastaneler where \"hastaneİd\" like '%" + TxtHastaneİd.Text + "%' ";
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sorgu, baglanti);
            adap.Fill(dt);
            this.dataGridView1.DataSource = dt.Tables[0];
            MessageBox.Show("Hastane arama işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }
    }
}
