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
            // "SQL SERVERDAKİ İLİŞKİLENDİRMEYİ BURAYA TANIMLADIM DAHA KISA OLSUN DİYE" //
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From Tbl_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            // "Bizim göreceğimiz firma ad alanı" //
            lookUpEdit1.Properties.DataSource = dt;
            // "dt'den gelen değer" //
        }

        void temizle()
        {
            TxtBankaAd.Text = "";
            TxtHesapNo.Text = "";
            TxtHesapTuru.Text = "";
            TxtIban.Text = "";
            Txtid.Text = "";
            Cmbil.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";
            lookUpEdit1.Text = "";
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();

            firmalistesi();

            temizle();
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
            komut.Parameters.AddWithValue("@p10", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtBankaAd.Text = dr["BANKAADI"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                TxtIban.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_bankalar where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka Bilgisi Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_bankalar set BANKAADI=@P1,IL=@P2,SUBE=@P3,IBAN=@P4,HESAPNO=@P5,YETKILI=@P6,TELEFON=@P7,TARIH=@P8,HESAPTURU=@P9,FIRMAID=@P10 where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbil.Text);
            komut.Parameters.AddWithValue("@p3", TxtSube.Text);
            komut.Parameters.AddWithValue("@p4", TxtIban.Text);
            komut.Parameters.AddWithValue("@p5", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@p7", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p8", MskTarih.Text);
            komut.Parameters.AddWithValue("@p9", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p10", lookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@p11", Txtid.Text);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
