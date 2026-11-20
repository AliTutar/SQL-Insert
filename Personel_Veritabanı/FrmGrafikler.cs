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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-A8VTLLB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");

        //Grafik 1 
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutg1 = new SqlCommand("Select PerŞehir,Count(*) From Tbl_Personell Group By PerŞehir", bağlantı);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            bağlantı.Close();

            //Grafik 2 
            bağlantı.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek,Avg(PerMaaş) From Tbl_Personell group by PerMeslek", bağlantı);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek Maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            bağlantı.Close();








        }
    }
    }

