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

        FaturaliFaturasizContext context = new FaturaliFaturasizContext();

        public void FaturaliFaturasizListe()
        {
            dgwMusteri.DataSource = context.HatFaturasizz.ToList();
        }

        public void Temizle()
        {
            txtAd.Text = txtSoyad.Text = comboBox1.Text = string.Empty;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            hatFaturaliFaturasizz musteriekle = new hatFaturaliFaturasizz();
            musteriekle.MusteriAd = txtAd.Text;
            musteriekle.MusteriSoyad = txtSoyad.Text;
            musteriekle.MusteriFaturaliFaturasiz = comboBox1.Text;
            context.HatFaturasizz.Add(musteriekle);
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaliFaturasizListe();
            Temizle();
        }

        private void hatFaturaliFaturasiz_Load(object sender, EventArgs e)
        {
            //using (FaturaliFaturasizContext context = new FaturaliFaturasizContext())
            //{
            //    context.Database.Create();
            //}
            //FaturaliFaturasizListe();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            FaturaliFaturasizListe();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            hatFaturaliFaturasizz musteriguncelle = new hatFaturaliFaturasizz();
            musteriguncelle.MusteriAd = txtAd.Text;
            musteriguncelle.MusteriSoyad = txtSoyad.Text;
            musteriguncelle.MusteriFaturaliFaturasiz = comboBox1.Text;
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaliFaturasizListe();
            Temizle();
        }

        private void dgwMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dgwMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dgwMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            hatFaturaliFaturasizz musterisil = new hatFaturaliFaturasizz();
            context.HatFaturasizz.Remove(musterisil);
            context.SaveChanges();
            MessageBox.Show("Müşteri bilgileri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaliFaturasizListe();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
