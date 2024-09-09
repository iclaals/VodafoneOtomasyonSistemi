using GorselProgramlamaVize.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaVize
{
    public partial class hatFaturaliFaturasiz : Form
    {
        public hatFaturaliFaturasiz()
        {
            InitializeComponent();
        }

        VodafoneContext context = new VodafoneContext();

        public void FaturaliFaturasizListe()
        {
            using (var dbContext = new VodafoneContext())
            {
                var veriler = dbContext.hatFaturaliFaturasizzs.ToList();

                dgwMusteri.DataSource = veriler;
            }
        }

        public void Temizle()
        {
            txtAd.Text = txtSoyad.Text = cmbFaturatur.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            hatFaturaliFaturasizz musteriekle = new hatFaturaliFaturasizz();
            musteriekle.MusteriAd = txtAd.Text;
            musteriekle.MusteriSoyad = txtSoyad.Text;
            musteriekle.MusteriFaturaliFaturasiz = cmbFaturatur.Text;
            context.hatFaturaliFaturasizzs.Add(musteriekle);
            context.SaveChanges();
            

            MessageBox.Show("Müşteri bilgileri kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaliFaturasizListe();
            Temizle();
        }

        private void hatFaturaliFaturasiz_Load(object sender, EventArgs e)
        {
            FaturaliFaturasizListe();
           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            FaturaliFaturasizListe();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            using (var dbContext = new VodafoneContext())
            {
                var musteri = dbContext.hatFaturaliFaturasizzs.FirstOrDefault(x => x.MusteriId == id);

                if (musteri != null)
                {
                    // Veriyi güncelleme
                    musteri.MusteriAd = txtAd.Text;
                    musteri.MusteriSoyad = txtSoyad.Text;
                    musteri.MusteriFaturaliFaturasiz = cmbFaturatur.Text;
                    // Diğer özellikleri güncelleme

                    dbContext.SaveChanges();

                    // Güncelleme başarılı
                    MessageBox.Show("Veri başarıyla güncellendi.");
                }
                else
                {
                    // Veri bulunamadı
                    MessageBox.Show("Güncelleme işlemi için veri bulunamadı.");
                }
            }
           
           
            
            FaturaliFaturasizListe();
            Temizle();
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgwMusteri.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbFaturatur.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            using (var dbContext = new VodafoneContext())
            {
                var d = dbContext.hatFaturaliFaturasizzs.FirstOrDefault(x => x.MusteriId == id);

                if (d != null)
                {



                    // Silme başarılı
                    dbContext.hatFaturaliFaturasizzs.Remove(d);
                    dbContext.SaveChanges();
                    FaturaliFaturasizListe();
                    Temizle();
                    MessageBox.Show("Veri başarıyla silindi.");
                }
                else
                {
                    // Veri bulunamadı
                    MessageBox.Show("Silme işlemi için veri bulunamadı.");
                }
            }
            
           
          
        
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
