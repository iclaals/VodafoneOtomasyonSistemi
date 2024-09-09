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

namespace GorselProgramlamaVize
{
    public partial class AdminGirisi : Form
    {
        public AdminGirisi()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.\\SQL;Initial Catalog=Vodafone;Integrated Security=True");

        public void Temizle()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlGiris = new SqlCommand("Select *from Users Where Username=@Username and UserPassword=@UserPassword", con);
            sqlGiris.Parameters.AddWithValue("@UserName", txtUsername.Text);
            sqlGiris.Parameters.AddWithValue("@UserPassword", txtPassword.Text);

            SqlDataReader dataReaderLogin = sqlGiris.ExecuteReader();
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (dataReaderLogin.Read())
                {
                    MessageBox.Show("Vodafone Sistemine Hoş Geldiniz");
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen kullanıcı adınızı veya şifrenizi kontrol edin", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
