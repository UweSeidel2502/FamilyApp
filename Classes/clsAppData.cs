using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Janus.Windows;
using Janus.Windows.EditControls;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;
using Janus.Windows.Ribbon;
using Janus.Windows.Schedule;
using Janus.Windows.UI;
using Janus.Windows.UI.CommandBars;
using USSoft.Data;
using FamilyApp.Repositories;
using FamilyApp.Classes;

namespace FamilyApp
{ 

public partial class clsMain
{
    public bool FindRecord(Janus.Windows.GridEX.GridEX grid, Janus.Windows.GridEX.GridEXColumn Column, object Value)
    {
        bool FindRecordRet = default;
        FindRecordRet = false;
        if (!(grid.RootTable == null))
        {
            try
            {

                object sValue = null;
                if (!(Value == null))
                {
                    if (Column.Type.Name.ToUpper() == "GUID" & Value.GetType().Name.ToUpper() == "STRING")
                    {
                        sValue = new Guid(Value.ToString());
                    }
                    else
                    {
                        sValue = Value;
                    }
                }

                return grid.FindAll(Column, Janus.Windows.GridEX.ConditionOperator.Equal, sValue) != 0;
            }

            catch
            {
                return false;
            }
        }

        return FindRecordRet;
    }
    public bool FindRecord(Janus.Windows.GridEX.GridEX grid, string ColumnKey, object Value)
    {
        bool FindRecordRet = default;
        FindRecordRet = false;
        if (!(grid.RootTable == null))
        {
            try
            {
               Janus.Windows.GridEX.GridEXColumn C = grid.RootTable.Columns[ColumnKey];
                // FindRecord = (grid.FindAll(grid.RootTable.Columns[ColumnKey], GridEX.ConditionOperator.Equal, Value) <> 0)
                return FindRecord(grid, C, Value);
            }
            catch
            {
                return false;
            }

        }

        return FindRecordRet;
    }
    public void PrepareGridForColumnSets(Janus.Windows.GridEX.GridEX AGrid, int AColumnSetRowCount = 1, int AColumnSetHeaderLines = 1)
    {
        {
            var withBlock = AGrid.RootTable;
            withBlock.CellLayoutMode = CellLayoutMode.UseColumns;
            withBlock.ColumnSets.Clear();
            withBlock.CellLayoutMode = CellLayoutMode.UseColumnSets;
            AGrid.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            AGrid.ColumnSetNavigation = ColumnSetNavigation.Row;
            withBlock.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            withBlock.ColumnSetRowCount = AColumnSetRowCount;
            withBlock.ColumnSetHeaderLines = AColumnSetHeaderLines;
        }
    }
    public bool FillMultiDropDownList(MultiColumnCombo ADropDownList, string AValueMember, string ADisplayMember, string ASQL, object ADefaultValue)
    {
        try
        {

            // RebindGrid(ADropDownList.DropDownList, ADropDownList.Name, ASQL)
            if (!(ADefaultValue == null))
            {
                if (!FindRecord(ADropDownList.DropDownList, ADropDownList.DropDownList.Columns[AValueMember], ADefaultValue))
                {
                    ADropDownList.Value = (object)null;
                }
                else
                {
                    ADropDownList.Value = ADefaultValue;
                }
                ADropDownList.DropDownList.SortKeys.Clear();
                return true;
            }
        }
        catch (Exception ex)
        {
            Program.ErrorException(ex, "FillMultiDoropDownList", "clsMain");
        }

        return false;
        }
    public void FillComboColumn(GridEXColumn Column, string ASQL, string ADisplayMember, string AValueMember = "GUID")
    {

        var GridCombo = new GridEXDropDown();
        try
        {
            Column.EditType = EditType.MultiColumnDropDown;
            // RebindGrid(GridCombo, "GridCombo", ASQL, Nothing, Nothing)
            GridCombo.ColumnAutoResize = true;
            GridCombo.ValueMember = AValueMember;
            GridCombo.DisplayMember = ADisplayMember;
            Column.DropDown = GridCombo;
        }
        catch (Exception ex)
        {
            Program.ErrorException(ex, "FillComboColumn", "clsMain");
        }

    }

