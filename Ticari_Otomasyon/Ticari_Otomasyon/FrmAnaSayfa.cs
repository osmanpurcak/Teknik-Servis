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
using System.Xml;
//haber başlıkları çekmek için

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD having Sum(adet)<=20 order by Sum(Adet)", bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 10 TARIH,SAAT,BASLIK From TBL_NOTLAR order by ID Desc", bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            GridControlFirmaHareket.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            GridControlFihrist.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("http://www.trt.net.tr/rss/gundem.rss");
            while (xmloku.Read())
            {
                //title ları görünce listele
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();

            ajanda();

            FirmaHareketleri();

            fihrist();

            //döviz kurları
            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");

            haberler();
        }
    }
}
