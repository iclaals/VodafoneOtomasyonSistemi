using GorselProgramlamaVize.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        
        basvuruContext context = new basvuruContext();

        public void BasvuruListele()
        {
            dgwMusteri.DataSource=context.hatBasvurularsss.ToList();
        }

        public void Temizle()
        {
            txtAd.Text = txtSoyad.Text = mtxtTel.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            hatBasvurularr musteriekle = new hatBasvurularr();
            musteriekle.MusteriAd = txtAd.Text;
            musteriekle.MusteriSoyad = txtSoyad.Text;
            musteriekle.MusteriTel = mtxtTel.Text;
            context.hatBasvurularsss.Add(musteriekle);
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
            hatBasvurularr musteriguncelle = new hatBasvurularr();
            musteriguncelle.MusteriAd = txtAd.Text;
            musteriguncelle.MusteriSoyad = txtSoyad.Text;
            musteriguncelle.MusteriTel= mtxtTel.Text;
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BasvuruListele();
            Temizle();
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            mtxtTel.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            hatBasvurularr musterisil = new hatBasvurularr();
            context.hatBasvurularsss.Remove(musterisil);
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
            //using (basvuruContext context = new basvuruContext())
            //{
            //    context.Database.Create();
            //}
            //BasvuruListele();
        }
    }
}
