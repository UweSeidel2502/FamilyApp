
namespace FamilyApp
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.vsm = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.pmMain = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.img16 = new System.Windows.Forms.ImageList(this.components);
            this.img32 = new System.Windows.Forms.ImageList(this.components);
            this.sbMain = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.rbMain = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btnTolls = new Janus.Windows.Ribbon.ButtonCommand();
            this.btnStunden = new Janus.Windows.Ribbon.ButtonCommand();
            this.btnDocuments = new Janus.Windows.Ribbon.ButtonCommand();
            this.btnPassword = new Janus.Windows.Ribbon.ButtonCommand();
            this.btnHandy = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // vsm
            // 
            janusColorScheme2.DisabledColor = System.Drawing.Color.Black;
            janusColorScheme2.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme2.Name = "Default";
            janusColorScheme2.Office2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Black;
            janusColorScheme2.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme2.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.vsm.ColorSchemes.Add(janusColorScheme2);
            this.vsm.DefaultColorScheme = null;
            // 
            // pmMain
            // 
            this.pmMain.AllowPanelDrag = false;
            this.pmMain.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><AutoHidePanelToolTip>" +
    "Ausblenden </AutoHidePanelToolTip></LocalizableData>";
            this.pmMain.ContainerControl = this;
            this.pmMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.pmMain.SplitterSize = 3;
            this.pmMain.TabbedMdi = true;
            this.pmMain.TabbedMdiSettings.ShowCloseButtonOnSelectedTab = true;
            this.pmMain.TabbedMdiSettings.UseFormIcons = true;
            this.pmMain.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.pmMain.VisualStyleManager = this.vsm;
            // 
            // img16
            // 
            this.img16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img16.ImageStream")));
            this.img16.TransparentColor = System.Drawing.Color.Transparent;
            this.img16.Images.SetKeyName(0, "UMUser.ico");
            this.img16.Images.SetKeyName(1, "Image120.ico");
            this.img16.Images.SetKeyName(2, "Beenden.ico");
            this.img16.Images.SetKeyName(3, "Image07.ico");
            this.img16.Images.SetKeyName(4, "Image23.ico");
            this.img16.Images.SetKeyName(5, "Image123.ico");
            this.img16.Images.SetKeyName(6, "Image124.ico");
            this.img16.Images.SetKeyName(7, "Image107.ico");
            this.img16.Images.SetKeyName(8, "Image82.ico");
            this.img16.Images.SetKeyName(9, "CloseApp.ico");
            this.img16.Images.SetKeyName(10, "Image27.ico");
            this.img16.Images.SetKeyName(11, "Image63.ico");
            this.img16.Images.SetKeyName(12, "Image57.ico");
            this.img16.Images.SetKeyName(13, "Image216.ico");
            this.img16.Images.SetKeyName(14, "Image217.ico");
            this.img16.Images.SetKeyName(15, "doc_tag.png");
            this.img16.Images.SetKeyName(16, "DLI");
            this.img16.Images.SetKeyName(17, "HeartHalf");
            this.img16.Images.SetKeyName(18, "icons8-smartphone-16.png");
            // 
            // img32
            // 
            this.img32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img32.ImageStream")));
            this.img32.TransparentColor = System.Drawing.Color.Transparent;
            this.img32.Images.SetKeyName(0, "icons8-schlüssel-office-m-32.png");
            this.img32.Images.SetKeyName(1, "icons8-smartphone-32.png");
            // 
            // sbMain
            // 
            this.sbMain.Location = new System.Drawing.Point(0, 488);
            this.sbMain.Name = "sbMain";
            this.sbMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "";
            uiStatusBarPanel3.ProgressBarValue = 0;
            uiStatusBarPanel3.Width = 185;
            uiStatusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Width = 10;
            this.sbMain.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.sbMain.Size = new System.Drawing.Size(888, 23);
            this.sbMain.TabIndex = 4;
            this.sbMain.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.sbMain.VisualStyleManager = this.vsm;
            // 
            // rbMain
            // 
            this.rbMain.ControlBoxMenu.SuperTipSettings.ImageListProvider = this.rbMain.ControlBoxMenu;
            this.rbMain.DocumentName = "FamilyApp C#";
            this.rbMain.ImageList = this.img16;
            this.rbMain.LargeImageList = this.img32;
            this.rbMain.Location = new System.Drawing.Point(0, 0);
            this.rbMain.Name = "rbMain";
            this.rbMain.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black;
            this.rbMain.ShowControlBoxButton = false;
            this.rbMain.ShowCustomizeButton = false;
            this.rbMain.ShowQuickCustomizeMenu = false;
            this.rbMain.Size = new System.Drawing.Size(888, 146);
            // 
            // 
            // 
            this.rbMain.SuperTipComponent.AutoPopDelay = 2000;
            this.rbMain.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMain.SuperTipComponent.ImageList = this.img16;
            this.rbMain.TabIndex = 6;
            this.rbMain.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.ribbonTab1});
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup1});
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Daten";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btnTolls,
            this.btnStunden,
            this.btnDocuments,
            this.btnPassword,
            this.btnHandy});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.SuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Text = "Seidel";
            // 
            // btnTolls
            // 
            this.btnTolls.Image = ((System.Drawing.Image)(resources.GetObject("btnTolls.Image")));
            this.btnTolls.Key = "btnTolls";
            this.btnTolls.Name = "btnTolls";
            this.btnTolls.SuperTipSettings.ImageListProvider = this.btnTolls;
            this.btnTolls.Text = "Werkzeuge";
            this.btnTolls.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btnTolls_Click);
            // 
            // btnStunden
            // 
            this.btnStunden.Image = ((System.Drawing.Image)(resources.GetObject("btnStunden.Image")));
            this.btnStunden.Key = "btnStunden";
            this.btnStunden.Name = "btnStunden";
            this.btnStunden.SuperTipSettings.ImageListProvider = this.btnStunden;
            this.btnStunden.Text = "Stunden Heizengasse";
            this.btnStunden.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btnStunden_Click);
            // 
            // btnDocuments
            // 
            this.btnDocuments.Image = ((System.Drawing.Image)(resources.GetObject("btnDocuments.Image")));
            this.btnDocuments.Key = "btnDocuments";
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.SuperTipSettings.ImageListProvider = this.btnDocuments;
            this.btnDocuments.Text = "Dokumente";
            this.btnDocuments.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btnDocuments_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnPassword.Image")));
            this.btnPassword.Key = "btnPassword";
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.SuperTipSettings.ImageListProvider = this.btnPassword;
            this.btnPassword.Text = "Passwörter";
            this.btnPassword.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btnPassword_Click);
            // 
            // btnHandy
            // 
            this.btnHandy.ImageIndex = 18;
            this.btnHandy.Key = "buttonCommand1";
            this.btnHandy.LargeImageIndex = 1;
            this.btnHandy.Name = "btnHandy";
            this.btnHandy.SuperTipSettings.ImageListProvider = this.btnHandy;
            this.btnHandy.Text = "Handy";
            this.btnHandy.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btnHandy_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 511);
            this.Controls.Add(this.rbMain);
            this.Controls.Add(this.sbMain);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "FamilyApp C#";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.Common.VisualStyleManager vsm;
        internal Janus.Windows.UI.Dock.UIPanelManager pmMain;
        internal System.Windows.Forms.ImageList img16;
        internal System.Windows.Forms.ImageList img32;
        internal Janus.Windows.Ribbon.Ribbon rbMain;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand btnTolls;
        private Janus.Windows.Ribbon.ButtonCommand btnStunden;
        private Janus.Windows.Ribbon.ButtonCommand btnDocuments;
        private Janus.Windows.Ribbon.ButtonCommand btnPassword;
        internal Janus.Windows.UI.StatusBar.UIStatusBar sbMain;
        private Janus.Windows.Ribbon.ButtonCommand btnHandy;
    }
}

