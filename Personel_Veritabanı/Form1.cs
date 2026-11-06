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
using System.Data.SqlClient;

namespace Personel_Veritabanı
{
    public partial class Form1 : Form
    {
        // EKLEMEN GEREKEN KISIM BURASI:
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-A8VTLLB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");
       

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet2.Tbl_Personell' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonellTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personell);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonellTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personell);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personell(PerAD,PerSoyad,PerŞehir,PerMaaş) values(@p1,@p2,@p3,@p4)", bağlantı);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbŞehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaaş.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");
            bağlantı.Close();
        }
    }
}