using GorselProgramlamaVize.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaVize
{
    public partial class evMusteriEkrani : Form
    {
        public evMusteriEkrani()
        {
            InitializeComponent();
            using (var context = new VodafoneContext())
            {
                var tablo = context.evMusteris.ToList(); 

                dgwMusteri.DataSource = tablo; 
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var dbContext = new VodafoneContext())
            {
                evMusteri m=new evMusteri();
                m.MusteriAd=txtAd.Text;
                m.MusteriSoyad=txtSoyad.Text;
                m.MusteriEvTel=mtxtTel.Text;

                dbContext.evMusteris.Add(m);
                dbContext.SaveChanges();

                // Ekleme başarılı
                MessageBox.Show("Müşteri başarıyla eklendi");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            

            int id =Convert.ToInt32(txtID.Text);
            using (var dbContext = new VodafoneContext())
            {
                var musteri = dbContext.evMusteris.FirstOrDefault(x => x.MusteriID == id);

                if (musteri != null)
                {
                    musteri.MusteriAd = txtAd.Text;
                    musteri.MusteriSoyad = txtSoyad.Text;
                    musteri.MusteriEvTel = mtxtTel.Text;

                    dbContext.SaveChanges();

                    // Güncelleme başarılı
                    MessageBox.Show("Müşteri başarıyla güncellendi.");
                }
                else
                {
                    // Müşteri bulunamadı
                    MessageBox.Show("Güncelleme işlemi için müşteri bulunamadı.");
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtID.Text);
            using (var context = new VodafoneContext())
            {
                var musteri = context.evMusteris.Find(id); // ID'ye göre kaydı bulun

                if (musteri != null)
                {
                    context.evMusteris.Remove(musteri); // Kaydı sil
                    context.SaveChanges(); // Değişiklikleri kaydet
                    Console.WriteLine("Kayıt silindi.");
                }
                else
                {
                    Console.WriteLine("Kayıt bulunamadı.");
                }
            }
        }
    }
}
