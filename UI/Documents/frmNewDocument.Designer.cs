namespace FamilyApp.UI.Documents
{
    using System.Collections.Generic;
    using System.Diagnostics;

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmNewDocument : System.Windows.Forms.Form
    {

        // Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;

        // Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        // Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        // Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pmMain = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.cmdCancel = new Janus.Windows.EditControls.UIButton();
            this.UiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.UiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.rbSearchDoc = new Janus.Windows.EditControls.UIRadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtFileName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.rbExcel = new Janus.Windows.EditControls.UIRadioButton();
            this.rbWord = new Janus.Windows.EditControls.UIRadioButton();
            this.cmdExplorer = new Janus.Windows.EditControls.UIButton();
            this.cmdOk = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiTab1)).BeginInit();
            this.UiTab1.SuspendLayout();
            this.UiTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pmMain
            // 
            this.pmMain.ContainerControl = this;
            this.pmMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.pmMain.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(430, 191);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 39;
            this.cmdCancel.Text = "&Abbrechen";
            this.cmdCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // UiTab1
            // 
            this.UiTab1.BackColor = System.Drawing.Color.Transparent;
            this.UiTab1.Location = new System.Drawing.Point(12, 12);
            this.UiTab1.Name = "UiTab1";
            this.UiTab1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.UiTab1.Size = new System.Drawing.Size(493, 173);
            this.UiTab1.TabIndex = 40;
            this.UiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.UiTabPage1});
            this.UiTab1.TabStop = false;
            this.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            // 
            // UiTabPage1
            // 
            this.UiTabPage1.Controls.Add(this.rbSearchDoc);
            this.UiTabPage1.Controls.Add(this.lblType);
            this.UiTabPage1.Controls.Add(this.Label1);
            this.UiTabPage1.Controls.Add(this.txtFileName);
            this.UiTabPage1.Controls.Add(this.rbExcel);
            this.UiTabPage1.Controls.Add(this.rbWord);
            this.UiTabPage1.Controls.Add(this.cmdExplorer);
            this.UiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.UiTabPage1.Name = "UiTabPage1";
            this.UiTabPage1.Size = new System.Drawing.Size(491, 151);
            this.UiTabPage1.TabStop = true;
            this.UiTabPage1.Text = "Übersicht";
            // 
            // rbSearchDoc
            // 
            this.rbSearchDoc.BackColor = System.Drawing.Color.Transparent;
            this.rbSearchDoc.Image = global::FamilyApp.Properties.Resources.icons8_in_ordner_kopieren_16;
            this.rbSearchDoc.Location = new System.Drawing.Point(28, 15);
            this.rbSearchDoc.Name = "rbSearchDoc";
            this.rbSearchDoc.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.rbSearchDoc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbSearchDoc.Size = new System.Drawing.Size(111, 21);
            this.rbSearchDoc.TabIndex = 0;
            this.rbSearchDoc.Text = "Dateisystem";
            this.rbSearchDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.rbSearchDoc.Click += new System.EventHandler(this.rbSearchDoc_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(446, 114);
            this.lblType.Margin = new System.Windows.Forms.Padding(0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(42, 20);
            this.lblType.TabIndex = 38;
            this.lblType.Text = ".xlst";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(38, 98);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 13);
            this.Label1.TabIndex = 37;
            this.Label1.Text = "Name (ohne Dateityp)";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(38, 114);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(407, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // rbExcel
            // 
            this.rbExcel.BackColor = System.Drawing.Color.Transparent;
            this.rbExcel.Image = global::FamilyApp.Properties.Resources.icons8_microsoft_excel_2019_color_16;
            this.rbExcel.Location = new System.Drawing.Point(28, 69);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.rbExcel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbExcel.Size = new System.Drawing.Size(148, 21);
            this.rbExcel.TabIndex = 2;
            this.rbExcel.Text = "Neue Excel-Datei";
            this.rbExcel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.rbExcel.Click += new System.EventHandler(this.rbExcel_CheckedChanged);
            // 
            // rbWord
            // 
            this.rbWord.BackColor = System.Drawing.Color.Transparent;
            this.rbWord.Image = global::FamilyApp.Properties.Resources.icons8_microsoft_word_2019_color_16;
            this.rbWord.Location = new System.Drawing.Point(28, 42);
            this.rbWord.Name = "rbWord";
            this.rbWord.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.rbWord.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbWord.Size = new System.Drawing.Size(148, 21);
            this.rbWord.TabIndex = 1;
            this.rbWord.Text = "Neue Word-Datei";
            this.rbWord.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.rbWord.Click += new System.EventHandler(this.rbWord_CheckedChanged);
            // 
            // cmdExplorer
            // 
            this.cmdExplorer.Location = new System.Drawing.Point(140, 16);
            this.cmdExplorer.Name = "cmdExplorer";
            this.cmdExplorer.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdExplorer.Size = new System.Drawing.Size(84, 21);
            this.cmdExplorer.TabIndex = 33;
            this.cmdExplorer.Text = "Durchsuchen";
            this.cmdExplorer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdExplorer.Click += new System.EventHandler(this.cmdExplorer_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(350, 191);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 38;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmNewDocument
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(516, 224);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.UiTab1);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewDocument";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neues Dokument";
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiTab1)).EndInit();
            this.UiTab1.ResumeLayout(false);
            this.UiTabPage1.ResumeLayout(false);
            this.UiTabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        internal Janus.Windows.UI.Dock.UIPanelManager pmMain;
        internal Janus.Windows.EditControls.UIButton cmdCancel;
        internal Janus.Windows.UI.Tab.UITab UiTab1;
        internal Janus.Windows.UI.Tab.UITabPage UiTabPage1;
        internal Janus.Windows.EditControls.UIButton cmdOk;
        internal Janus.Windows.EditControls.UIButton cmdExplorer;
        internal Janus.Windows.EditControls.UIRadioButton rbWord;
        internal Janus.Windows.EditControls.UIRadioButton rbExcel;
        internal System.Windows.Forms.Label Label1;
        internal Janus.Windows.GridEX.EditControls.EditBox txtFileName;
        internal System.Windows.Forms.Label lblType;
        internal Janus.Windows.EditControls.UIRadioButton rbSearchDoc;
    }
}