using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoEmotionAnalysis
{
    public partial class OptionDialog : Form
    {
        public OptionDialog()
        {
            InitializeComponent();

            //オプションの読み込み
            string APIKEY = "";
            APIKEY = Properties.Settings.Default.emotionAPIKEY;
            txtAPIKEY.Text = APIKEY;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //設定の書き込み
            string APIKEY = txtAPIKEY.Text;
            Properties.Settings.Default.emotionAPIKEY = APIKEY;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
