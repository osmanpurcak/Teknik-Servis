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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.AliceBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.White;
        }

        // admin giriş paneli
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where KullaniciAd=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fr = new FrmAnaModul();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kulanıcı Adı ya da Şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
