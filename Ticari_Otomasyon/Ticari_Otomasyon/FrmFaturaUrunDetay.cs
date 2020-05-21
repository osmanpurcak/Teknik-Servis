using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        // fatura id değerlerini taşımak için public bi id tanımlıyorum
        public string id;
        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            label1.Text = id;
        }
    }
}
