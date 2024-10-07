using System;
using System.Collections.Generic;
using FamilyApp.Repositories.Documents;
using FamilyApp.Repositories.Registry;
using Janus.Windows.GridEX;
using USSoft.Data;
using System.Windows.Forms;
using FamilyApp.Data;
using FamilyApp.Classes;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop;

namespace FamilyApp.UI.Documents
{
    public partial class frmDocuments : Form
    {
        public enum TExcel
        {
            xlTypePDF = 0,
            xlQualityStandard = 0,
            xlQualityMinimum = 1
        }

        private const byte CtrlMask = 8;
        public string TmpPath = Path.Combine(Path.GetTempPath(), @"USSoft\TEMP\FamilyApp\");
        private bool IsStarted = false;
        private string fNodeName;
        private IEnumerable<DM_Folders> myFolders;
        private bool _isDrag;
        private TNode _currentNode;
        private string TempFileName;
        private Microsoft.Office.Interop.Word.Application m_Word = null;
        private Microsoft.Office.Interop.Excel.Application m_Excel = null;
        public frmDocuments()
        {
            InitializeComponent();
        }

        private void frmDocuments_Load(object sender, EventArgs e)
        {

            UIViewSample.SetVisualStyle(this);
            grdMain.NodeName = this.Name;
            grdMain.ExportExcelFileName = "Dokumente.xls";
            cmMain.SetContextMenu(trv.Controls[0], popMain);
            pPreView.Closed = true;
            this.Update();

            UIViewSample.GetPanelFormatStyle(pmMain, this.Name);
            grdMain.cPro = Program.cPRO;

            LoadTreeView();
            IsStarted = true;
            try
            {
                string sNode = Program.DBReg.ReadString(Usage.User, this.Name, "LastNode", this.Name);
                trv.FindNode(sNode);
            }
            catch { }

        }
        private void frmDocuments_Shown(object sender, EventArgs e)
        {
            uiPanelFolder.Height = 28;
            uiPanel2.Height = 30;
        }
        private void frmDocuments_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            pPreView.Closed = true;
            if (IsStarted & !(grdMain.Grid.Tag == null))
            {
                UIViewSample.SetGridFormatStyle(grdMain.Grid.RootTable, grdMain.Grid.Tag.ToString());
            }

            if (!(Program.DBReg == null))
            {
                if (!(trv.Node == null))
                {
                    Program.DBReg.SaveSetting(Usage.User, this.Name, "LastNode", trv.Node.Key);
                }

                UIViewSample.SetPanelFormatStyle(pmMain, this.Name);
            }

            if (!(m_Word == null))
            {
                m_Word.Quit();
                m_Word = null;
            }

            if (!(m_Excel == null))
            {
                m_Excel.Quit();
                m_Excel = null;
            }

            if (!(wb == null))
            {
                wb.Dispose();
                wb = null;
            }

            this.Cursor = Cursors.Default;

        }
        private void frmDocuments_FormClosed(object sender, FormClosedEventArgs e)
        {

            try
            {
                foreach (var f in Directory.GetFiles(TmpPath, "*.*"))
                    File.Delete(f);
                Directory.Delete(TmpPath, true);
            }
            catch { }
        }
        private void cmMain_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            string sNode = "";

            switch (e.Command.Key)
            {
                case "mnuNew":
                    {
                        sNode = Program.cPRO.InputBoxExt("Neue Struktur", "", "Neuer Eintrag", default, 400);
                        if (!string.IsNullOrEmpty(sNode))
                        {
                            var NewNode = FamilyAppApplication.DataFactory.DM_Folders.Add(new DM_Folders()
                            {
                                FolderName = sNode,
                                ParentID = trv.Node.Key.ToInteger(),
                                FLAG = 0
                            });
                            FamilyAppApplication.DataFactory.SaveChanges();
                            sNode = NewNode.ID.ToString();
                        }

                        break;
                    }
                case "mnuEdit":
                    {
                        sNode = Program.cPRO.InputBoxExt("Struktur bearbeiten", trv.Node.NodeName, "Eintrag bearbeiten", default, 400);
                        if (!string.IsNullOrEmpty(sNode))
                        {
                            var iKey = trv.Node.Key.ToInteger();
                            var DataNode = FamilyAppApplication.DataFactory.DM_Folders.Where(x => x.ID == iKey).First();
                            DataNode.FolderName = sNode;
                            sNode = DataNode.ID.ToString();
                        }

                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg("Datensatz wirklich löschen?"))
                        {
                            var iKey = trv.Node.Key.ToInteger();
                            var DataNode = FamilyAppApplication.DataFactory.DM_Folders.Where(x => x.ID == iKey).First();

                            if (DataNode.ParentID.HasValue)
                            {
                                sNode = DataNode.ParentID.ToString();
                            }
                            FamilyAppApplication.DataFactory.DM_Folders.Remove(DataNode);
                        }

                        break;
                    }
            }

