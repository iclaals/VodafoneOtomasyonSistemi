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

namespace GorselProgramlamaVize
{
    public partial class hatAranacaklar : Form
    {
        string connect = "Data Source=.\\SQL;Initial Catalog=Vodafone;Integrated Security=True";
        public hatAranacaklar()
        {
            InitializeComponent();
            AranacaklarListele();
        }
        
        

        public void AranacaklarListele()
        {
           

            string query = "SELECT MusteriID, MusteriAd, MusteriSoyad, MusteriTel FROM hatAranacaklar";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                dgwMusteri.DataSource = dataTable;
            }
        }

        public void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mtxtTel.Clear();
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
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "INSERT INTO Kullanicilar (KullaniciAdi, KullaniciSoyad, KullaniciTel) VALUES (@Ad, @Soyad, @Tel)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", txtAd.Text);
                command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                command.Parameters.AddWithValue("@Tel", mtxtTel.Text);

                connection.Open();
                
            }
            AranacaklarListele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);


            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "UPDATE hatAranacaklar SET MusteriAd = @Ad, MusteriSoyad = @Soyad, MusteriTel = @Tel WHERE MusteriID = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", txtAd.Text);
                command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                command.Parameters.AddWithValue("@Tel", mtxtTel.Text);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    // Güncelleme başarılı
                    MessageBox.Show("Veriler güncellendi.");
                    AranacaklarListele();
                }
                else
                {
                    // Güncelleme başarısız
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.");
                }
            }
        }
               
            

            private void btnSil_Click(object sender, EventArgs e)
            {
            


        }

            private void dgwMusteri_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            

            private void hatAranacaklar_Load(object sender, EventArgs e)
            {
            AranacaklarListele();
             }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgwMusteri.Rows.Count)
            {
                DataGridViewRow row = dgwMusteri.Rows[e.RowIndex];

                // Verileri TextBox'lara aktarma işlemi
                txtID.Text = row.Cells["MusteriId"].Value.ToString();
                txtAd.Text = row.Cells["MusteriAd"].Value.ToString();
                txtSoyad.Text = row.Cells["MusteriSoyad"].Value.ToString();
                mtxtTel.Text = row.Cells["MusteriTel"].Value.ToString();

                // İşlemleri gerçekleştirin
                // ...
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string query = "DELETE FROM hatAranacaklar WHERE MusteriID = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    // Silme başarılı
                    MessageBox.Show("Veri başarıyla silindi.");
                    AranacaklarListele();
                }
                else
                {
                    // Silme başarısız
                    MessageBox.Show("Veri silinirken bir hata oluştu.");
                }
            }
        }
    }
    }