    public void FillComboColumn(GridEXColumn Column, object DataSource, string ADisplayMember, string AValueMember = "GUID")
    {

        var GridCombo = new GridEXDropDown();
        try
        {
            Column.EditType = EditType.MultiColumnDropDown;
            // RebindGrid(GridCombo, "GridCombo", ASQL, Nothing, Nothing)
            GridCombo.ColumnAutoResize = true;
            GridCombo.ValueMember = AValueMember;
            GridCombo.DisplayMember = ADisplayMember;
            GridCombo.DataSource = DataSource;
            Column.DropDown = GridCombo;
        }
        catch (Exception ex)
        {
            Program.ErrorException(ex, "FillComboColumn", "clsMain");
        }

    }

    public object GetDataSourceBaseListType(object dataSource)
    {

        string typeName = dataSource.GetType().FullName;
        typeName = typeName.Substring(typeName.IndexOf("[") + 2).Replace("]", "");

        try
        {
            return Activator.CreateInstance(Type.GetType(typeName));
        }
        catch
        {
            return null;
        }

    }
    public bool RebindDataGrid(GridEX grid, string dataMemberName, object dataSource)
    {
        return RebindDataGrid(grid, dataMemberName, dataSource, default, default);
    }
    public bool RebindDataGrid(GridEX grid, string dataMemberName, object dataSource, UICommand cmdColumns = default, Janus.Windows.UI.CommandBars.CommandEventHandler uicClick = default)
    {
        bool RebindDataGridRet = default;
        RebindDataGridRet = false;
        try
        {
            List<NameInfo> fieldList = null;

            if (!(dataSource is DataTable))
            {
                fieldList = GetFields(GetDataSourceBaseListType(dataSource));
            }
            else
            {
                fieldList = new List<NameInfo>();
                foreach (DataColumn dataColumn in ((DataTable)dataSource).Columns)
                    fieldList.Add(new NameInfo(dataColumn, dataColumn.ColumnName));
            }

            string currentDataMemberName = "";
            dataMemberName = dataMemberName.Replace(".", "");


            if (grid.BoundMode == BoundMode.Bound)
            {

                if (dataMemberName == "ROOT")
                {
                    return false;
                }

                if (!string.IsNullOrEmpty(grid.DataMember))
                {
                    currentDataMemberName = grid.DataMember;
                }

                if (currentDataMemberName != grid.DataMember)
                    grid.ClearStructure();

                grid.SetDataBinding(dataSource, dataMemberName);
                grid.Hierarchical = false;
                grid.RetrieveStructure();

                if (string.IsNullOrEmpty(grid.DataMember))
                {
                    grid.DataMember = dataMemberName;
                }

                if (grid.RootTable != null)
                {
                    grid.RootTable.PreviewRow = false;
                    grid.RootTable.PreviewRowMember = "";

                    if (!(grid.Tag == null))
                    {
                        if (!UIViewSample.GetGridFormatStyle(grid.RootTable, grid.Tag.ToString()))
                        {
                            grid.Hierarchical = false;
                        }
                        else
                        {
                            UIViewSample.GridEXBuiltInText(grid);
                        }
                    }

                    grid.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges;
                    var janusColumn = new GridEXColumn();

                    foreach (GridEXColumn currentJanusColumn in grid.RootTable.Columns)
                    {
                        janusColumn = currentJanusColumn;
                        if (janusColumn.DataTypeCode == TypeCode.Object)
                        {
                            SetColumnDefault(janusColumn);
                        }
                    }

                    if (fieldList == null && fieldList.Any())
                    {
                        foreach (var @field in fieldList)
                        {
                            if (!grid.RootTable.Columns.Contains(@field.Name))
                            {

                                if (grid.Tag.ToString().StartsWith("Statistic."))
                                {
                                    janusColumn = new GridEXColumn();
                                    janusColumn.Key = @field.Name;
                                    janusColumn.Caption = @field.Name;
                                    janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
                                    janusColumn.DataMember = @field.Name;
                                    grid.RootTable.Columns.Insert(0, janusColumn);
                                    SetColumnDefault(janusColumn);
                                }
                                else
                                {
                                    janusColumn = grid.RootTable.Columns.Add(@field.Name);
                                }

                                janusColumn.Visible = true;
                            }
                            else
                            {
                                janusColumn = grid.RootTable.Columns[@field.Name];
                            }

                            SetColumnDefault(janusColumn);
                        }
                    }
                    else
                    {
                        SetColumnDefault(grid.RootTable);
                    }
                }
                else if (!(grid.Tag == null))
                {
                    if (!UIViewSample.GetGridFormatStyle(grid.RootTable, grid.Tag.ToString()))
                    {
                        grid.Hierarchical = false;
                    }
                    else
                    {
                        UIViewSample.GridEXBuiltInText(grid);
                    }
                }

                var columnList = new List<string>();

                if (grid.RowCount > 0)
                    grid.Row = 0;

                if (cmdColumns != null)
                {

                    cmdColumns.Commands.Clear();
                    foreach (GridEXColumn column in grid.RootTable.Columns)
                    {

                        if (grid.BoundMode == BoundMode.Bound)
                        {
                            if (fieldList != null)
                            {
                                if (!fieldList.Where(f => f.Name == column.Key).Any())
                                {
                                    columnList.Add(column.Key);
                                }
                            }
                        }

                        CheckColumnsByCommandBar(column, cmdColumns, uicClick);
                    }

                }

                foreach (var columnKey in columnList)
                    grid.RootTable.Columns.Remove(columnKey);

                UIViewSample.SetDefaultGridView(grid);

                return true;
            }
        }

        catch (Exception ex)
        {
            Program.ErrorException(ex, "RebindGrid." + dataMemberName, "clsMain");
        }

        return RebindDataGridRet;
    }

