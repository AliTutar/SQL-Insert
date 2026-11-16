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

namespace Personel_Veritabanı
{
    public partial class Frmistatislik: Form
    {
        public Frmistatislik()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-A8VTLLB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");

        private void Frmistatislik_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personell", bağlantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1 [0].ToString();
            }
            bağlantı.Close();






        }
    }
}
