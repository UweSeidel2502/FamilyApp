using System;
using System.Windows.Forms;
using USSoft.Data;
using System.IO;

namespace FamilyApp.UI.Documents
{
    public partial class frmNewDocument : Form
    {
        public string FileName;
        public frmDocuments RefForm;
        public Boolean IsFromSearchDoc;

        public frmNewDocument()
        {
            InitializeComponent();
            lblType.Text = "";
            rbSearchDoc.Checked = true;
            cmdExplorer.Enabled = true;
            txtFileName.Enabled = false;
            lblType.Enabled = false;
            cmdOk.Enabled = false;
        }
        private void rbSearchDoc_CheckedChanged(object sender, EventArgs e)
        {
            cmdExplorer.Enabled = true;
            txtFileName.Enabled = false;
            lblType.Enabled = false;
            cmdOk.Enabled = false;
        }
        private void rbWord_CheckedChanged(object sender, EventArgs e)
        {
            lblType.Text = ".docx";
            cmdExplorer.Enabled = false;
            txtFileName.Enabled = true;
            lblType.Enabled = true;
            cmdOk.Enabled = true;
        }
        private void rbExcel_CheckedChanged(object sender, EventArgs e)
        {
            lblType.Text = ".xlsx";
            cmdExplorer.Enabled = false;
            txtFileName.Enabled = true;
            lblType.Enabled = true;
            cmdOk.Enabled = true;
        }
        private void cmdExplorer_Click(object sender, EventArgs e)
        {

            string sFileName = "";
            sFileName = RefForm.GetDocumentFileName(ref sFileName, "");

            if (string.IsNullOrEmpty(sFileName))
                return;

            FileName = sFileName;
            this.DialogResult = DialogResult.OK;

        }
        private void cmdOk_Click(object sender, EventArgs e)
        {

            const int wdFormatXMLDocument = 12;
            const int wdCompatibilityMode = 15;
            const int wdSaveChanges = -1;
            const int xlOpenXMLWorkbook = 51;

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                Program.cPRO.MsgBoxExt("Bitte Name eintragen!", TMsgBox.MsgBoxIcon.mbiError, "Fehler", Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
                txtFileName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }


            FileName = txtFileName.Text + lblType.Text;
            FileName = System.IO.Path.Combine(RefForm.TmpPath, FileName);

            try
            {
                this.Cursor = Cursor.Current;
                if (rbWord.Checked)
                {

                    clsAppData.CloseProcess("WINWORD");
                    Microsoft.Office.Interop.Word.Application myWord = new Microsoft.Office.Interop.Word.Application();
                    myWord.Documents.Add(Template: "Normal", NewTemplate: false, DocumentType: 0);
                    myWord.ChangeFileOpenDirectory(Path.GetTempPath());
                    myWord.ActiveDocument.SaveAs2(FileName: FileName, FileFormat: wdFormatXMLDocument, CompatibilityMode: wdCompatibilityMode);
                    myWord.ActiveDocument.Close();
                    myWord.Application.Quit(SaveChanges: wdSaveChanges);
                    myWord = null;
                    this.DialogResult = DialogResult.OK;
                    return;
                }

                if (rbExcel.Checked)
                {
                    clsAppData.CloseProcess("EXCEL");
                    this.Cursor = Cursor.Current;
                    Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
                    myExcel.Workbooks.Add();
                    myExcel.ActiveWorkbook.SaveAs(Filename: FileName, FileFormat: xlOpenXMLWorkbook, CreateBackup: false);
                    myExcel.ActiveWindow.Close();
                    myExcel.Application.Quit();
                    myExcel = null;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }

            catch 
            {
                this.DialogResult = DialogResult.Cancel;
                FileName = string.Empty;
                return;
            }

        }
    }
}
