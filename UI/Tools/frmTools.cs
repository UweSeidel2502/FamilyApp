using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FamilyApp.Repositories;
using System.Windows.Forms;
using FamilyApp.Classes;
using FamilyApp.Data;
using Janus.Windows.GridEX;
using FamilyApp.Repositories.Registry;
using USSoft.Data;

namespace FamilyApp.UI.Tools
{
    public partial class frmTools : Form
    {
        private const byte CtrlMask = 8;
        private bool IsStarted = false;
        private string fNodeName;
        private IEnumerable<FamilyToolsTree> myToolsFolders;
        private bool _isDrag;
        private TNode _currentNode;
        public frmTools()
        {
            InitializeComponent();
        }

        private void frmTools_Load(object sender, EventArgs e)
        {

            UIViewSample.SetVisualStyle(this);
            grdMain.NodeName = this.Name;
            grdMain.ExportExcelFileName = "Tools.xls";
            cboSizeMode.Items.Add("Normal", "Normal");
            cboSizeMode.Items.Add("Stretch", "Stretch");
            cboSizeMode.Items.Add("AutoSize", "AutoSize");
            cboSizeMode.Items.Add("CenterImage", "CenterImage");
            cboSizeMode.Items.Add("Zoom", "Zoom");
            cboSizeMode.SelectedIndex = 3;
            cmMain.SetContextMenu(trv.Controls[0], popMain);

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
            catch {}

        }
        private void frmTools_Shown(object sender, EventArgs e)
        {
            uiPanelFolder.Height = 28;
            uiPanel2.Height = 30;
        }
        private void frmTools_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

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

