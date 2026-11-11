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
       

        void temizle()
        {
            Txtİd.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text=  "";
            TxtMeslek.Text = "";
            MskMaaş.Text = "";
            CmbŞehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtAd.Focus();
        }



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
            SqlCommand komut = new SqlCommand("insert into Tbl_Personell(PerAD,PerSoyad,PerŞehir,PerMaaş,PerMeslek,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)", bağlantı);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbŞehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaaş.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Eklendi");
            bağlantı.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbŞehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaaş.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand kişisil = new SqlCommand("Delete From Tbl_Personell Where Perid=@k1", bağlantı);
            kişisil.Parameters.AddWithValue("@k1", Txtİd.Text);
            kişisil.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("Kayit Silindi");


        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand Komutguncelle = new SqlCommand("Update Tbl_Personell Set Perad=@a1,PerSoyad=@a2,PerŞehir=@a3,PerMaaş=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", bağlantı);
            Komutguncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            Komutguncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            Komutguncelle.Parameters.AddWithValue("@a3", CmbŞehir.Text);
            Komutguncelle.Parameters.AddWithValue("@a4", MskMaaş.Text);
            Komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            Komutguncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            Komutguncelle.Parameters.AddWithValue("@a7", Txtİd.Text);
            Komutguncelle.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");
        }
    }
}