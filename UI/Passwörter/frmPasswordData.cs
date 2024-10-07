using FamilyApp.Repositories.Password;
using FamilyApp.Repositories.Registry;
using FamilyApp.Data;
using FamilyApp.Classes;
using FamilyApp.Repositories;
using Janus.Windows.GridEX;
using USSoft.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FamilyApp.UI.Password
{
    public partial class frmPasswordData : Form
    {
        private const byte CtrlMask = 8;
        private bool IsStarted = false;
        private string fNodeName;
        private IEnumerable<PasswordTree> myPasswordFolders;
        private bool _isDrag = false;
        private TNode _currentNode;
        public frmPasswordData()
        {
            InitializeComponent();
        }

        private void frmPasswordData_Load(object sender, EventArgs e)
        {

            UIViewSample.SetVisualStyle(this);
            grdMain.NodeName = this.Name;
            grdMain.ExportExcelFileName = "Password.xls";

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
            catch{}

        }
        private void frmPasswordData_FormClosing(object sender, FormClosingEventArgs e)
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
                            var NewNode = FamilyAppApplication.DataFactory.PasswordTree.Add(new PasswordTree()
                            {
                                NodeName = sNode,
                                ParentID = trv.Node.Key.ToInteger()
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
                            var DataNode = FamilyAppApplication.DataFactory.PasswordTree.Where(x => x.ID == iKey).First();
                            DataNode.NodeName = sNode;
                            sNode = DataNode.ID.ToString();
                        }

                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg("Datensatz wirklich löschen?"))
                        {
                            var iKey = trv.Node.Key.ToInteger();
                            var DataNode = FamilyAppApplication.DataFactory.PasswordTree.Where(x => x.ID == iKey).First();

                            if (DataNode.ParentID.HasValue)
                            {
                                sNode = DataNode.ParentID.ToString();
                            }
                            FamilyAppApplication.DataFactory.PasswordTree.Remove(DataNode);
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
                myPasswordFolders = FamilyAppApplication.DataFactory.PasswordTree.Where(x => (x.ParentID.HasValue == false));
                trv.BeginEdit();
                var DataNode = myPasswordFolders.Where(x => x.ParentID.HasValue == false).First();
                ParentNode = trv.AddNode(DataNode.ID.ToString(), DataNode.NodeName, 9, true);
                myPasswordFolders = FamilyAppApplication.DataFactory.PasswordTree.Where(x => x.ParentID.HasValue == true).OrderBy(o => o.NodeName).ToList();
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

            foreach (var n in myPasswordFolders)
            {
                if (n.ParentID.ToString() == ParentNode.Key)
                {
                    var Node = ParentNode.AddChildNode(n.ID.ToString(), n.NodeName, 5);
                    AddChildNode(Node);
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

                    Node.NodeInfoText = " IN(" + string.Join(",", myIDList) + ")";

                    RefreshGrid(Node);
                }

            }
        }

        private void RefreshGrid(USSoft.Data.TNode Node)
        {
            grdMain.KeyField = "ID";

            grdMain.Grid.Tag = this.Name;
            if (grdMain.Grid.RootTable != null)
            {
               UIViewSample.SetGridFormatStyle(grdMain.Grid.RootTable, this.Name);
            }

            Program.cMain.RebindDataGrid(grdMain.Grid, this.Name, PasswordView.PasswordDataTable(FamilyAppApplication.DataFactory, new FilterArgs() { NodeKey = Node.Key }), grdMain.cmMain.Commands["mnuColumns"], uiColumn_CommandClick);
            grdMain.Grid.AllowEdit = InheritableBoolean.False;
            grdMain.SetButtonState();

        }
        private void uiColumn_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            e.Command.IsChecked = !e.Command.IsChecked;
            grdMain.Grid.RootTable.Columns[e.Command.Key].Visible = e.Command.IsChecked;
        }

        private void frmStundenEingabe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                StundenEingabe(-1);
            }
        }

        private void grdMain_OnGridToolBarClick(string Key, object IndexValue, bool IsDoubleClick)
        {

            switch (Key ?? "")
            {
                case "mnuNew":
                    {
                        StundenEingabe(-1);
                        break;
                    }
                case "mnuEdit":
                    {
                        StundenEingabe(Convert.ToInt32(IndexValue));
                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg(FamilyApp.Properties.Resources.RecordReallyDeleteIrrevocably, FamilyApp.Properties.Resources.Delete))
                        {
                            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
                            FamilyAppApplication.DataFactory.ArbeitsStunden.Remove(FamilyAppApplication.DataFactory.ArbeitsStunden.FirstOrDefault(x => x.ID == ID));
                            FamilyAppApplication.DataFactory.SaveChanges();
                            RefreshGrid(_currentNode);
                        }
                        break;
                    }
            }
        }

        private void StundenEingabe(int IndexValue)
        {

            using (var F = new FamilyApp.UI.Password.frmPasswordEdit())
            {
                F.IndexValue = IndexValue;
                F.PasswordTreeID = _currentNode.Key.ToInteger();
                F.Icon = this.Icon;
                if (F.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshGrid(_currentNode);
                    Program.cMain.FindRecord(grdMain.Grid, "ID", F.IndexValue);
                }
            }

        }
    }
}
