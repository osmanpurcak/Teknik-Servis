﻿/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2019-2020 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........: 2.Ödev
** ÖĞRENCİ ADI............: Osman PURÇAK
** ÖĞRENCİ NUMARASI.......: b191200373
** DERSİN ALINDIĞI GRUP...: A 
****************************************************************************/
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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Notlar", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource=dt;
        }

        void temizle()
        {
            Txtid.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtBaslik.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            RchDetay.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();

            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", textEdit3.Text);
            komut.Parameters.AddWithValue("@p6", textEdit2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtBaslik.Text = dr["BASLIK"].ToString();
                textEdit2.Text = dr["OLUSTURAN"].ToString();
                textEdit3.Text = dr["HITAP"].ToString();
                RchDetay.Text = dr["DETAY"].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Notlar Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_NOTLAR set TARIH=@P1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", textEdit2.Text);
            komut.Parameters.AddWithValue("@p6", textEdit3.Text);
            komut.Parameters.AddWithValue("@p7", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Sisteme Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
            }
            fr.Show();
        }
    }
}