    public List<NameInfo> GetFields(object newEntity)
    {

        if (newEntity is null)
        {
            return null;
        }
        var fieldList = new List<NameInfo>();

        foreach (PropertyInfo prop in newEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.PropertyType.Name.StartsWith("ICollection`"))
            {
                fieldList.Add(new NameInfo(prop, prop.Name));
            }
        }

        return fieldList;
    }

    public void CheckColumnsInGrid(DataTable dataTable, GridEXColumnCollection columns)
    {
        var janusCol = new GridEXColumn();

        foreach (System.Data.DataColumn dbCol in dataTable.Columns)
        {
            if (!columns.Contains(dbCol.ColumnName))
            {
                janusCol = columns.Add(dbCol.ColumnName);
                janusCol.Visible = true;
            }
            else
            {
                janusCol = columns[dbCol.ColumnName];
            }
            SetColumnDefault(janusCol);
        }

    }

    public void SetColumnDefault(Janus.Windows.GridEX.GridEXTable jsTable, bool AIsChildTabel = false)
    {

        try
        {
            foreach (Janus.Windows.GridEX.GridEXColumn janusColumn in jsTable.Columns)
                SetColumnDefault(janusColumn, AIsChildTabel);
        }
        catch (Exception ex)
        {
            Program.ErrorException(ex, "SetColumnDefault", "clsMain");
        }

    }
    public void SetColumnDefault(Janus.Windows.GridEX.GridEXColumn janusColumn, bool AIsChildTabel = false)
    {

        try
        {
            switch (janusColumn.Table.Columns[janusColumn.Key].Type.ToString()) // System.Type {System.RuntimeType} janusColumn.Type.ToString()
            {
                case "System.Guid":
                    {
                        switch (janusColumn.EditType)
                        {
                            case var @case when @case == EditType.DropDownList:
                            case var case1 when case1 == EditType.MultiColumnDropDown:
                                {
                                    janusColumn.Visible = true;
                                    break;
                                }

                            default:
                                {
                                    janusColumn.Visible = false;
                                    janusColumn.Tag = -1;
                                    janusColumn.FilterEditType = FilterEditType.NoEdit;
                                    break;
                                }
                        }

                        break;
                    }

                case "System.DateTime":
                    {
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.FormatString = "d";
                        break;
                    }
                case "System.Double":
                case "System.Decimal":
                case "System.Single":
                    {
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                        janusColumn.FormatString = "0.00";
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        break;
                    }

                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                    {
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        break;
                    }
                case "System.Boolean":
                    {
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.ColumnType = ColumnType.CheckBox;
                        janusColumn.EditType = EditType.CheckBox;
                        janusColumn.CheckBoxFalseValue = false;
                        janusColumn.CheckBoxTrueValue = true;
                        break;
                    }
            }

            if (janusColumn.Key.ToLower().EndsWith("_guid")) // OrElse janusColumn.Type.BaseType.Name = "Object" Then
            {
                janusColumn.Visible = false;
                janusColumn.Tag = -1;
                janusColumn.FilterEditType = FilterEditType.NoEdit;
            }

            switch (janusColumn.Key)
            {
                case "ID":
                case "FamilyToolsTreeID":
                case "Picture":
                case "FolderID":
                case "PasswordTreeID":
                    {
                        janusColumn.Tag = -1;
                        janusColumn.Visible = false;
                        break;
                    }
                case "_HasAdmission":
                    {
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.ColumnType = ColumnType.CheckBox;
                        janusColumn.EditType = EditType.CheckBox;

                        if (janusColumn.Type.ToString() != "System.Boolean")
                        {
                            janusColumn.CheckBoxFalseValue = 0;
                            janusColumn.CheckBoxTrueValue = 1;
                        }

                        break;
                    }
                case "PurchaseDate":
                case "MaxDate":
                    {
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.FormatString = "d";
                        break;
                    }
            }

            switch (janusColumn.Key)
            {
                case "_Department1":
                    {
                        janusColumn.Tag = -1;
                        janusColumn.Visible = false;
                        janusColumn.FilterEditType = FilterEditType.NoEdit;
                        break;
                    }
                case "FLAG":
                case "GUID":
                case "ID":
                    {
                        janusColumn.Visible = false;
                        janusColumn.FilterEditType = FilterEditType.NoEdit;
                        break;
                    }
                case "_IsMainSupplier":
                    {
                        janusColumn.Visible = false;
                        janusColumn.Tag = -1;
                        break;
                    }
                case "_ModificationDate":
                    {
                        janusColumn.Visible = false;
                        janusColumn.Tag = -1;
                        janusColumn.Caption = "Kaufdatum";
                        janusColumn.Selectable = false;
                        janusColumn.FormatString = "G";
                        janusColumn.Width = 115;
                        break;
                    }
                case "PurchaseDate":
                    {
                        janusColumn.Caption = "Kaufdatum";
                        break;
                    }
                case "Price":
                    {
                        janusColumn.Caption = "Preis";
                        break;
                    }
                case "Description":
                    {
                        if (janusColumn.GridEX.Tag != null && janusColumn.GridEX.Tag.ToString() == "frmDocuments")
                        {
                            janusColumn.Caption = "Datei";
                        }
                        else
                        {
                            janusColumn.Caption = "Bezeichnung";
                        }

                        break;
                    }

                case "Waranty":
                    {
                        janusColumn.Caption = "Garantie";
                        break;
                    }
                case "NodeName":
                    {
                        janusColumn.Caption = "Ordner";
                        janusColumn.Selectable = false;
                        break;
                    }
                case "Document":
                    {
                        janusColumn.Caption = "Dokument";
                        janusColumn.Visible = false;
                        break;
                    }
                case "DocumentState":
                    {
                        janusColumn.Caption = "Status";
                        janusColumn.Visible = false;
                        break;
                    }
                case "DateCreated":
                    {
                        janusColumn.Caption = "Erstellt";
                        janusColumn.Selectable = false;
                        break;
                    }
                case "DateChanged":
                    {
                        janusColumn.Caption = "Geändert";
                        janusColumn.Selectable = false;
                        break;
                    }
                case "FileSize":
                case "ICON":
                case "DocumentType":
                    {
                        // janusColumn.Caption = "Größe"
                        // janusColumn.Selectable = False
                        janusColumn.Visible = false;
                        janusColumn.Tag = -1;
                        break;
                    }
                case "FileSizeText":
                    {
                        janusColumn.Caption = "Größe";
                        janusColumn.Selectable = false;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        break;
                    }
                case "FolderName":
                    {
                        janusColumn.Caption = "Ordner";
                        janusColumn.Selectable = false;
                        break;
                    }
                case "FactoryName":
                    {
                        janusColumn.Caption = "Firma";
                        break;
                    }
                case var case2 when case2 == "DateCreated":
                    {
                        janusColumn.Caption = "Erstellt am";
                        break;
                    }
                case "UserName":
                    {
                        janusColumn.Caption = "Benutzername";
                        break;
                    }
                case "UserPassword":
                    {
                        janusColumn.Caption = "Passwort";
                        janusColumn.PasswordChar = char.Parse("*");
                        break;
                    }
                case "Remark":
                    {
                        janusColumn.Caption = "Bemerkung";
                        break;
                    }
                case "DisplayIcon":
                case "ImageExt":
                    {
                        janusColumn.Caption = "";
                        janusColumn.Selectable = false;
                        janusColumn.Width = 25;
                        janusColumn.AllowDrag = false;
                        janusColumn.AllowSize = false;
                        janusColumn.Position = 1;
                        janusColumn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center;
                        janusColumn.LeftMargin = 3;
                        break;
                    }
            }
        }

        catch (Exception ex)
        {
            Program.ErrorException(ex, "SetColumnDefault", "clsMain");
        }

    }

