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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;  Database=proje.; user ID=postgres; password=MERTaslay1907 ");
        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "Select*from ilceler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into ilceler(\"ilceİd\",\"ilceAdi\",\"ilİd\") values(@p1,@p2,@p3)", baglanti);
            komut1.Parameters.AddWithValue("@p1", Txtİlçeİd.Text);
            komut1.Parameters.AddWithValue("@p2", TxtİlçeAdi.Text);
            komut1.Parameters.AddWithValue("@p3", textBox1.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ilceler ekleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete From ilceler where \"ilceİd\"=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", Txtİlçeİd.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İlçe silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update ilceler set \"ilceAdi\"=@p2 where \"ilceİd\"=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p2", TxtİlçeAdi.Text);
            komut4.Parameters.AddWithValue("@p1", Txtİlçeİd.Text);
            komut4.ExecuteNonQuery();
            MessageBox.Show("İlçe güncelleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataSet dt = new DataSet();
            string sorgu = "select*from ilceler where \"ilceİd\" like '%" + Txtİlçeİd.Text + "%' ";
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sorgu, baglanti);
            adap.Fill(dt);
            this.dataGridView1.DataSource = dt.Tables[0];
            MessageBox.Show("İlçe arama işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }
    }
}
