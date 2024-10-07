namespace FamilyApp.UI.Password
{
    using System.Collections.Generic;
    using System.Diagnostics;

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmPasswordEdit : System.Windows.Forms.Form
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
            this.UiButton1 = new Janus.Windows.EditControls.UIButton();
            this.txtFactoryName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtRemark = new Janus.Windows.GridEX.EditControls.EditBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPassword = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.dtpDatum = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtHomepage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmdOk = new Janus.Windows.EditControls.UIButton();
            this.UiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.PasswordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiTab1)).BeginInit();
            this.UiTab1.SuspendLayout();
            this.UiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBindingSource)).BeginInit();
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
            this.cmdCancel.Location = new System.Drawing.Point(403, 274);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
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
            this.UiTab1.Size = new System.Drawing.Size(466, 256);
            this.UiTab1.TabIndex = 37;
            this.UiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.UiTabPage1});
            this.UiTab1.TabStop = false;
            this.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            // 
            // UiButton1
            // 
            this.UiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UiButton1.Image = global::FamilyApp.Properties.Resources.icons8_augen_emoji_16;
            this.UiButton1.Location = new System.Drawing.Point(418, 88);
            this.UiButton1.Name = "UiButton1";
            this.UiButton1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.UiButton1.Size = new System.Drawing.Size(29, 20);
            this.UiButton1.TabIndex = 38;
            this.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.UiButton1.Click += new System.EventHandler(this.UiButton1_Click);
            // 
            // txtFactoryName
            // 
            this.txtFactoryName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "FactoryName", true));
            this.txtFactoryName.Location = new System.Drawing.Point(83, 36);
            this.txtFactoryName.Name = "txtFactoryName";
            this.txtFactoryName.Size = new System.Drawing.Size(364, 20);
            this.txtFactoryName.TabIndex = 1;
            this.txtFactoryName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(7, 40);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 14);
            this.Label4.TabIndex = 32;
            this.Label4.Text = "Firma";
            // 
            // txtRemark
            // 
            this.txtRemark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "Remark", true));
            this.txtRemark.Location = new System.Drawing.Point(83, 140);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(363, 83);
            this.txtRemark.TabIndex = 5;
            this.txtRemark.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Location = new System.Drawing.Point(7, 142);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 30;
            this.Label3.Text = "Bemerkung";
            // 
            // txtPassword
            // 
            this.txtPassword.ButtonImageSize = new System.Drawing.Size(10, 10);
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "UserPassword", true));
            this.txtPassword.Location = new System.Drawing.Point(83, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(335, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "UserName", true));
            this.txtName.Location = new System.Drawing.Point(83, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(364, 20);
            this.txtName.TabIndex = 2;
            this.txtName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // dtpDatum
            // 
            this.dtpDatum.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.PasswordBindingSource, "DateCreated", true));
            // 
            // 
            // 
            this.dtpDatum.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.dtpDatum.Location = new System.Drawing.Point(83, 10);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.ShowUpDown = true;
            this.dtpDatum.Size = new System.Drawing.Size(103, 20);
            this.dtpDatum.TabIndex = 0;
            this.dtpDatum.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(7, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 13);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Erstellt";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(8, 91);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(74, 17);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Passwort";
            // 
            // txtHomepage
            // 
            this.txtHomepage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PasswordBindingSource, "Homepage", true));
            this.txtHomepage.Location = new System.Drawing.Point(83, 114);
            this.txtHomepage.Name = "txtHomepage";
            this.txtHomepage.Size = new System.Drawing.Size(363, 20);
            this.txtHomepage.TabIndex = 4;
            this.txtHomepage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblRemark.Location = new System.Drawing.Point(7, 117);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(75, 13);
            this.lblRemark.TabIndex = 20;
            this.lblRemark.Text = "Homepage";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(7, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Benutzername";
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(323, 274);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 6;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // UiTabPage1
            // 
            this.UiTabPage1.Controls.Add(this.UiButton1);
            this.UiTabPage1.Controls.Add(this.txtFactoryName);
            this.UiTabPage1.Controls.Add(this.Label4);
            this.UiTabPage1.Controls.Add(this.txtRemark);
            this.UiTabPage1.Controls.Add(this.Label3);
            this.UiTabPage1.Controls.Add(this.txtPassword);
            this.UiTabPage1.Controls.Add(this.txtName);
            this.UiTabPage1.Controls.Add(this.dtpDatum);
            this.UiTabPage1.Controls.Add(this.Label2);
            this.UiTabPage1.Controls.Add(this.Label1);
            this.UiTabPage1.Controls.Add(this.txtHomepage);
            this.UiTabPage1.Controls.Add(this.lblRemark);
            this.UiTabPage1.Controls.Add(this.lblName);
            this.UiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.UiTabPage1.Name = "UiTabPage1";
            this.UiTabPage1.Size = new System.Drawing.Size(464, 234);
            this.UiTabPage1.TabStop = true;
            this.UiTabPage1.Text = "Übersicht";
            // 
            // PasswordBindingSource
            // 
            this.PasswordBindingSource.DataSource = typeof(FamilyApp.Data.Password);
            // 
            // frmPasswordEdit
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(490, 306);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.UiTab1);
            this.Controls.Add(this.cmdOk);
            this.Name = "frmPasswordEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passwort bearbeiten";
            this.Load += new System.EventHandler(this.frmPasswordEdit_Load);
            this.Shown += new System.EventHandler(this.frmPasswordEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiTab1)).EndInit();
            this.UiTab1.ResumeLayout(false);
            this.UiTabPage1.ResumeLayout(false);
            this.UiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        internal Janus.Windows.UI.Dock.UIPanelManager pmMain;
        internal Janus.Windows.EditControls.UIButton cmdCancel;
        internal Janus.Windows.UI.Tab.UITab UiTab1;
        internal Janus.Windows.UI.Tab.UITabPage UiTabPage1;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDatum;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal Janus.Windows.GridEX.EditControls.EditBox txtHomepage;
        internal System.Windows.Forms.Label lblRemark;
        internal System.Windows.Forms.Label lblName;
        internal Janus.Windows.EditControls.UIButton cmdOk;
        internal Janus.Windows.GridEX.EditControls.EditBox txtName;
        internal Janus.Windows.GridEX.EditControls.EditBox txtRemark;
        internal System.Windows.Forms.Label Label3;
        internal Janus.Windows.GridEX.EditControls.EditBox txtPassword;
        internal System.Windows.Forms.BindingSource PasswordBindingSource;
        internal Janus.Windows.GridEX.EditControls.EditBox txtFactoryName;
        internal System.Windows.Forms.Label Label4;
        internal Janus.Windows.EditControls.UIButton UiButton1;
    }
}
