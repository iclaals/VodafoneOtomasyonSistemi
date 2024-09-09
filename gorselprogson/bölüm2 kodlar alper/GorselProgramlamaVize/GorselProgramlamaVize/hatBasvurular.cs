using GorselProgramlamaVize.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaVize
{
    public partial class hatBasvurular : Form
    {
        public hatBasvurular()
        {
            InitializeComponent();
        }

        CodeFirst.VodafoneContext context = new CodeFirst.VodafoneContext();

        public void BasvuruListele()
        {
            var list=context.hatBasvurulars.ToList();
            dgwMusteri.DataSource= list;
        }

        public void Temizle()
        {
            txtAd.Text = txtSoyad.Text = mtxtTel.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            hatBasvurularr musteri = new hatBasvurularr();
            musteri.MusteriAd = txtAd.Text;
            musteri.MusteriSoyad = txtSoyad.Text;
            musteri.MusteriTel = mtxtTel.Text;
            context.hatBasvurulars.Add(musteri);
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BasvuruListele();
            Temizle();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            BasvuruListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var musteri = context.hatBasvurulars.FirstOrDefault(k => k.MusteriId == id);

            if (musteri != null)
            {
                musteri.MusteriAd = txtAd.Text;
                musteri.MusteriSoyad = txtSoyad.Text;
                musteri.MusteriTel = mtxtTel.Text;
                

                context.SaveChanges();
            }
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BasvuruListele();
            Temizle();
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgwMusteri.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            mtxtTel.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtID.Text);
            var musteri = context.hatBasvurulars.FirstOrDefault(k => k.MusteriId == id);

            if (musteri != null)
            {
                context.hatBasvurulars.Remove(musteri);
                context.SaveChanges();
            }
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BasvuruListele();
            Temizle();

            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void hatBasvurular_Load(object sender, EventArgs e)
        {
            txtID.Enabled= false;
            BasvuruListele();
        }
    }
}
