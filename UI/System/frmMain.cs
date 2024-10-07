using System;
using System.Windows.Forms;
using FamilyApp.Repositories.Registry;
using Janus.Windows.GridEX;
using System.Drawing;
using FamilyApp.UI.Tools;
using FamilyApp.UI.Documents;
using FamilyApp.UI.Password;
using FamilyApp.UI.StundenHG8;
using FamilyApp.Classes;

namespace FamilyApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Program.fMain = this;
            UIViewSample.SetVisualStyle(this);
            this.Update();
            sbMain.Panels[0].Text = "Server: " + DBApplication.Get.DBContext.Database.Connection.DataSource;
            sbMain.Panels[1].Text = "Datenbank: " + DBApplication.Get.DBContext.Database.Connection.Database;
            // UIViewSample.GetPanelFormatStyle(pmMain, me.Name)
            Program.cPRO.UserGuid = Program.DBReg.UserID;
            Program.cPRO.AppName = Application.ProductName;
            // cPRO.RebindGrid = AddressOf cMain.RebindGrid
            Program.cPRO.SetVisualStyle = UIViewSample.SetVisualStyle;

        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


        }

        private void btnTolls_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {

            frmTools f;
            if (!Program.HasFormInstance("frmTools", true))
            {
                f = new frmTools();
                f.MdiParent = this;
                f.Text = btnTolls.Text;
                SetFormIcon((Bitmap)btnTolls.Image, f, img16);
                f.Show();
            }

        }

        private void btnStunden_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            frmStundenEingabe f;
            if (!Program.HasFormInstance("frmStundenEingabe", true))
            {
                f = new frmStundenEingabe();
                f.MdiParent = this;
                f.Text = btnStunden.Text;
                SetFormIcon((Bitmap)btnStunden.Image, f, img16);
                f.Show();
            }

        }

        private void btnDocuments_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            frmDocuments f;
            if (!Program.HasFormInstance("frmDocuments", true))
            {
                f = new frmDocuments();
                f.MdiParent = this;
                f.Text = btnDocuments.Text;
                SetFormIcon((Bitmap)btnDocuments.Image, f, img16);
                f.Show();
            }

        }

        private void btnPassword_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            frmPasswordData f;
            if (!Program.HasFormInstance("frmPasswordData", true))
            {
                f = new frmPasswordData();
                f.MdiParent = this;
                f.Text = btnPassword.Text;
                SetFormIcon((Bitmap)btnPassword.Image, f, img16);
                f.Show();
            }
        }
        private void btnHandy_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            frmPasswordData f;
            if (!Program.HasFormInstance("frmPasswordData", true))
            {
                f = new frmPasswordData();
                f.MdiParent = this;
                f.Text = btnHandy.Text;
                SetFormIcon((Bitmap)btnHandy.Image, f, img16);
                f.Show();
            }
        }
        public void SetFormIcon(System.Drawing.Bitmap bm, Form AForm, ImageList AImageList)
        {

            if (bm != null)
            {
                IntPtr HIcon = bm.GetHicon();
                AForm.Icon = Icon.FromHandle(HIcon);
                AForm.ShowIcon = true;
            }

        }

    }
}
