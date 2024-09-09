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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btnHatBasvurular_Click(object sender, EventArgs e)
        {
            hatBasvurular hatBasvurular = new hatBasvurular();
            hatBasvurular.Show();
            this.Hide();
        }

        private void btnHatAranacaklar_Click(object sender, EventArgs e)
        {
            hatAranacaklar hatAranacaklar = new hatAranacaklar();
            hatAranacaklar.Show();
            this.Hide();
        }

        private void btnHatFaturaliFaturasiz_Click(object sender, EventArgs e)
        {
            hatFaturaliFaturasiz hatFaturaliFaturasiz = new hatFaturaliFaturasiz();
            hatFaturaliFaturasiz.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            evMusteriEkrani ev=new evMusteriEkrani();
            this.Hide();
            ev.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
