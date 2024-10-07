using System;
using System.Linq;
using Janus.Windows.GridEX;
using System.Windows.Forms;
using FamilyApp.Classes;

namespace FamilyApp.UI.StundenHG8
{
    public partial class frmStundenEingabe : Form
    {
        public frmStundenEingabe()
        {
            InitializeComponent();
        }

        private void frmStundenEingabe_Load(object sender, EventArgs e)
        {
            UIViewSample.SetVisualStyle(this);
            RefreshGrid();
            UIViewSample.GetGridFormatStyle(grdMain.Grid.RootTable, this.Name);
            UIViewSample.SetDefaultGridView(grdMain.Grid);
            grdMain.Grid.AllowEdit = InheritableBoolean.True;
            grdMain.NodeName = this.Name;
            grdMain.ExportExcelFileName = "StundenEingabeHG8.xls";
            grdMain.cPro = Program.cPRO;
        }

        private void frmStundenEingabe_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIViewSample.SetGridFormatStyle(grdMain.Grid.RootTable, this.Name);
        }
        private void RefreshGrid()
        {

            grdMain.KeyField = "ID";
            grdMain.Grid.SetDataBinding(FamilyApp.Repositories.Stunden.StundenDataView.StundenHG8DataTable(FamilyAppApplication.DataFactory), "FamilyApp");
            grdMain.Grid.RetrieveStructure();
            {
                var withBlock = grdMain.Grid.RootTable;
                withBlock.RowHeaders = InheritableBoolean.True;
                withBlock.Columns["ID"].Visible = false;
                withBlock.RowHeight = 21;
                withBlock.Columns["Datum"].TextAlignment = TextAlignment.Center;
                withBlock.Columns["Datum"].HeaderAlignment = TextAlignment.Center;
                withBlock.Columns["Datum"].Width = 75;

                withBlock.Columns["Stunden"].TextAlignment = TextAlignment.Far;
                withBlock.Columns["Stunden"].HeaderAlignment = TextAlignment.Center;
                withBlock.Columns["Stunden"].Width = 55;
                withBlock.Columns["Stunden"].FormatString = "###,0.00"; // "D"
                withBlock.Columns["Stunden"].AggregateFunction = AggregateFunction.Sum;

                withBlock.Columns["UserID"].HasValueList = true;
                withBlock.Columns["UserID"].ValueList.Clear();
                withBlock.Columns["UserID"].Caption = "Name";
                withBlock.Columns["UserID"].EditType = EditType.DropDownList;
                foreach (var B in  FamilyAppApplication.DataFactory.Bearbeiter.ToList())
                    withBlock.Columns["UserID"].ValueList.Add(B.ID, B.Name);

                withBlock.Columns["Taetigkeit"].Caption = "Tätigkeit";
                withBlock.Columns["Taetigkeit"].Width = grdMain.Parent.Width - (withBlock.Columns[0].Width + withBlock.Columns[1].Width + withBlock.Columns[2].Width + withBlock.Columns[3].Width);
                withBlock.TotalRow = InheritableBoolean.True;
            }

        }

        private void grdMain_UpdatingRecord(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
            var S = FamilyAppApplication.DataFactory.ArbeitsStunden.FirstOrDefault(x => x.ID == ID);

            if (S is null)
            {
                return;
            }
            S.Stunden = (decimal)grdMain.Grid.CurrentRow.Cells["Stunden"].Value;
            S.Taetigkeit = grdMain.Grid.CurrentRow.Cells["Taetigkeit"].Value.ToString();
            S.Datum = (DateTime)grdMain.Grid.CurrentRow.Cells["Datum"].Value;
            S.UserID = (Int32)grdMain.Grid.CurrentRow.Cells["UserID"].Value;

            FamilyAppApplication.DataFactory.SaveChanges();
        }

        private void frmStundenEingabe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                StundenEingabe();
            }
        }

        private void grdMain_OnGridToolBarClick(string Key, object IndexValue, bool IsDoubleClick)
        {

            switch (Key ?? "")
            {
                case "mnuNew":
                    {
                        StundenEingabe();
                        break;
                    }
                case "mnuDelete":
                    {
                        if (Program.cPRO.DeleteMsg("Datensatz wirklich unwiederruflich löschen?", "Löschen"))
                        {
                            int ID = (int)grdMain.Grid.CurrentRow.Cells["ID"].Value;
                           FamilyAppApplication.DataFactory.ArbeitsStunden.Remove(FamilyAppApplication.DataFactory.ArbeitsStunden.FirstOrDefault(x => x.ID == ID));
                            FamilyAppApplication.DataFactory.SaveChanges();
                            RefreshGrid();
                        }

                        break;
                    }
            }
        }
        private void StundenEingabe()
        {

            using (var F = new frmStundenEingabeEdit())
            {
                F.Datum = (DateTime)grdMain.Grid.CurrentRow.Cells["Datum"].Value;
                F.Icon = this.Icon;
                if (F.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }

        }
    }
}