    private void CheckColumnsByCommandBar(GridEXColumn ACol, UICommand cmdColumns, Janus.Windows.UI.CommandBars.CommandEventHandler uicClick)
    {


        try
        {
            if (ACol.Type.ToString() != "System.Guid" || ACol.EditType == EditType.DropDownList || ACol.EditType == EditType.MultiColumnDropDown)
            {
                switch (ACol.Key)
                {
                    case "FLAG":
                    case "ID":
                        {
                            ACol.Tag = -1;
                            break;
                        }
                    case "XX":
                        {
                            if (ACol.GridEX.Tag is string)
                            {
                                switch (ACol.GridEX.Tag)
                                {
                                    case "XX":
                                        {
                                            AddColumnsToCommandBar(ACol, cmdColumns, uicClick);
                                            break;
                                        }

                                    default:
                                        {
                                            ACol.Tag = -1;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                ACol.Tag = -1;
                            }

                            break;
                        }

                    default:
                        {
                            AddColumnsToCommandBar(ACol, cmdColumns, uicClick);
                            break;
                        }
                }
            }
        }
        catch
        {
            throw;
        }

    }
    public void AddColumnsToCommandBar(GridEXColumn ACol, UICommand cmdColumns, Janus.Windows.UI.CommandBars.CommandEventHandler uicClick)
    {

        try
        {

            if (ACol.Tag == null)
                return;

            if (ACol.Tag.ToString() != "-1")
            {
                var uic = new UICommand();
                uic.Key = ACol.Key;
                uic.Text = ACol.Caption;
                uic.Tag = ACol.Position;
                uic.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
                if (ACol.Visible == true)
                {
                    uic.Checked = Janus.Windows.UI.InheritableBoolean.True;
                    uic.IsChecked = true;
                }
                else
                {
                    uic.Checked = Janus.Windows.UI.InheritableBoolean.False;
                    uic.IsChecked = false;
                }
                if (!(uicClick == null))
                    uic.Click += uicClick.Invoke;
                cmdColumns.Commands.Add(uic);
                // cmdColumns.Commands.Insert(ACol.Position, uic)
            }
        }
        catch
        {
            throw;
        }

    }
    public bool ContainsFormatStyles(GridEX grid, string AKey)
    {
        bool ContainsFormatStylesRet = default;

        ContainsFormatStylesRet = false;
        for (int i = 0, loopTo = grid.FormatStyles.Count - 1; i <= loopTo; i++)
        {
            if (grid.FormatStyles[i].Key == AKey)
            {
                return true;
            }
        }

        return ContainsFormatStylesRet;

    }

}

public partial class clsAppData
{
    public bool ShowMDITab { get; set; } = false;
    public bool HasOfficeFormAdorner { get; set; } = false;
    public static void CloseProcess(string Name)
    {
        while (true)
        {
            Process[] pl = Process.GetProcessesByName(Name);
            if (pl.Length > 0)
            {
                pl[0].CloseMainWindow();
                pl[0].Kill();
            }

            if (pl.Length == 0)
            {
                break;
            }
        }

    }
}
}