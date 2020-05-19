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

namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            // "SQL SERVERDAKİ İLİŞKİLENDİRMEYİ BURAYA TANIMLADIM DAHA KISA OLSUN DİYE"
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbil.Text);
            komut.Parameters.AddWithValue("@p3", TxtSube.Text);
            komut.Parameters.AddWithValue("@p4", TxtIban.Text);
            komut.Parameters.AddWithValue("@p5", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p8", MskTarih.Text);
            komut.Parameters.AddWithValue("@p9", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p10", TxtFirma.Text);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