            this.Cursor = Cursors.Default;

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
                            var NewNode = FamilyAppApplication.DataFactory.FamilyToolsTree.Add(new FamilyToolsTree()
                            {
                                Description = sNode,
                                ParentID = Convert.ToInt32(trv.Node.Key),
                                Typ = 1
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
                            var DataNode = FamilyAppApplication.DataFactory.FamilyToolsTree.Where(x => x.ID == iKey).First();
                            DataNode.Description = sNode;
                            sNode = DataNode.ID.ToString();
                        }

                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg(FamilyApp.Properties.Resources.DeleteRecord))
                        {
                            var iKey = trv.Node.Key.ToInteger();
                            var DataNode = FamilyAppApplication.DataFactory.FamilyToolsTree.Where(x => x.ID == iKey).First();

                            if (DataNode.ParentID.HasValue)
                            {
                                sNode = DataNode.ParentID.Value.ToString();
                            }
                            FamilyAppApplication.DataFactory.FamilyToolsTree.Remove(DataNode);
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
                myToolsFolders = FamilyAppApplication.DataFactory.FamilyToolsTree.Where(x => x.Typ ==  1);
                trv.BeginEdit();
                var DataNode = myToolsFolders.Where(x => x.ParentID.HasValue == false).First();
                ParentNode = trv.AddNode(DataNode.ID.ToString(), DataNode.Description, 4, true);
                myToolsFolders = myToolsFolders.Where(x => x.ParentID.HasValue == true).OrderBy(o => o.Description).ToList();
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

            foreach (FamilyToolsTree n in myToolsFolders)
            {
                if (n.ParentID.ToString() == ParentNode.Key)
                {
                    var Node = ParentNode.AddChildNode(n.ID.ToString(), n.Description, 5);
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
                pbTool.Image = null;
                if (!_isDrag)
                {
                    _currentNode = Node;
                }
                if (!grdMain.IsDrag)
                {
                    var myIDList = new List<string>();
                    myIDList.Add(Node.Key);
                    GetChildNodes(Node, myIDList);

                    Node.NodeInfoText = " IN(" + string.Join(",", myIDList) + ")";

                    RefreshGrid(Node);
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

                    if (DNode != null)
                    {
                        switch (DNode.Key)
                        {
                            case "ROOT":
                            case "1":
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
                                var DataNode =  FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);
                                DataNode.FamilyToolsTreeID = Convert.ToInt32(trv.Node.Key);
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
                    var iKey = Convert.ToInt32(_currentNode.Key);
                    var DataNode = FamilyAppApplication.DataFactory.FamilyToolsTree.Where(x => x.ID == iKey).First();
                    DataNode.ParentID = Convert.ToInt32(Node.Key);
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
                    Program.cPRO.MsgBoxExt("Ein Element kann nicht in eine ihr selbst untegeordnete Gruppe verschoben werden!", TMsgBox.MsgBoxIcon.mbiInformation, FindForm().Text);
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
            if (grdMain.Grid.RootTable != null)
            {
                UIViewSample.SetGridFormatStyle(grdMain.Grid.RootTable, this.Name);
            }

            Program.cMain.RebindDataGrid(grdMain.Grid, "Tools", FamilyApp.Repositories.ToolsView.ToolsDataTable(FamilyAppApplication.DataFactory, new Repositories.FilterArgs() { InStatement = Node.NodeInfoText }), grdMain.cmMain.Commands["mnuColumns"], uiColumn_CommandClick);

            grdMain.Grid.AllowEdit = InheritableBoolean.True;
            grdMain.Grid.TotalRow = InheritableBoolean.True;
            grdMain.Grid.TotalRowPosition = TotalRowPosition.BottomFixed;
            grdMain.Grid.RootTable.Columns["Price"].AggregateFunction = AggregateFunction.Sum;
            grdMain.Grid.RootTable.Columns["Price"].TotalFormatString = "Summe 0.00 €";

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
                cmdClipboard.Enabled = false;
                cmdDelPic.Enabled = false;
                cmdNewPic.Enabled = false;
                pbTool.Image = null;
                return;
            }

            cmdClipboard.Enabled = true;
            cmdDelPic.Enabled = true;
            cmdNewPic.Enabled = true;

            var ms = new System.IO. MemoryStream();
            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);

            if (T == null)
            {
                return;
            }

            if (T.Picture == null)
            {
                pbTool.Image = null;
                return;
            }

            if (!(DBNull.Value.Equals(T.Picture) || !(T.Picture == null)))
            {
                ms.Write(T.Picture, 0, T.Picture.Length);
                pbTool.Image = Bitmap.FromStream(ms);
            }

            txtMemo.Text = T.Description;
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
                        var sTool = Program.cPRO.InputBoxExt("Neuer Datensatz", "", "Neuer Eintrag", default, 500, 2000);
                        if (!string.IsNullOrEmpty(sTool))
                        {
                            var NewTool = FamilyAppApplication.DataFactory.Tools.Add(new  Data.Tools()
                            {
                                Description = sTool,
                                FamilyToolsTreeID = Convert.ToInt32(trv.Node.Key),
                                Price = 0,
                                Waranty = false
                            });


                            FamilyAppApplication.DataFactory.SaveChanges();
                            RefreshGrid(trv.Node);

                            Program.cPRO.FindRecord(grdMain.Grid, "ID", NewTool.ID);
                        }

                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg("Datensatz wirklich löschen?"))
                        {
                            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
                            var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);

                            if (!(T == null))
                            {
                                FamilyAppApplication.DataFactory.Tools.Remove(T);
                                FamilyAppApplication.DataFactory.SaveChanges();
                                grdMain.Grid.CurrentRow.Delete();
                            }
                        }

                        break;
                    }
            }
        }
        private void grdMain_UpdatingRecord(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);

            if (T is null)
            {
                return;
            }
            if (!(grdMain.Grid.CurrentRow.Cells["Description"].Value is DBNull))
            {
                T.Description = grdMain.Grid.CurrentRow.Cells["Description"].Value.ToString();
            }

            if (!(grdMain.Grid.CurrentRow.Cells["PurchaseDate"].Value is DBNull))
            {
                T.PurchaseDate = Convert.ToDateTime(grdMain.Grid.CurrentRow.Cells["PurchaseDate"].Value);
            }

            if (!(grdMain.Grid.CurrentRow.Cells["Price"].Value is DBNull))
            {
                T.Price = Convert.ToDecimal(grdMain.Grid.CurrentRow.Cells["Price"].Value);
            }
            if (!(grdMain.Grid.CurrentRow.Cells["Waranty"].Value is DBNull))
            {
                T.Waranty = Convert.ToBoolean(grdMain.Grid.CurrentRow.Cells["Waranty"].Value);
            }

            FamilyAppApplication.DataFactory.SaveChanges();
        }
        private void cmdNewPic_Click(object sender, EventArgs e)
        {

            if (grdMain.Grid.CurrentRow == null)
            {
                return;
            }

            var dlg = new System.Windows.Forms.OpenFileDialog();

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {

                if (string.IsNullOrEmpty(dlg.FileName))
                {
                    return;
                }

                int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
                var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);
                var ms = new System.IO.MemoryStream();
                Bitmap.FromFile(dlg.FileName).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                T.Picture = ms.GetBuffer();
                pbTool.Image = Bitmap.FromFile(dlg.FileName);
            }
        }
        private void cmdClipboard_Click(object sender, EventArgs e)
        {

            var myImg = Clipboard.GetImage();

            if (myImg == null || grdMain.Grid.CurrentRow == null || grdMain.Grid.CurrentRow.RowType != RowType.Record)
            {
                return;
            }

            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);

            var ms = new System.IO. MemoryStream();
            myImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            T.Picture = ms.GetBuffer();
            pbTool.Image = myImg;

        }
        private void cmdDelPic_Click(object sender, EventArgs e)
        {

            if (grdMain.Grid.CurrentRow == null || grdMain.Grid.CurrentRow.RowType != RowType.Record)
            {
                return;
            }

            if (Program.cPRO.DeleteMsg("Bild wirklich löschen?"))
            {
                int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
                var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);
                T.Picture = null;
                FamilyAppApplication.DataFactory.SaveChanges();
                pbTool.Image = null;
            }

        }
        private void cboSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbTool.SizeMode = (PictureBoxSizeMode)cboSizeMode.SelectedIndex;
        }
        private void txtMemo_Leave(object sender, EventArgs e)
        {
            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            var T = FamilyAppApplication.DataFactory.Tools.FirstOrDefault(x => x.ID == ID);

            if (!(T == null))
            {
                T.Description = txtMemo.Text;
                FamilyAppApplication.DataFactory.SaveChanges();
            }

        }
    }
}
