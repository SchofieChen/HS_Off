using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NI_HSAS;
using Advantech_HSAS;

namespace Interface_HSAS
{
    public partial class frminterface : DevExpress.XtraEditors.XtraForm
    {
        public frminterface()
        {

            InitializeComponent();
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void advantechtileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                Thread startfftformthread = new Thread(new ThreadStart(Startadvantechform));
                startfftformthread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Ensure Advantech driver be installed on computer & .Net Framework4.5.2");
            }

        }

        public void Startadvantechform()
        {
            try
            {
                Application.Run(new Advantech_HSAS.frmMain());
            }
            catch (Exception error)
            {
                DialogResult dr = MessageBox.Show("Ensure Advantech driver be installed on computer & .Net Framework4.5.2\r\n" + error.Message, "Error", MessageBoxButtons.AbortRetryIgnore);
                switch (dr)
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        Startadvantechform();
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }

        }

        private void frminterface_Load(object sender, EventArgs e)
        {
            this.Text = "Interface HSAS Ver." + Application.ProductVersion;
        }

        private void NItileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                Thread startfftformthread = new Thread(new ThreadStart(StartNIform));
                startfftformthread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Ensure NI driver be installed on computer & .Net Framework4.5.2");
            }

        }

        public void StartNIform()
        {
            try
            {
                Application.Run(new NI_HSAS.frmMain());
            }
            catch (Exception error)
            {
                DialogResult dr = MessageBox.Show("Ensure NI driver be installed on computer & .Net Framework4.5.2\r\n" + error.Message, "Error", MessageBoxButtons.AbortRetryIgnore);

                switch (dr)
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        StartNIform();
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }

        }

    }

}
