using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FamilyApp.UI.StundenHG8
{
    partial class frmStundenEingabe : System.Windows.Forms.Form
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
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.grdMain = new USSoft.Data.TGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // pmMain
            // 
            this.pmMain.ContainerControl = this;
            this.pmMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.pmMain.SplitterSize = 2;
            this.pmMain.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.uiPanel1.Id = new System.Guid("cbeb6fde-963d-4694-ba74-840008809d7c");
            this.pmMain.Panels.Add(this.uiPanel1);
            // 
            // Design Time Panel Info:
            // 
            this.pmMain.BeginPanelInfo();
            this.pmMain.AddDockPanelInfo(new System.Guid("cbeb6fde-963d-4694-ba74-840008809d7c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1263, 643), true);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("cbeb6fde-963d-4694-ba74-840008809d7c"), new System.Drawing.Point(690, 499), new System.Drawing.Size(200, 200), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("03d7b388-8c71-4356-b922-b27faa4fb3ed"), new System.Drawing.Point(571, 183), new System.Drawing.Size(200, 200), false);
            this.pmMain.EndPanelInfo();
            // 
            // uiPanel1
            // 
            this.uiPanel1.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.FloatingLocation = new System.Drawing.Point(690, 499);
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(3, 3);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1263, 643);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "Panel 1";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.grdMain);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 1);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(1261, 641);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // grdMain
            // 
            this.grdMain.cPro = null;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.ExportExcelFileName = null;
            this.grdMain.IsDeleteVisible = true;
            this.grdMain.IsDrag = false;
            this.grdMain.IsEditVisible = false;
            this.grdMain.IsExportToExcleVisible = true;
            this.grdMain.IsFilterChecked = true;
            this.grdMain.IsFilterVisible = true;
            this.grdMain.IsFindVisible = false;
            this.grdMain.IsGridColumnPopUpVisible = false;
            this.grdMain.IsGridSettingVisible = false;
            this.grdMain.IsGroupVisible = true;
            this.grdMain.IsNewCopyVisible = false;
            this.grdMain.IsNewVisible = true;
            this.grdMain.IsPageViewVisible = false;
            this.grdMain.IsPrintVisible = true;
            this.grdMain.IsUnDoVisible = false;
            this.grdMain.KeyField = "GUID";
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.MenuItemsExtImageList = null;
            this.grdMain.Name = "grdMain";
            this.grdMain.NodeName = null;
            this.grdMain.Size = new System.Drawing.Size(1261, 641);
            this.grdMain.SQL = "";
            this.grdMain.TabIndex = 2;
            this.grdMain.UseDirectEdit = true;
            this.grdMain.UseExternPrinting = false;
            this.grdMain.UsesSetButtonState = true;
            this.grdMain.UpdatingRecord += new USSoft.Data.TGridView.UpdatingRecordEventHandler(this.grdMain_UpdatingRecord);
            this.grdMain.OnGridToolBarClick += new USSoft.Data.TGridView.OnGridToolBarClickEventHandler(this.grdMain_OnGridToolBarClick);
            // 
            // frmStundenEingabe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 649);
            this.Controls.Add(this.uiPanel1);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 39);
            this.Name = "frmStundenEingabe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stundeneingabe Heizengasse 8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStundenEingabe_FormClosing);
            this.Load += new System.EventHandler(this.frmStundenEingabe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmStundenEingabe_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal Janus.Windows.UI.Dock.UIPanelManager pmMain;
        internal Janus.Windows.UI.Dock.UIPanel uiPanel1;
        internal Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        internal USSoft.Data.TGridView grdMain;
    }
}