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
    public partial class AramaKaydi_Ekrani : Form
    {
        public AramaKaydi_Ekrani()
        {
            InitializeComponent();
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var context = new VodafoneContext())
            {
                var arama = new AramaKaydi
                {
                    ArananMusteriAd = txtAd.Text,
                    AramaTarihi = dtAramaTarih.Value,
                    AramaDurum = cmbDurum.Text,
                    ArananTel = mtxtTel.Text
                };
              
           

                context.AramaKaydis.Add(arama);
                context.SaveChanges();
                EkranGuncelle();
            }
        }

        private void AramaKaydi_Ekrani_Load(object sender, EventArgs e)
        {
            cmbDurum.Items.Add("arandı");
            cmbDurum.Items.Add("aranmadı");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtID.Text);
            using (var context = new VodafoneContext())
            {
                var arama = context.AramaKaydis.Find(id); 

                if (arama != null)
                {
                    context.AramaKaydis.Remove(arama); 
                    context.SaveChanges(); 
                    Console.WriteLine("Kayıt silindi.");
                    EkranGuncelle();
                }
                else
                {
                    Console.WriteLine("Kayıt bulunamadı.");
                }
            }
        }

        public void EkranGuncelle()
        {
            using (var context = new VodafoneContext())
            {
                var aramalar = context.AramaKaydis.ToList();

                dgwMusteri.DataSource = aramalar;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtID.Text);
            using (var context = new VodafoneContext())
            {
                var arama = context.AramaKaydis.Find(id); 

                if (arama != null)
                {
                    arama.ArananMusteriAd = txtAd.Text; 
                    arama.AramaTarihi = dtAramaTarih.Value; 
                    arama.AramaDurum = cmbDurum.Text; 
                    arama.ArananTel=mtxtTel.Text;



                    context.SaveChanges(); 
                    Console.WriteLine("Kayıt güncellendi.");
                }
                else
                {
                    Console.WriteLine("Kayıt bulunamadı.");
                }
            }
        }
    }
}
