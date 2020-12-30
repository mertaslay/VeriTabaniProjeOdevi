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
    public partial class Frmİl : Form
    {
        public Frmİl()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;  Database=proje.; user ID=postgres; password=MERTaslay1907 ");
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnListele1_Click(object sender, EventArgs e)
        {
            string sorgu2 = "Select * from \"İller\" ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void BtnEkle1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into İller (\"ilid\",\"ilAdi\",\"ilPlaka\") values(@p1,@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p1", Txtİlİd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtİlAdi.Text);
            komut2.Parameters.AddWithValue("@p3", TxtİlPlaka.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("iller ekleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete From İller where \"ilid\"=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", Txtİlİd.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İl silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

        }

        private void BtnGüncelle1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update İller set \"ilAdi\"=@p2,\"ilPlaka\"=@p3 where ilid=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", Txtİlİd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtİlAdi.Text);
            komut4.Parameters.AddWithValue("@p3", TxtİlPlaka.Text);
            komut4.ExecuteNonQuery();
            MessageBox.Show("İl güncelleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void BtnAra1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataSet dt = new DataSet();
            string sorgu = "select*from İller where ilid like '%"+ Txtİlİd.Text+ "%' ";
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sorgu, baglanti);
            adap.Fill(dt);
            this.dataGridView2.DataSource = dt.Tables[0];
            MessageBox.Show("İl arama işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }
    }
}
