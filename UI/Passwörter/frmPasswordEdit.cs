using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilyApp.Data;
using USSoft.Data;

namespace FamilyApp.UI.Password
{
    public partial class frmPasswordEdit : Form
    {
        public int IndexValue;
        public int PasswordTreeID;
        private string mHashCode = "uwe.seidel@fn.de";
        public frmPasswordEdit()
        {
            InitializeComponent();
        }

        private void frmPasswordEdit_Load(object sender, EventArgs e)
        {

            if (IndexValue != -1)
            {
                PasswordBindingSource.DataSource = FamilyAppApplication.DataFactory.Password.FirstOrDefault(x => x.ID == IndexValue);
            }
            else
            {
                dtpDatum.Value = DateTime.Today;
            }
        }
        private void frmPasswordEdit_Shown(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    txtPassword.Text = Crypt.clsCrypt.Decrypt(txtPassword.Text, mHashCode);
                }
            }
            catch 
            {
                // Passwort nicht verschlüsselt,
            }

            txtPassword.PasswordChar = '*';
            txtFactoryName.Focus();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFactoryName.Text))
            {
                Program.cPRO.MsgBoxExt("Bitte Firma eintragen!", TMsgBox.MsgBoxIcon.mbiError, "Fehler",  Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
                txtName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                Program.cPRO.MsgBoxExt("Bitte Name eintragen!", TMsgBox.MsgBoxIcon.mbiError, "Fehler",  Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
                txtName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Program.cPRO.MsgBoxExt("Bitte Passwort eintragen!", TMsgBox.MsgBoxIcon.mbiError, "Fehler",  Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
                txtPassword.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

            FamilyApp.Data.Password MyPassword;

            if (IndexValue == -1)
            {
                MyPassword = FamilyAppApplication.DataFactory.Password.Add(new FamilyApp.Data.Password() { PasswordTreeID = PasswordTreeID });
            }
            else
            {
                MyPassword = (FamilyApp.Data.Password)PasswordBindingSource.DataSource;
            }

            MyPassword.FactoryName = txtFactoryName.Text;
            MyPassword.DateCreated = dtpDatum.Value;
            MyPassword.UserName = txtName.Text;
            var test = Crypt.clsCrypt.Encrypt(txtPassword.Text, mHashCode);
            MyPassword.UserPassword = test;
            MyPassword.Homepage = txtHomepage.Text;
            MyPassword.Remark = txtRemark.Text;

            FamilyAppApplication.DataFactory.SaveChanges();
            IndexValue = MyPassword.ID;

        }

        private void UiButton1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == Convert.ToChar("*"))
            {
                txtPassword.PasswordChar = '\0'; ;
            }
            else
            {
                txtPassword.PasswordChar = Convert.ToChar("*");
            }
        }

    }
}