            if (string.IsNullOrEmpty(sNode))
            {
                return;
            }

            FamilyAppApplication.DataFactory.SaveChanges();
            LoadTreeView();
            trv.FindNode(sNode);
        }
        public void LoadTreeView()
        {

            TNode ParentNode;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                myFolders = FamilyAppApplication.DataFactory.DM_Folders;
                trv.BeginEdit();
                var DataNode = myFolders.Where(x => x.ParentID.HasValue == false).First();
                ParentNode = trv.AddNode(DataNode.ID.ToString(), DataNode.FolderName, 4, true);
                myFolders = myFolders.Where(x => x.ParentID.HasValue == true).OrderBy(o => o.FolderName).ToList();
                AddChildNode(ParentNode);
                trv.EndEdit();
            }
            catch (Exception ex)
            {
                Program.cPRO.ErrorException(ex, "LoadTreeView", this.Name);
            }

        }
        private void AddChildNode(TNode ParentNode)
        {

            foreach (var n in myFolders)
            {
                if (((dynamic)n).ParentID.ToString() == ParentNode.Key)
                {
                    var Node = ParentNode.AddChildNode(n.ID.ToString(), n.FolderName, 5);
                    AddChildNode(Node);
                }
            }

        }
        private void GetChildNodes(TNode ParentNode, List<string> myIDList)
        {

            foreach (TNode n in ParentNode.Nodes)
            {
                myIDList.Add(n.Key);
                if (n.HasChildren)
                {
                    GetChildNodes(n, myIDList);
                }
            }

        }
        private void trv_NodeClick(USSoft.Data.TNode Node, EventArgs e)
        {
            if (!(Node == null) & IsStarted)
            {
                fNodeName = Node.Key;
                if (!_isDrag)
                {
                    _currentNode = Node;
                }
                if (!grdMain.IsDrag)
                {
                    var myIDList = new List<string>();
                    myIDList.Add(Node.Key);
                    GetChildNodes(Node, myIDList);

                    // Node.NodeInfoText = " IN(" & String.Join(",", myIDList) & ")"
                    Node.NodeInfoText = " IN(" + Node.Key + ")";

                    RefreshGrid(Node);

                    if (grdMain.Grid.RecordCount == 0 && wb  != null)
                    {

                        wb.Dispose();
                        wb = null;
                    }
                }

            }
        }
        private void trv_DragOver(TNode Node, GridEX sender, DragEventArgs e)
        {

            try
            {
                if (e.Data.GetDataPresent("Janus.Windows.GridEX.GridEXRow") | e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                {

                    if (e.Data.GetDataPresent("Janus.Windows.GridEX.GridEXRow"))
                    {
                        _isDrag = true; // vwGrid.IsDrag
                    }

                    TNode DNode;
                    Point pt;
                    pt = ((TTreeView)sender.Parent).PointToClient(new Point(e.X, e.Y));
                    DNode = ((TTreeView)sender.Parent).GetNodeAt(pt);

                    if (DNode  != null)
                    {
                        switch (DNode.Key)
                        {
                            case "ROOT":
                            case "3":
                                {
                                    if (e.Data.GetDataPresent("Janus.Windows.GridEX.GridEXRow"))
                                    {
                                        e.Effect = DragDropEffects.None;
                                    }
                                    else
                                    {
                                        e.Effect = DragDropEffects.All;
                                        trv.Select();
                                        trv.Node = DNode;
                                    }

                                    break;
                                }

                            default:
                                {
                                    if (DNode.Key != _currentNode.Key)
                                    {

                                        trv.Select();
                                        trv.Node = DNode;
                                        trv.ExpandNode();

                                        if ((e.KeyState & CtrlMask) == CtrlMask)
                                        {
                                            e.Effect = DragDropEffects.Copy;
                                        }
                                        else
                                        {
                                            // e.Effect = DragDropEffects.Move
                                            e.Effect = DragDropEffects.All;
                                        }
                                    }
                                    else
                                    {
                                        e.Effect = DragDropEffects.None;
                                    }

                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    grdMain.IsDrag = false;
                    _isDrag = false;
                }
            }

            catch (Exception ex)
            {
                grdMain.IsDrag = false;
                _isDrag = false;
                Program.ErrorException(ex, "trv.DragOver", this.Name);
            }


        }
        private void trv_DragDrop(TNode Node, GridEX sender, DragEventArgs e)
        {

            try
            {

                if (e.Data.GetDataPresent("Janus.Windows.GridEX.GridEXRow") & grdMain.IsDrag)
                {
                    _isDrag = grdMain.IsDrag;
                    if (trv.Node.Key == _currentNode.Key)
                    {
                        Program.cPRO.MsgBoxExt("Quell und Ziel sind indentisch!", USSoft.Data.TMsgBox.MsgBoxIcon.mbiError, FindForm().Text);
                        trv.Node = _currentNode;
                    }
                    else
                    {
                        grdMain.IsDrag = false;
                        _isDrag = false;
                        for (int i = 0, loopTo = grdMain.Grid.SelectedItems.Count - 1; i <= loopTo; i++)
                        {
                            GridEXRow Row = grdMain.Grid.SelectedItems[i].GetRow();
                            if (Row.RowType == RowType.Record)
                            {
                                int ID = (int)Row.Cells["ID"].Value;
                                var DataNode = FamilyAppApplication.DataFactory.DM_Documents.FirstOrDefault(x => x.ID == ID);
                                DataNode.FolderID = trv.Node.Key.ToInteger();
                            }
                        }
                        FamilyAppApplication.DataFactory.SaveChanges();
                        RefreshGrid(Node);
                    }
                    grdMain.IsDrag = false;
                    _isDrag = false;
                }
                else if (e.Data.GetDataPresent("Janus.Windows.GridEX.GridEXRow"))
                {
                    _isDrag = false;

                    if (HasParentToChildCopy(_currentNode))
                    {
                        return;
                    }
                    var iKey = _currentNode.Key.ToInteger();
                    var DataNode = FamilyAppApplication.DataFactory.DM_Folders.Where(x => x.ID == iKey).First();
                    DataNode.ParentID = Node.Key.ToInteger();
                    FamilyAppApplication.DataFactory.SaveChanges();

                    LoadTreeView();
                    trv.ExpandAll();
                    trv.Node = _currentNode;
                }
                else
                {
                    grdMain.IsDrag = false;
                    _isDrag = false;
                }
            }

            catch (Exception ex)
            {
                grdMain.IsDrag = false;
                _isDrag = false;
                Program.ErrorException(ex, "trv.DragDrop", this.Name);
            }
        }
        public bool HasParentToChildCopy(TNode ANode)
        {
            bool HasParentToChildCopyRet = default;

            HasParentToChildCopyRet = false;
            var Node = ANode;
            while (!(Node == null))
            {
                if (Node.Key == _currentNode.Key)
                {
                    Program.cPRO.MsgBoxExt("Ein Element kann nicht in eine ihr selbst untegeordnete Gruppe verschoben werden!", USSoft.Data.TMsgBox.MsgBoxIcon.mbiInformation, FindForm().Text);
                    trv.Node = _currentNode;
                    _isDrag = false;
                    return true;
                }
                else
                {
                    Node = Node.ParentNode;
                }
            }

            return HasParentToChildCopyRet;

        }
        private string GetParentNodeKey()
        {

            TNode N = trv.Node;

            if (!N.HasParent)
            {
                return N.Key;
            }

            while (N.HasParent)
            {
                N = N.ParentNode;
                if (N.ImageIndex == 4)
                {
                    return N.Key;
                }
            }

            return trv.Node.Key;

        }
        private void RefreshGrid(USSoft.Data.TNode Node)
        {
            grdMain.KeyField = "ID";

            grdMain.Grid.Tag = this.Name;
            if (grdMain.Grid.RootTable  != null)
            {
                UIViewSample.SetGridFormatStyle(grdMain.Grid.RootTable, this.Name);
            }

            Program.cMain.RebindDataGrid(grdMain.Grid, "Tools", DocumentView.DocumentsDataTable(FamilyAppApplication.DataFactory, new Repositories.FilterArgs() { InStatement = Node.NodeInfoText }), grdMain.cmMain.Commands["mnuColumns"], uiColumn_CommandClick);
            grdMain.Grid.AllowEdit = InheritableBoolean.True;

        }
        private void uiColumn_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            e.Command.IsChecked = !e.Command.IsChecked;
            grdMain.Grid.RootTable.Columns[e.Command.Key].Visible = e.Command.IsChecked;
        }
        private void grdMain_RowChanged(Janus.Windows.GridEX.GridEXRow Row, EventArgs e)
        {

            if (Row is null || Row.RowType != RowType.Record)
            {
                return;
            }

            // Dim ID = CType(grdMain.Grid.CurrentRow.Cells("ID").Value, Integer)
            // Dim D = FamilyAppApplication.DataFactory.DM_Documents.FirstOrDefault(Function(x) x.ID = ID)

            ShowPreView();


        }
        private void grdMain_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (trv.Node == null || trv.Node.ParentNode is null)
                {
                    return;
                }

                if (e.Data.GetDataPresent(DataFormats.FileDrop) | e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch { }
        }
        private void grdMain_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (!(trv.Node == null))
                {
                    string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string sFileName in draggedFiles)
                        InsertDocument(sFileName, true);
                }
                e.Effect = DragDropEffects.None;
            }
            else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                string sFileName = TJanusGrid.HandleFileDropsFileGroupDescriptor(e);
                if (!string.IsNullOrEmpty(sFileName))
                {
                    if (Convert.ToBoolean(InsertDocument(sFileName, true)))
                    {
                        if (File.Exists(sFileName))
                        {
                            File.Delete(sFileName);
                        }
                    }


                }
                e.Effect = DragDropEffects.None;
            }

        }
        private void grdMain_OnGridDragEnter(object sender, bool IsDragReday)
        {
            if (_isDrag)
            {
                trv.Node = _currentNode;
                if (IsDragReday)
                {
                    _isDrag = false;
                    grdMain.IsDrag = false;
                }
            }
        }
        private void grdMain_OnGridToolBarClick(string Key, object IndexValue, bool IsDoubleClick)
        {
            switch (Key ?? "")
            {
                case "mnuNew":
                    {                        
                        string sFileName = "";
                        Boolean IsFromSearchDoc;                        

                        using (var F = new frmNewDocument())
                        {
                            F.RefForm = this;
                            F.Icon = this.Icon;
                            if (F.ShowDialog(this) != DialogResult.OK)
                                return;

                            sFileName = F.FileName;
                            IsFromSearchDoc = F.IsFromSearchDoc;
                        }

                        InsertDocument(sFileName, IsFromSearchDoc);
                        break;
                    }

                case "mnuEdit":
                    {
                        OpenDocument();
                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg("Datensatz wirklich löschen?"))
                        {
                            var doc = GetDoc();

                            if (!(doc == null))
                            {
                                FamilyAppApplication.DataFactory.DM_Documents.Remove(doc);
                                FamilyAppApplication.DataFactory.SaveChanges();
                                grdMain.Grid.CurrentRow.Delete();
                            }
                        }

                        break;
                    }
                case "mnuPageView":
                    {
                        grdMain.cmMain.Commands["mnuPageView"].IsChecked = !grdMain.cmMain.Commands["mnuPageView"].IsChecked;
                        pPreView.Closed = !grdMain.cmMain.Commands["mnuPageView"].IsChecked;
                        ShowPreView();
                        break;
                    }
            }
        }

        private Boolean InsertDocument(string FileName, bool IsFromSearchDoc)
        {

            if (!string.IsNullOrEmpty(FileName) && File.Exists(FileName))
            {
                byte[] fileBytes = File.ReadAllBytes(FileName);
                var MyFI = new FileInfo(FileName);

                var NewDoc = FamilyAppApplication.DataFactory.DM_Documents.Add(new DM_Documents()
                {
                    Description = MyFI.Name,
                    Document = fileBytes,
                    DocumentType = MyFI.Extension,
                    FolderID = Convert.ToInt32(trv.Node.Key),
                    FLAG = 0,
                    DateCreated = MyFI.CreationTime,
                    DateChanged = MyFI.LastAccessTime,
                    FileSize = MyFI.Length
                });

                FamilyAppApplication.DataFactory.SaveChanges();

                UpdateDisplayIcon(FileName);

                RefreshGrid(trv.Node);

                Program.cPRO.FindRecord(grdMain.Grid, "ID", NewDoc.ID);

                if (!IsFromSearchDoc)
                {
                    File.Delete(FileName);
                    System.Threading.Thread.Sleep(2000);
                    OpenDocument();
                }
                return true;
            }

            return false;

        }
        public bool FileInUse(FileInfo AFileInfo)
        {

            try
            {
                var fs = AFileInfo.Open(FileMode.Append, FileAccess.Write);
                fs.Close();
                return false;
            }

            catch {return true;}

        }
        public bool FileInUse(string AFile)
        {
            return FileInUse(Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(AFile));
        }

        private bool OpenDocument()
        {
            try
            {

                var doc = GetDoc();
                string sFileName = GetTempFileName(doc.DocumentType);
                File.WriteAllBytes(sFileName, doc.Document);

                if (!(m_Word == null))
                    m_Word.Quit();
                if (!(m_Excel == null))
                    m_Excel.Quit();
                if (!(wb == null))
                    wb.Url = null;
                m_Word = null;
                m_Excel = null;

                using (var P = new System.Diagnostics.Process())
                {
                    P.StartInfo.FileName = sFileName;
                    P.StartInfo.WorkingDirectory = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(sFileName).Directory.FullName;
                    if (!P.Start())
                    {
                        return false;
                    }
                    else
                    {
                        try
                        {
                            while (true)
                            {
                                Application.DoEvents();
                                if (P.WaitForExit(int.MaxValue))
                                {
                                    Application.UseWaitCursor = true;
                                    P.Close();
                                    doc.Document = File.ReadAllBytes(sFileName);
                                    FamilyAppApplication.DataFactory.SaveChanges();

                                    ShowPreView();

                                    if (File.Exists(sFileName))
                                    {
                                        File.Delete(sFileName);
                                    }
                                    return true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.cPRO.MsgBoxExt(ex.ToString(), TMsgBox.MsgBoxIcon.mbiError, "Fehler", Microsoft.VisualBasic.MsgBoxStyle.OkOnly);
                            return false;
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                Application.UseWaitCursor = false;
                throw ex;
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

        }
        private void ShowPreView()
        {

            if (!grdMain.cmMain.Commands["mnuPageView"].IsChecked)
            {
                return;
            }
            this.Cursor = Cursor.Current;
            pPreView.Closed = false;
            var doc = GetDoc();
            string sPath = GetTempFileName(doc.DocumentType);

            File.WriteAllBytes(sPath, doc.Document);

            switch (doc.DocumentType.ToLower())
            {
                case ".docx":
                case ".doc":
                    {
                        if (!ConvertWordToPDF(sPath, false))
                        {
                            return;
                        }
                        sPath = TempFileName;
                        break;
                    }
                case ".xlsx":
                case ".xls":
                    {
                        if (!ConvertExcelToPDF(sPath, false))
                        {
                            return;
                        }
                        sPath = TempFileName;
                        break;
                    }
            }

            if (wb is null)
            {
                wb = new WebBrowser();
            }

            var siteUri = new Uri(sPath);
            string s = "";

            if (!(wb.Url == null))
            {
                s = wb.Url.AbsoluteUri.ToString();
            }
            if ((siteUri.AbsoluteUri.ToString() ?? "") != (s ?? ""))
            {
                wb.Visible = true;
                wb.Navigate(siteUri);
                wb.IsWebBrowserContextMenuEnabled = true;
                wb.Parent = pPreViewContainer;
                wb.Dock = DockStyle.Fill;
            }
        }
        private DM_Documents GetDoc()
        {
            if (grdMain.Grid.CurrentRow is null)
            {
                // ÄExit Function
                return default;
            }
            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            return FamilyAppApplication.DataFactory.DM_Documents.FirstOrDefault(x => x.ID == ID);
        }
        private string CreaeteFileGuid(object AGuid)
        {
            string s = AGuid.ToString();
            s = s.Replace("-", string.Empty);

            return Application.ProductName + "_" + s.ToUpper();
        }
        public string GetTempFileName(string AFileExtract)
        {

            string sPath = TmpPath; // IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "USSoft\TEMP\")

            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
            sPath = sPath + CreaeteFileGuid(Guid.NewGuid()) + AFileExtract;

            TempFileName = sPath;
            return sPath;

        }
        private bool ConvertWordToPDF(string AFileNameToExport, bool AOpenAfterExport)
        {
            try
            {
                if (m_Word == null)
                    m_Word = new Microsoft.Office.Interop.Word.Application();

                string sFileName = AFileNameToExport;
                var FI = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(sFileName);
                m_Word.Documents.Open(FileName: sFileName);
                sFileName = sFileName.Replace(FI.Extension, ".pdf");
                TempFileName = sFileName;
                m_Word.ChangeFileOpenDirectory(FI.DirectoryName);
                m_Word.ActiveDocument.ExportAsFixedFormat(OutputFileName: sFileName, ExportFormat: Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, OpenAfterExport: AOpenAfterExport, OptimizeFor:  Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Range: Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, From: 1, To: 1, Item: Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, IncludeDocProps: true, KeepIRM: true, CreateBookmarks: Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: false);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!(m_Word == null))
                {
                    m_Word.ActiveDocument.Close();
                }

                this.Cursor = Cursors.Default;
            }

        }
        private bool ConvertExcelToPDF(string AFileNameToExport, bool AOpenAfterExport)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {

                if (m_Excel == null)
                {
                    m_Excel = new Microsoft.Office.Interop.Excel.Application();
                }

                string sFileName = AFileNameToExport;
                var FI = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(sFileName);
                m_Excel.Workbooks.Open(Filename: sFileName);
                sFileName = sFileName.Replace(FI.Extension, ".pdf");
                TempFileName = sFileName;

                m_Excel.ActiveWorkbook.ExportAsFixedFormat( Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, Filename: sFileName, Quality: TExcel.xlQualityMinimum, IncludeDocProperties: true, IgnorePrintAreas: false, OpenAfterPublish: false);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!(m_Excel == null))
                {
                    m_Excel.Workbooks.Close();
                }
                this.Cursor = Cursors.Default;
            }

        }
        private void grdMain_UpdatingRecord(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var d = GetDoc();
            if (d is null)
                return;
            
            if (!(grdMain.Grid.CurrentRow.Cells["Description"].Value is DBNull))
                d.Description = grdMain.Grid.CurrentRow.Cells["Description"].Value.ToString();

            FamilyAppApplication.DataFactory.SaveChanges();
        }
        private void grdMain_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record & !(e.Row.Cells["ID"].Value == null))
            {
                SetFileIconByStream((Janus.Windows.GridEX.GridEX)sender, e.Row, "DocumentType");
            }
        }
        public string GetDocumentFileName(ref string AFileName, string AFilter, string ADefaultDir = "", string ATitle = "", bool IsImageFilter = false)
        {
            string GetDocumentFileNameRet = default;

            var dlgOpen = new System.Windows.Forms.OpenFileDialog();
            GetDocumentFileNameRet = "";
            try
            {
                string sDirName;
                // Lesen des zuletzt ausgewählten Ordner (Voreingestellt ist "Eigene Dateien")
                sDirName = Program.DBReg.ReadString(Usage.User, "OpenFileDialog", "LastDir", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                dlgOpen.FileName = string.Empty;
                dlgOpen.Filter = AFilter;

                if (IsImageFilter)
                {
                    dlgOpen.FilterIndex = Program.DBReg.ReadInteger(Usage.User, "OpenFileDialog", "LastImageFilterIndex", 1);
                }
                else
                {
                    dlgOpen.FilterIndex = Program.DBReg.ReadInteger(Usage.User, "OpenFileDialog", "LastDocumentFilterIndex", 1);
                }
                if (Microsoft.VisualBasic.FileIO.FileSystem.DirectoryExists(sDirName))
                {
                    dlgOpen.InitialDirectory = sDirName;
                }
                else
                {
                    dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var f = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(dlgOpen.FileName);
                    if (Microsoft.VisualBasic.FileIO.FileSystem.FileExists(dlgOpen.FileName))
                    {
                        // Speichen des ausgewähltem Ordner
                        Program.DBReg.SaveSetting(Usage.User, "OpenFileDialog", "LastDir", f.Directory.FullName);
                        AFileName = dlgOpen.FileName;
                        GetDocumentFileNameRet = AFileName;
                        UpdateDisplayIcon(AFileName);
                    } // FileIO.FileSystem.FileExists
                }
                else
                {
                    GetDocumentFileNameRet = "";
                } // ShowDialog
                if (IsImageFilter)
                {
                    Program.DBReg.SaveSetting(Usage.User, "OpenFileDialog", "LastImageFilterIndex", dlgOpen.FilterIndex);
                }
                else
                {
                    Program.DBReg.SaveSetting(Usage.User, "OpenFileDialog", "LastDocumentFilterIndex", dlgOpen.FilterIndex);
                }
            }
            catch (Exception ex)
            {
                Program.cPRO.ErrorException(ex, "ShowOpenFileDialog", "clsMain");
                return "";
            }
            finally
            {
                dlgOpen.Dispose();
            }

            return GetDocumentFileNameRet;

        }
        public void SetFileIconByStream(Janus.Windows.GridEX.GridEX jsGrid, Janus.Windows.GridEX.GridEXRow ARow, string AColKey)
        {
            string sFileExt = "";

            try
            {

                if (jsGrid.ImageList == null)
                {
                    var img16 = new ImageList();
                    img16 = new ImageList();
                    img16.ColorDepth = ColorDepth.Depth32Bit;
                    img16.ImageSize = new Size(16, 16);
                    jsGrid.ImageList = img16;
                }

                var tmp = ARow.Cells[AColKey].Value.ToString();
                if (tmp == "")
                    return;

                sFileExt = tmp.Substring(1).ToUpper();

                if (jsGrid.ImageList.Images.ContainsKey(sFileExt))
                    ARow.Cells["ImageExt"].ImageKey = sFileExt;
                else
                {
                    System.Drawing.Bitmap BMP;
                    BMP = GetDisplayIcon(sFileExt);
                    if (!(BMP == null))
                    {
                        jsGrid.ImageList.Images.Add(sFileExt, BMP);
                        ARow.Cells["ImageExt"].ImageKey = sFileExt;
                    }
                }
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message)
                throw ex;
            }

        }

        private static Bitmap GetDisplayIcon(string sFileExt)
        {

            var di = FamilyAppApplication.DataFactory.DM_DisplayIcons.FirstOrDefault(x => x.FileExtension == sFileExt);
            if (di  != null)
            {
                return (Bitmap)Bitmap.FromStream(new MemoryStream(di.DisplayIcon));
            }
            return default;

        }

        private void UpdateDisplayIcon(string FileName)
        {

            string[] v = FileName.Split('.');

            if (v.Length >= 2)
            {
                var dims = new MemoryStream();
                System.Drawing.Icon di = new TDocumentBridge().GetDisplayIconByFileFullName(FileName);
                var bmp = new Bitmap(di.ToBitmap(), 16, 16);
                bmp.Save(dims, System.Drawing.Imaging.ImageFormat.Png);

                di.Save(dims);
                string sFileExt = v[v.Length - 1].ToUpper();
                var D = FamilyAppApplication.DataFactory.DM_DisplayIcons.FirstOrDefault(x => x.FileExtension == sFileExt);
                if (D is null)
                {
                    FamilyAppApplication.DataFactory.DM_DisplayIcons.Add(new DM_DisplayIcons() { FileExtension = sFileExt, DisplayIcon = dims.GetBuffer() });
                }
                else
                {
                    D.DisplayIcon = dims.GetBuffer();
                }
                FamilyAppApplication.DataFactory.SaveChanges();

            }
        }

    }
}