using USSoft.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FamilyApp.UI.StundenHG8
{
    public partial class frmStundenEingabeEdit : Form
    {
        public DateTime Datum;
        public frmStundenEingabeEdit()
        {
            InitializeComponent();
        }
        private void frmStundenEingabeEdit_Load(object sender, EventArgs e)
        {
            dtpDatum.Value = Datum;

            foreach (var B in FamilyAppApplication.DataFactory.Bearbeiter.ToList())
                cboUser.Items.Add(B.Name, B.ID);

            var work = (from a in FamilyAppApplication.DataFactory.ArbeitsStunden
                        select a.Taetigkeit).Distinct();

            foreach (var t in work)
                cboWork.Items.Add(t, t);

            if (cboUser.Items.Count > 0)
            {
                cboUser.SelectedIndex = 0;
            }
            txtStunden.Value = 1;

        }
        private void frmStundenEingabeEdit_Shown(object sender, EventArgs e)
        {
            txtTaetigkeit.Focus();
        }
        private void cmdOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTaetigkeit.Text))
            {
                Program.cPRO.MsgBoxExt("Bitte Tätigkeit eintragen!", TMsgBox.MsgBoxIcon.mbiError, "Fehler",  Microsoft.VisualBasic.MsgBoxStyle.OkOnly );
                txtTaetigkeit.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }

               FamilyAppApplication.DataFactory.ArbeitsStunden.Add(new FamilyApp.Data.ArbeitsStunden()
            {
                Datum = dtpDatum.Value,
                Stunden = (decimal)txtStunden.Value,
                UserID = (Int32)cboUser.SelectedValue,
                Taetigkeit = txtTaetigkeit.Text
            });

            FamilyAppApplication.DataFactory.SaveChanges();
        }

        private void cboWork_SelectedItemChanged(object sender, EventArgs e)
        {
            txtTaetigkeit.Text = cboWork.Text;
        }

    }
}



