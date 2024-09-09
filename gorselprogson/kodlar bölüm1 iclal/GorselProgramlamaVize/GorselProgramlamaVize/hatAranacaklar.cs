using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GorselProgramlamaVize.CodeFirst;
using System.Runtime.Remoting.Contexts;

namespace GorselProgramlamaVize
{
    public partial class hatAranacaklar : Form
    {
        public hatAranacaklar()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-2163TII\\MSSQLSERVER01;Initial Catalog=Vodafone;Integrated Security=True");

        public void AranacaklarListele()
        {
            baglan.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from hatAranacaklar", baglan);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgwMusteri.DataSource = dataTable;
            baglan.Close();
        }

        public void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mtxtTel.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            AranacaklarListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into hatAranacaklar(MusteriAd, MusteriSoyad, MusteriTel) values(@MusteriAd,@MusteriSoyad,@MusteriTel)", baglan);
            ekle.Parameters.AddWithValue("@MusteriAd", txtAd.Text);
            ekle.Parameters.AddWithValue("@MusteriSoyad", txtSoyad.Text);
            ekle.Parameters.AddWithValue("@MusteriTel", mtxtTel.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Çalışan kaydı yapılmıştır", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
            AranacaklarListele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update hatAranacaklar set MusteriAd=@MusteriAd, MusteriSoyad=@MusteriSoyad, MusteriTel=@MusteriTel", baglan);
            guncelle.Parameters.AddWithValue("@MusteriAd", txtAd.Text);
            guncelle.Parameters.AddWithValue("@MusteriSoyad", txtSoyad.Text);
            guncelle.Parameters.AddWithValue("@MusteriTel", mtxtTel.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi tamamlanmıştır", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
            AranacaklarListele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from hatAranacaklar where MusteriAd=@MusteriAd, MusteriSoyad=@MusteriSoyad, MusteriTel=@MusteriTel", baglan);
            sil.Parameters.AddWithValue("@MusteriAd", txtAd.Text);
            sil.Parameters.AddWithValue("@MusteriSoyad", txtSoyad.Text);
            sil.Parameters.AddWithValue("@MusteriTel", mtxtTel.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi tamamlanmıştır", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
            AranacaklarListele();
            Temizle();
        }

        private void dgwMusteri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            mtxtTel.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void hatAranacaklar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
