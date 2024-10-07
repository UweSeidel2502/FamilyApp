using System.Collections.Generic;
using System.Diagnostics;

namespace FamilyApp.UI.StundenHG8
{
    partial class frmStundenEingabeEdit : System.Windows.Forms.Form
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
            this.cboWork = new USSoft.Data.TComboBox();
            this.dtpDatum = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtStunden = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboUser = new Janus.Windows.EditControls.UIComboBox();
            this.txtTaetigkeit = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
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
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(698, 250);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 33;
            this.cmdCancel.Text = "&Abbrechen";
            this.cmdCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // UiTab1
            // 
            this.UiTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiTab1.BackColor = System.Drawing.Color.Transparent;
            this.UiTab1.Location = new System.Drawing.Point(12, 12);
            this.UiTab1.Name = "UiTab1";
            this.UiTab1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.UiTab1.Size = new System.Drawing.Size(762, 232);
            this.UiTab1.TabIndex = 34;
            this.UiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.UiTabPage1});
            this.UiTab1.TabStop = false;
            this.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            // 
            // UiTabPage1
            // 
            this.UiTabPage1.Controls.Add(this.cboWork);
            this.UiTabPage1.Controls.Add(this.dtpDatum);
            this.UiTabPage1.Controls.Add(this.Label2);
            this.UiTabPage1.Controls.Add(this.txtStunden);
            this.UiTabPage1.Controls.Add(this.Label1);
            this.UiTabPage1.Controls.Add(this.cboUser);
            this.UiTabPage1.Controls.Add(this.txtTaetigkeit);
            this.UiTabPage1.Controls.Add(this.lblRemark);
            this.UiTabPage1.Controls.Add(this.lblName);
            this.UiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.UiTabPage1.Name = "UiTabPage1";
            this.UiTabPage1.Size = new System.Drawing.Size(760, 210);
            this.UiTabPage1.TabStop = true;
            this.UiTabPage1.Text = "Übersicht";
            // 
            // cboWork
            // 
            this.cboWork.ButtonEnabled = true;
            this.cboWork.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis;
            this.cboWork.ButtonText = "";
            this.cboWork.ButtonToolTipText = "";
            this.cboWork.ButtonVisible = false;
            this.cboWork.ButtonWidth = 26;
            this.cboWork.DataField = null;
            this.cboWork.DataKey = null;
            this.cboWork.DisplayLabel = null;
            this.cboWork.DisplayLabelPos = USSoft.Data.TEnums.TDisplayLabelPosition.dlpLeft;
            this.cboWork.IsItemInsert = false;
            this.cboWork.Location = new System.Drawing.Point(61, 81);
            this.cboWork.LookUpSQL = null;
            this.cboWork.Name = "cboWork";
            this.cboWork.NotInComboList = false;
            this.cboWork.ParamData = null;
            this.cboWork.ParamName = "";
            this.cboWork.ReadOnlyData = false;
            this.cboWork.RefreshLookUpList = false;
            this.cboWork.Required = false;
            this.cboWork.Size = new System.Drawing.Size(695, 20);
            this.cboWork.TabIndex = 3;
            this.cboWork.TupelEditor = null;
            this.cboWork.UseDisplayLableInfo = true;
            this.cboWork.UseTextAsValue = false;
            this.cboWork.Value = null;
            this.cboWork.SelectedItemChanged += new System.EventHandler(this.cboWork_SelectedItemChanged);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(61, 10);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.ShowUpDown = true;
            this.dtpDatum.Size = new System.Drawing.Size(103, 20);
            this.dtpDatum.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(7, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 13);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Datum";
            // 
            // txtStunden
            // 
            this.txtStunden.DecimalDigits = 2;
            this.txtStunden.Location = new System.Drawing.Point(61, 57);
            this.txtStunden.Name = "txtStunden";
            this.txtStunden.Size = new System.Drawing.Size(52, 20);
            this.txtStunden.TabIndex = 2;
            this.txtStunden.Text = "0,00";
            this.txtStunden.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(8, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 13);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Stunden";
            // 
            // cboUser
            // 
            this.cboUser.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboUser.Location = new System.Drawing.Point(61, 33);
            this.cboUser.Name = "cboUser";
            this.cboUser.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cboUser.Size = new System.Drawing.Size(103, 20);
            this.cboUser.TabIndex = 1;
            this.cboUser.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // txtTaetigkeit
            // 
            this.txtTaetigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaetigkeit.Location = new System.Drawing.Point(61, 105);
            this.txtTaetigkeit.Multiline = true;
            this.txtTaetigkeit.Name = "txtTaetigkeit";
            this.txtTaetigkeit.Size = new System.Drawing.Size(695, 97);
            this.txtTaetigkeit.TabIndex = 4;
            this.txtTaetigkeit.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblRemark.Location = new System.Drawing.Point(7, 86);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(48, 13);
            this.lblRemark.TabIndex = 20;
            this.lblRemark.Text = "Tätigkeit";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(7, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(618, 250);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 32;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmStundenEingabeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(786, 283);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.UiTab1);
            this.Controls.Add(this.cmdOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(393, 236);
            this.Name = "frmStundenEingabeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuer Datensatz";
            this.Load += new System.EventHandler(this.frmStundenEingabeEdit_Load);
            this.Shown += new System.EventHandler(this.frmStundenEingabeEdit_Shown);
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
        internal Janus.Windows.EditControls.UIComboBox cboUser;
        internal Janus.Windows.GridEX.EditControls.EditBox txtTaetigkeit;
        internal System.Windows.Forms.Label lblRemark;
        internal System.Windows.Forms.Label lblName;
        internal Janus.Windows.EditControls.UIButton cmdOk;
        internal Janus.Windows.GridEX.EditControls.NumericEditBox txtStunden;
        internal System.Windows.Forms.Label Label1;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDatum;
        internal System.Windows.Forms.Label Label2;
        internal USSoft.Data.TComboBox cboWork;
    }
}