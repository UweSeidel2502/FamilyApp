namespace FamilyApp.UI.Documents
{
    partial class frmDocuments : System.Windows.Forms.Form
    {

        // Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocuments));
            this.vsm = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.pmMain = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.UiPanelGroup1 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanel2 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanelFolder = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.UiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmMain = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.mnuNew2 = new Janus.Windows.UI.CommandBars.UICommand("mnuNew");
            this.mnuEdit = new Janus.Windows.UI.CommandBars.UICommand("mnuEdit");
            this.mnuDelete = new Janus.Windows.UI.CommandBars.UICommand("mnuDelete");
            this.popWindow = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.popMain = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.mnuNew3 = new Janus.Windows.UI.CommandBars.UICommand("mnuNew");
            this.mnuEdit2 = new Janus.Windows.UI.CommandBars.UICommand("mnuEdit");
            this.mnuDelete2 = new Janus.Windows.UI.CommandBars.UICommand("mnuDelete");
            this.img16 = new System.Windows.Forms.ImageList(this.components);
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.mnuNew1 = new Janus.Windows.UI.CommandBars.UICommand("mnuNew");
            this.mnuEdit1 = new Janus.Windows.UI.CommandBars.UICommand("mnuEdit");
            this.mnuDelete1 = new Janus.Windows.UI.CommandBars.UICommand("mnuDelete");
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.trv = new USSoft.Data.TTreeView();
            this.UiPanelGroup3 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.grdMain = new USSoft.Data.TGridView();
            this.pPreView = new Janus.Windows.UI.Dock.UIPanel();
            this.pPreViewContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.mnuNew = new Janus.Windows.UI.CommandBars.UICommand("mnuNew");
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiPanelGroup1)).BeginInit();
            this.UiPanelGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.uiPanelFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiPanelGroup3)).BeginInit();
            this.UiPanelGroup3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pPreView)).BeginInit();
            this.pPreView.SuspendLayout();
            this.pPreViewContainer.SuspendLayout();
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
            this.pmMain.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><AutoHidePanelToolTip>" +
    "Ausblenden </AutoHidePanelToolTip></LocalizableData>";
            this.pmMain.ContainerControl = this;
            this.pmMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.pmMain.SplitterSize = 3;
            this.pmMain.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.pmMain.VisualStyleManager = this.vsm;
            this.UiPanelGroup1.Id = new System.Guid("7daf8ef6-e0bd-417a-b080-55388f87cdfc");
            this.uiPanel2.Id = new System.Guid("2519d0cf-6846-46b5-93ff-d2e841b588f8");
            this.UiPanelGroup1.Panels.Add(this.uiPanel2);
            this.uiPanel0.Id = new System.Guid("4f634037-74da-4a23-808e-245eaaf17dc7");
            this.UiPanelGroup1.Panels.Add(this.uiPanel0);
            this.pmMain.Panels.Add(this.UiPanelGroup1);
            this.UiPanelGroup3.Id = new System.Guid("e65b98b5-1e42-4741-87c8-dab56844148e");
            this.uiPanel1.Id = new System.Guid("3995c41d-9bdd-492a-8d67-1fa747b09749");
            this.UiPanelGroup3.Panels.Add(this.uiPanel1);
            this.pPreView.Id = new System.Guid("9c77920b-3d03-4e3c-818e-4b1525832de6");
            this.UiPanelGroup3.Panels.Add(this.pPreView);
            this.pmMain.Panels.Add(this.UiPanelGroup3);
            // 
            // Design Time Panel Info:
            // 
            this.pmMain.BeginPanelInfo();
            this.pmMain.AddDockPanelInfo(new System.Guid("7daf8ef6-e0bd-417a-b080-55388f87cdfc"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, false, new System.Drawing.Size(227, 515), true);
            this.pmMain.AddDockPanelInfo(new System.Guid("2519d0cf-6846-46b5-93ff-d2e841b588f8"), new System.Guid("7daf8ef6-e0bd-417a-b080-55388f87cdfc"), 30, true);
            this.pmMain.AddDockPanelInfo(new System.Guid("4f634037-74da-4a23-808e-245eaaf17dc7"), new System.Guid("7daf8ef6-e0bd-417a-b080-55388f87cdfc"), 482, true);
            this.pmMain.AddDockPanelInfo(new System.Guid("e65b98b5-1e42-4741-87c8-dab56844148e"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Fill, false, new System.Drawing.Size(1009, 515), true);
            this.pmMain.AddDockPanelInfo(new System.Guid("3995c41d-9bdd-492a-8d67-1fa747b09749"), new System.Guid("e65b98b5-1e42-4741-87c8-dab56844148e"), 338, true);
            this.pmMain.AddDockPanelInfo(new System.Guid("9c77920b-3d03-4e3c-818e-4b1525832de6"), new System.Guid("e65b98b5-1e42-4741-87c8-dab56844148e"), 174, true);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("0c34fba0-ed9a-4b04-807c-ec1a0c99e1c5"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("3de18fec-43e5-417d-b8b0-fd2f40c6d0d2"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("4f634037-74da-4a23-808e-245eaaf17dc7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("3995c41d-9bdd-492a-8d67-1fa747b09749"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("fe652091-2b96-4b96-9d7d-c13f633c7fab"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("2519d0cf-6846-46b5-93ff-d2e841b588f8"), new System.Drawing.Point(299, 388), new System.Drawing.Size(200, 200), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("891ca29c-f9fa-448b-8abb-b20eace185c6"), new System.Drawing.Point(837, 394), new System.Drawing.Size(200, 200), false);
            this.pmMain.AddFloatingPanelInfo(new System.Guid("9c77920b-3d03-4e3c-818e-4b1525832de6"), new System.Drawing.Point(628, 362), new System.Drawing.Size(200, 200), false);
            this.pmMain.EndPanelInfo();
            // 
            // UiPanelGroup1
            // 
            this.UiPanelGroup1.Location = new System.Drawing.Point(3, 3);
            this.UiPanelGroup1.Name = "UiPanelGroup1";
            this.UiPanelGroup1.Size = new System.Drawing.Size(227, 515);
            this.UiPanelGroup1.TabIndex = 4;
            // 
            // uiPanel2
            // 
            this.uiPanel2.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel2.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanel2.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel2.FloatingLocation = new System.Drawing.Point(299, 388);
            this.uiPanel2.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanel2.InnerContainer = this.uiPanelFolder;
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(-1, 30);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(224, 30);
            this.uiPanel2.TabIndex = 4;
            // 
            // uiPanelFolder
            // 
            this.uiPanelFolder.Controls.Add(this.TopRebar1);
            this.uiPanelFolder.Location = new System.Drawing.Point(1, 1);
            this.uiPanelFolder.MinimumSize = new System.Drawing.Size(0, 28);
            this.uiPanelFolder.Name = "uiPanelFolder";
            this.uiPanelFolder.Size = new System.Drawing.Size(222, 28);
            this.uiPanelFolder.TabIndex = 0;
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.UiCommandBar1});
            this.TopRebar1.CommandManager = this.cmMain;
            this.TopRebar1.Controls.Add(this.UiCommandBar1);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.TopRebar1.Size = new System.Drawing.Size(222, 28);
            this.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // UiCommandBar1
            // 
            this.UiCommandBar1.CommandManager = this.cmMain;
            this.UiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.mnuNew1,
            this.mnuEdit1,
            this.mnuDelete1});
            this.UiCommandBar1.Key = "CommandBar1";
            this.UiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.UiCommandBar1.Name = "UiCommandBar1";
            this.UiCommandBar1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.UiCommandBar1.RowIndex = 0;
            this.UiCommandBar1.Size = new System.Drawing.Size(71, 28);
            this.UiCommandBar1.Text = "CommandBar1";
            // 
            // cmMain
            // 
            this.cmMain.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.cmMain.BottomRebar = this.BottomRebar1;
            this.cmMain.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.UiCommandBar1});
            this.cmMain.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.mnuNew2,
            this.mnuEdit,
            this.mnuDelete});
            this.cmMain.ContainerControl = this.uiPanelFolder;
            this.cmMain.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.popWindow,
            this.popMain});
            // 
            // 
            // 
            this.cmMain.EditContextMenu.Key = "";
            this.cmMain.Id = new System.Guid("f3c35928-058f-4f85-9066-7cac83ba6208");
            this.cmMain.ImageList = this.img16;
            this.cmMain.LeftRebar = this.LeftRebar1;
            this.cmMain.LockCommandBars = true;
            this.cmMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.cmMain.RightRebar = this.RightRebar1;
            this.cmMain.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.cmMain.TopRebar = this.TopRebar1;
            this.cmMain.VisualStyleManager = this.vsm;
            this.cmMain.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.cmMain_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.cmMain;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 0);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.BottomRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // mnuNew2
            // 
            this.mnuNew2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.mnuNew2.ImageIndex = 0;
            this.mnuNew2.Key = "mnuNew";
            this.mnuNew2.Name = "mnuNew2";
            this.mnuNew2.Shortcut = System.Windows.Forms.Shortcut.Ins;
            this.mnuNew2.Text = "Neuer Ordner";
            // 
            // mnuEdit
            // 
            this.mnuEdit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.mnuEdit.ImageIndex = 1;
            this.mnuEdit.Key = "mnuEdit";
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Text = "Bearbeiten";
            // 
            // mnuDelete
            // 
            this.mnuDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.mnuDelete.ImageIndex = 3;
            this.mnuDelete.Key = "mnuDelete";
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Text = "Ordner löschen";
            // 
            // popWindow
            // 
            this.popWindow.CommandManager = this.cmMain;
            this.popWindow.Key = "popWindow";
            this.popWindow.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            // 
            // popMain
            // 
            this.popMain.CommandManager = this.cmMain;
            this.popMain.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.mnuNew3,
            this.mnuEdit2,
            this.mnuDelete2});
            this.popMain.Key = "popMain";
            this.popMain.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            // 
            // mnuNew3
            // 
            this.mnuNew3.Key = "mnuNew";
            this.mnuNew3.Name = "mnuNew3";
            this.mnuNew3.Text = "Neuer Eintrag";
            // 
            // mnuEdit2
            // 
            this.mnuEdit2.Key = "mnuEdit";
            this.mnuEdit2.Name = "mnuEdit2";
            // 
            // mnuDelete2
            // 
            this.mnuDelete2.Key = "mnuDelete";
            this.mnuDelete2.Name = "mnuDelete2";
            this.mnuDelete2.Text = "Eintrag löschen";
            // 
            // img16
            // 
            this.img16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img16.ImageStream")));
            this.img16.TransparentColor = System.Drawing.Color.Transparent;
            this.img16.Images.SetKeyName(0, "NEW.png");
            this.img16.Images.SetKeyName(1, "EDIT.png");
            this.img16.Images.SetKeyName(2, "disk.png");
            this.img16.Images.SetKeyName(3, "DELETE.png");
            this.img16.Images.SetKeyName(4, "icons8-wartung-16.ico");
            this.img16.Images.SetKeyName(5, "PfeilRechts.ico");
            this.img16.Images.SetKeyName(6, "FilterAdd.ico");
            this.img16.Images.SetKeyName(7, "page_white_find.png");
            this.img16.Images.SetKeyName(8, "FilterDel.ico");
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.cmMain;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.LeftRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.cmMain;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(0, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Black;
            this.RightRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // mnuNew1
            // 
            this.mnuNew1.Key = "mnuNew";
            this.mnuNew1.Name = "mnuNew1";
            this.mnuNew1.Text = "Neuer Eintrag";
            // 
            // mnuEdit1
            // 
            this.mnuEdit1.Key = "mnuEdit";
            this.mnuEdit1.Name = "mnuEdit1";
            // 
            // mnuDelete1
            // 
            this.mnuDelete1.Key = "mnuDelete";
            this.mnuDelete1.Name = "mnuDelete1";
            this.mnuDelete1.Text = "Eintrag löschen";
            // 
            // uiPanel0
            // 
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(0, 33);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(224, 482);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Panel 0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.trv);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 1);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(222, 480);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // trv
            // 
            this.trv.AggregationMode = Janus.Data.SelfReferencingAggregationMode.AllRows;
            this.trv.AllowDrop = true;
            this.trv.AllowNodeDrop = true;
            this.trv.BackColor = System.Drawing.Color.Transparent;
            this.trv.BorderStyleTreeView = Janus.Windows.GridEX.BorderStyle.None;
            this.trv.ChildListMember = "Nodes";
            this.trv.ChildMember = "";
            this.trv.ChildNodeKeyDBField = "";
            this.trv.ChildNodeNameDBField = "";
            this.trv.DataSource = null;
            this.trv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv.HierarchicalGroupMode = Janus.Data.HierarchicalGroupMode.ParentRows;
            this.trv.IconColumns = 0;
            this.trv.ImageList = null;
            this.trv.Location = new System.Drawing.Point(0, 0);
            this.trv.Name = "trv";
            this.trv.Node = null;
            this.trv.NodeClickBehavior = USSoft.Data.TEnums.TNodeClickBehavior.ncbOnSelected;
            this.trv.NodeHideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.trv.NodeInfoDBField = "";
            this.trv.NodeInfoTextDBField = "";
            this.trv.ParentMember = "";
            this.trv.ParentNodeKeyDBField = "GUID";
            this.trv.ParentNodeNameDBField = "";
            this.trv.ParentRootMode = Janus.Data.ParentRootMode.NullValue;
            this.trv.ParentRootValue = null;
            this.trv.RowHeight = -1;
            this.trv.Size = new System.Drawing.Size(222, 480);
            this.trv.SQL = null;
            this.trv.TabIndex = 1;
            this.trv.TreatOrphanRowsAsRoot = false;
            this.trv.TreeLines = true;
            this.trv.VisualSyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.trv.NodeClick += new USSoft.Data.TTreeView.NodeClickEventHandler(this.trv_NodeClick);
            this.trv.DragDrop += new USSoft.Data.TTreeView.DragDropEventHandler(this.trv_DragDrop);
            this.trv.DragOver += new USSoft.Data.TTreeView.DragOverEventHandler(this.trv_DragOver);
            // 
            // UiPanelGroup3
            // 
            this.UiPanelGroup3.Location = new System.Drawing.Point(230, 3);
            this.UiPanelGroup3.Name = "UiPanelGroup3";
            this.UiPanelGroup3.Size = new System.Drawing.Size(1009, 515);
            this.UiPanelGroup3.TabIndex = 5;
            this.UiPanelGroup3.Visible = false;
            // 
            // uiPanel1
            // 
            this.uiPanel1.AllowResize = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1009, 338);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = "Werkzeuge";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.grdMain);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 1);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(1007, 336);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // grdMain
            // 
            this.grdMain.AllowDrop = true;
            this.grdMain.cPro = null;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.ExportExcelFileName = null;
            this.grdMain.IsDeleteVisible = true;
            this.grdMain.IsDrag = false;
            this.grdMain.IsEditVisible = true;
            this.grdMain.IsExportToExcleVisible = true;
            this.grdMain.IsFilterChecked = false;
            this.grdMain.IsFilterVisible = true;
            this.grdMain.IsFindVisible = false;
            this.grdMain.IsGridColumnPopUpVisible = true;
            this.grdMain.IsGridSettingVisible = false;
            this.grdMain.IsGroupVisible = true;
            this.grdMain.IsNewCopyVisible = false;
            this.grdMain.IsNewVisible = true;
            this.grdMain.IsPageViewVisible = true;
            this.grdMain.IsPrintVisible = true;
            this.grdMain.IsUnDoVisible = false;
            this.grdMain.KeyField = "ID";
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.MenuItemsExtImageList = null;
            this.grdMain.Name = "grdMain";
            this.grdMain.NodeName = null;
            this.grdMain.Size = new System.Drawing.Size(1007, 336);
            this.grdMain.SQL = "";
            this.grdMain.TabIndex = 1;
            this.grdMain.UseDirectEdit = true;
            this.grdMain.UseExternPrinting = false;
            this.grdMain.UsesSetButtonState = true;
            this.grdMain.UpdatingRecord += new USSoft.Data.TGridView.UpdatingRecordEventHandler(this.grdMain_UpdatingRecord);
            this.grdMain.OnGridToolBarClick += new USSoft.Data.TGridView.OnGridToolBarClickEventHandler(this.grdMain_OnGridToolBarClick);
            this.grdMain.RowChanged += new USSoft.Data.TGridView.RowChangedEventHandler(this.grdMain_RowChanged);
            this.grdMain.OnGridDragEnter += new USSoft.Data.TGridView.OnGridDragEnterEventHandler(this.grdMain_OnGridDragEnter);
            this.grdMain.LoadingRow += new USSoft.Data.TGridView.LoadingRowEventHandler(this.grdMain_LoadingRow);
            this.grdMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdMain_DragDrop);
            this.grdMain.DragOver += new System.Windows.Forms.DragEventHandler(this.grdMain_DragOver);
            // 
            // pPreView
            // 
            this.pPreView.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pPreView.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pPreView.FloatingLocation = new System.Drawing.Point(628, 362);
            this.pPreView.InnerContainer = this.pPreViewContainer;
            this.pPreView.Location = new System.Drawing.Point(0, 341);
            this.pPreView.Name = "pPreView";
            this.pPreView.Size = new System.Drawing.Size(1009, 174);
            this.pPreView.TabIndex = 4;
            this.pPreView.Text = "pPreView";
            // 
            // pPreViewContainer
            // 
            this.pPreViewContainer.Controls.Add(this.wb);
            this.pPreViewContainer.Location = new System.Drawing.Point(1, 1);
            this.pPreViewContainer.Name = "pPreViewContainer";
            this.pPreViewContainer.Size = new System.Drawing.Size(1007, 172);
            this.pPreViewContainer.TabIndex = 0;
            // 
            // wb
            // 
            this.wb.AllowWebBrowserDrop = false;
            this.wb.CausesValidation = false;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(1007, 172);
            this.wb.TabIndex = 6;
            this.wb.TabStop = false;
            this.wb.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // mnuNew
            // 
            this.mnuNew.Key = "mnuNew";
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Text = "Neu";
            // 
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 521);
            this.Controls.Add(this.UiPanelGroup3);
            this.Controls.Add(this.UiPanelGroup1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDocuments";
            this.Text = "Dokumente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocuments_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDocuments_FormClosed);
            this.Load += new System.EventHandler(this.frmDocuments_Load);
            this.Shown += new System.EventHandler(this.frmDocuments_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiPanelGroup1)).EndInit();
            this.UiPanelGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanelFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UiPanelGroup3)).EndInit();
            this.UiPanelGroup3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pPreView)).EndInit();
            this.pPreView.ResumeLayout(false);
            this.pPreViewContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal Janus.Windows.Common.VisualStyleManager vsm;
        internal Janus.Windows.UI.Dock.UIPanelManager pmMain;
        internal Janus.Windows.UI.Dock.UIPanel uiPanel0;
        internal Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        internal Janus.Windows.UI.Dock.UIPanel uiPanel1;
        internal Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        internal Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        internal Janus.Windows.UI.CommandBars.UICommandManager cmMain;
        internal Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        internal Janus.Windows.UI.CommandBars.UIContextMenu popWindow;
        internal Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        internal Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        internal USSoft.Data.TTreeView trv;
        internal USSoft.Data.TGridView grdMain;
        internal Janus.Windows.UI.Dock.UIPanelGroup UiPanelGroup1;
        internal Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanelFolder;
        internal Janus.Windows.UI.Dock.UIPanel uiPanel2;
        internal Janus.Windows.UI.CommandBars.UICommand mnuNew;
        internal Janus.Windows.UI.CommandBars.UICommandBar UiCommandBar1;
        internal Janus.Windows.UI.CommandBars.UICommand mnuNew1;
        internal Janus.Windows.UI.CommandBars.UICommand mnuEdit1;
        internal Janus.Windows.UI.CommandBars.UICommand mnuDelete1;
        internal Janus.Windows.UI.CommandBars.UICommand mnuNew2;
        internal Janus.Windows.UI.CommandBars.UICommand mnuEdit;
        internal Janus.Windows.UI.CommandBars.UICommand mnuDelete;
        internal Janus.Windows.UI.CommandBars.UIContextMenu popMain;
        internal Janus.Windows.UI.CommandBars.UICommand mnuNew3;
        internal Janus.Windows.UI.CommandBars.UICommand mnuEdit2;
        internal Janus.Windows.UI.CommandBars.UICommand mnuDelete2;
        internal Janus.Windows.UI.Dock.UIPanel pPreView;
        internal Janus.Windows.UI.Dock.UIPanelInnerContainer pPreViewContainer;
        internal Janus.Windows.UI.Dock.UIPanelGroup UiPanelGroup3;
        internal System.Windows.Forms.ImageList img16;
        internal System.Windows.Forms.WebBrowser wb;
    }
}