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
            //Toplam Personel Sayısı//
            bağlantı.Open();
            SqlCommand  komut1 = new SqlCommand("Select Count(*) From Tbl_Personell", bağlantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            bağlantı.Close();
            // Evli Perosnel Sayısı//
            bağlantı.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personell where Perdurum=1", bağlantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            bağlantı.Close();
            //Bekar Personel Sayisi//
            bağlantı.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_personell where PerDurum=0", bağlantı);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }
            bağlantı.Close();
            // Şehir Sayısı//
            bağlantı.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerŞehir))From Tbl_Personell", bağlantı);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblŞehirSayısı.Text = dr4[0].ToString();
            }
            bağlantı.Close();
            //Toplam Maaş//
            bağlantı.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaaş)From Tbl_Personell", bağlantı);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaaş.Text = dr5[0].ToString();
            }
            bağlantı.Close();
            //Ortalama Maaş//
            bağlantı.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaaş From tbl_Personell", bağlantı);
            SqlDataReader dr6 = komut5.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaaş.Text = dr6[0].ToString();
            }
            bağlantı.Close();
        }
    }
}
