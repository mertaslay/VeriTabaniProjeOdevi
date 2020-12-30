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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;  Database=proje.; user ID=postgres; password=MERTaslay1907 ");
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void BtnListele2_Click(object sender, EventArgs e)
        {
            string sorgu1 = "Select*from hastalar ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu1, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into hastalar (\"hastaİd\",ad,soyadı,\"sicilNo\",adres,\"tcKimlikNo\",\"cepTel\",cinsiyet,\"medeniHali\",\"doğumTarihi\",meslek,\"öncekiSoyadı\",\"vergiNo\",\"kayıtTarihi\",\"kayıtlıİlİd\",\"doğumYeriİd\",\"hastaneİd\") values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtHastaİd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtAdı.Text);
            komut2.Parameters.AddWithValue("@p3", TxtSoyadı.Text);
            komut2.Parameters.AddWithValue("@p4", textBox1.Text);
            komut2.Parameters.AddWithValue("@p5", textBox2.Text);
            komut2.Parameters.AddWithValue("@p6", textBox4.Text);
            komut2.Parameters.AddWithValue("@p7", textBox3.Text);
            komut2.Parameters.AddWithValue("@p8", textBox6.Text);
            komut2.Parameters.AddWithValue("@p9", textBox7.Text);
            komut2.Parameters.AddWithValue("@p10", dateTimePicker1.Value);
            komut2.Parameters.AddWithValue("@p11", textBox8.Text);
            komut2.Parameters.AddWithValue("@p12", textBox9.Text);
            komut2.Parameters.AddWithValue("@p13", textBox10.Text);
            komut2.Parameters.AddWithValue("@p14", dateTimePicker2.Value);
            komut2.Parameters.AddWithValue("@p15", textBox12.Text);
            komut2.Parameters.AddWithValue("@p16", textBox13.Text);
            komut2.Parameters.AddWithValue("@p17", textBox14.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("hasta ekleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Delete From hastalar where \"hastaİd\"=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtHastaİd.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hasta silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void BtnGüncelle2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update hastalar set \"adres\"=@p5,\"cepTel\"=@p7,\"medeniHali\"=@p9 where \"hastaİd\"=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtHastaİd.Text);
            komut4.Parameters.AddWithValue("@p5", textBox2.Text);
            komut4.Parameters.AddWithValue("@p7", textBox3.Text);
            komut4.Parameters.AddWithValue("@p9", textBox7.Text);
            komut4.ExecuteNonQuery();
            MessageBox.Show("Hasta güncelleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataSet dt = new DataSet();
            string sorgu = "select*from hastalar where \"hastaİd\" like '%" + TxtHastaİd.Text + "%' ";
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sorgu, baglanti);
            adap.Fill(dt);
            this.dataGridView1.DataSource = dt.Tables[0];
            MessageBox.Show("Hasta arama işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }
    }
}
