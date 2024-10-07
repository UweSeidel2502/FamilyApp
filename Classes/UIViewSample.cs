using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilyApp.Repositories.Registry;
using Janus.Windows.UI.Dock;
using Janus.Windows.GridEX;
using Janus.Windows.Ribbon;
using Janus.Windows.EditControls;
using Janus.Windows.UI.CommandBars;
using Janus.Windows.UI;
using USSoft.Data;
namespace FamilyApp.Classes
{
    public partial class UIViewSample
    {

        #region WindowsPos
        private static void SetDefaultWindowSize(Form form)
        {
            form.Left = 0;
            form.Top = 0;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = Screen.PrimaryScreen.WorkingArea.Width + 14;
            form.WindowState = FormWindowState.Maximized;
        }
        public static void GetWindowsPosXML(Form form)
        {

            if (!Program.AppData.ShowMDITab | !form.IsMdiChild)
            {
                form.Height = Program.DBReg.ReadXMLInt32(@"WinPos\Height", form.Height);
                form.Width = Program.DBReg.ReadXMLInt32(@"WinPos\Width", form.Width);
                form.Left = Program.DBReg.ReadXMLInt32(@"WinPos\Left", form.Left);
                form.Top = Program.DBReg.ReadXMLInt32(@"WinPos\Top", form.Top);
                form.WindowState = (FormWindowState)Program.DBReg.ReadXMLInt32(@"WinPos\WindowState", 0);
                if (form.Left < 0)
                    form.Left = 0;
                if (form.Top < 0)
                    form.Top = 0;
            }
            else
            {
                SetDefaultWindowSize(form);
            }

        }
        public static void SetWindowsPosXML(Form form)
        {

            if (!Program.AppData.ShowMDITab | !form.IsMdiChild)
            {

                if (form.Left < 0)
                    form.Left = 0;
                if (form.Top < 0)
                    form.Top = 0;

                Program.DBReg.SaveXMLSettings(@"WinPos\Height", form.Height);
                Program.DBReg.SaveXMLSettings(@"WinPos\Width", form.Width);
                Program.DBReg.SaveXMLSettings(@"WinPos\Left", form.Left);
                Program.DBReg.SaveXMLSettings(@"WinPos\Top", form.Top);
                Program.DBReg.SaveXMLSettings(@"WinPos\WindowState", (int)form.WindowState);

            }
        }
        public static void GetWindowsPos(Form form, string formName = "")
        {

            if (!Program.AppData.ShowMDITab | !form.IsMdiChild)
            {
                string sWinPos;

                try
                {

                    if (!string.IsNullOrEmpty(formName))
                    {
                        sWinPos = Program.DBReg.ReadString(Repositories.Registry.Usage.User, formName, "WinPos");
                    }
                    else
                    {
                        sWinPos = Program.DBReg.ReadString(Repositories.Registry.Usage.User, form.Name, "WinPos");
                    }

                    if (!string.IsNullOrEmpty(sWinPos))
                    {
                        string[] vntSplit  = sWinPos.Split(Convert.ToChar(",")); //Strings.Split(sWinPos, ",");
                        form.Height = Convert.ToInt32(vntSplit[0]);
                        form.Width = Convert.ToInt32(vntSplit[1]);
                        form.Left = Convert.ToInt32(vntSplit[2]);
                        form.Top = Convert.ToInt32(vntSplit[3]);
                        form.WindowState = (FormWindowState)Convert.ToInt32(vntSplit[4]);
                    }

                    if (form.Left < 0 | form.Left > Screen.PrimaryScreen.WorkingArea.Width - 50)
                        form.Left = 0;
                    if (form.Top < 0)
                        form.Top = 0;
                }

                catch {}
            }
            else
            {
                SetDefaultWindowSize(form);
            }

        }
        public static void SetWindowsPos(Form form, string formName = "")
        {

            try
            {

                string sSection = "";

                if (!string.IsNullOrEmpty(formName))
                {
                    sSection = formName;
                }
                else
                {
                    sSection = form.Name;
                }

                if (!Program.AppData.ShowMDITab | !form.IsMdiChild)
                {

                    string sWinPos;

                    if (form.WindowState != FormWindowState.Minimized)
                    {
                        if (form.Left < 0)
                            form.Left = 0;
                        if (form.Top < 0)
                            form.Top = 0;
                        sWinPos = form.Height.ToString() + "," + form.Width.ToString() + "," + form.Left.ToString() + "," + form.Top.ToString() + "," + ((int)form.WindowState).ToString();
                        Program.DBReg.SaveSetting(Usage.User, sSection, "WinPos", sWinPos);
                    }
                }
                else if (Program.AppData.ShowMDITab)
                {
                    Program.DBReg.DeleteSetting(Usage.User, sSection, "WinPos");
                }
            }
            catch {}
        }
        #endregion

        #region Janusgrid Settings
        public static void SetPanelFormatStyle(UIPanelManager panel, string formName)
        {

            var layoutStream = new System.IO.MemoryStream();
            try
            {
                if (panel.Panels.Count > 0)
                {
                    panel.SaveLayoutFile(layoutStream);
                    if (layoutStream.Length > 0L)
                    {
                        Program.DBReg.SaveSettingAsBlob(Usage.User, formName, "Panel_LayoutString", layoutStream);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (!(layoutStream == null))
                {
                    layoutStream.Close();
                    layoutStream.Dispose();
                }
            }

        }
        public static void GetPanelFormatStyle(UIPanelManager panel, string formName)
        {

            MemoryStream layoutStream;
            layoutStream = Program.DBReg.ReadBlob(Usage.User, formName, "Panel_LayoutString", default);

            try
            {
                if (!(layoutStream == null))
                {
                    try
                    {
                        panel.LoadLayoutFile(layoutStream);
                        panel.DefaultPanelSettings.CaptionDoubleClickAction = CaptionDoubleClickAction.None;
                        panel.DefaultPanelSettings.CaptionStyle = PanelCaptionStyle.Dark;
                        panel.DefaultPanelSettings.ActiveCaptionMode = ActiveCaptionMode.Never;
                        panel.BuiltInTexts[PanelsBuiltInText.AutoHidePanelToolTip] = "Ausblenden";
                    }

                    catch
                    {
                        Program.DBReg.DeleteSettings(formName);
                        return;
                    }
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (!(layoutStream == null))
                {
                    layoutStream.Close();
                    layoutStream.Dispose();
                }
            }

        }
        public static void SetRibbonFormatStyle(Ribbon ribbon, string formName)
        {

            var layoutStream = new MemoryStream();
            try
            {

                ribbon.SaveLayoutFile(layoutStream);
                if (layoutStream.Length > 0L)
                {
                    Program.DBReg.SaveSettingAsBlob(Usage.User, formName, "Ribbon_LayoutString", layoutStream);
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                if (!(layoutStream == null))
                {
                    layoutStream.Close();
                    layoutStream.Dispose();
                }
            }

        }
        public static void GetRibbonFormatStyle(Ribbon ribbon, string formName)
        {

            MemoryStream layoutStream;
            layoutStream = Program.DBReg.ReadBlob(Usage.User, formName, "Ribbon_LayoutString", default);

            try
            {
                if (!(layoutStream == null))
                {
                    try
                    {
                        ribbon.LoadLayoutFile(layoutStream);
                    }
                    catch
                    {
                        Program.DBReg.DeleteSettings(formName);
                        return;
                    }
                }
            }

            catch 
            {
                throw;
            }
            finally
            {
                if (!(layoutStream == null))
                {
                    layoutStream.Close();
                    layoutStream.Dispose();
                }
            }

        }
        public static void SetGridFormatStyle(GridEXTable table, string formName)
        {

            if (!string.IsNullOrEmpty(formName.Trim()))
            {
                if (!(table == null))
                {
                    try
                    {
                        if (table.Columns.Count > 0)
                        {
                            table.GridEX.WatermarkImage.Image = null;
                            var s = new MemoryStream();
                            table.GridEX.SaveLayoutFile(s);
                            if (s.Length > 0L)
                            {
                                Program.DBReg.SaveSettingAsBlob(Usage.User, formName, "GridEX_LayoutString", s);
                            }
                            s.Close();
                            s.Dispose();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        }
        public static bool GetGridFormatStyle(GridEXTable table, string formName)
        {
            bool IsSucc = true;
            try
            {
                table.GridEX.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.EntireRow;
                table.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.False;
                table.GridEX.ContinuousScroll = true;
                table.AllowEdit =  Janus.Windows.GridEX.InheritableBoolean.False;
                table.GridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
                table.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False;

                if (!string.IsNullOrEmpty(formName))
                {

                    MemoryStream layoutStream;
                    layoutStream = Program.DBReg.ReadBlob(Usage.User, formName, "GridEX_LayoutString", default);

                    if (layoutStream != null)
                    {
                        try
                        {
                            table.GridEX.LoadLayoutFile(layoutStream);
                            layoutStream.Close();
                            layoutStream.Dispose();
                        }
                        catch
                        {
                            layoutStream.Close();
                            layoutStream.Dispose();
                            IsSucc = false;
                            Program.DBReg.DeleteSettings(formName);
                            string s = "Die tablelle konnte nicht geladen werden!/r/rEinige Spalten wurden gelöscht. Öffnen Sie das Fenster erneut.";
                            bool showBox = false;
                            Program.cPRO.MsgBoxExt(s, USSoft.Data.TMsgBox.MsgBoxIcon.mbiInformation, Program.AssemblyName, Microsoft.VisualBasic.MsgBoxStyle.OkOnly, 0, default,ref showBox);
                            return false;
                        }
                    }
                    else
                    {
                        IsSucc = false;
                    }
                }
                else
                {
                    IsSucc = false;
                }

                if (!IsSucc)
                {
                    GridEXBuiltInText(table.GridEX);
                    table.AlternatingRowFormatStyle.Reset();
                    table.GridEX.AlternatingRowFormatStyle.Reset();
                    table.GridEX.RowFormatStyle.Reset();
                    table.GridEX.HeaderFormatStyle.Reset();
                    table.GridEX.SelectedFormatStyle.Reset();
                    table.GridEX.GroupByBoxFormatStyle.Reset();
                    table.GridEX.GroupByBoxInfoFormatStyle.Reset();
                    table.GridEX.GroupRowFormatStyle.Reset();

                    table.GridEX.RecordNavigator = true;
                    table.GridEX.AlternatingColors = true;
                    table.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
                    table.GridEX.ThemedAreas = Janus.Windows.GridEX.ThemedArea.All;
                    table.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
                    table.GridEX.GroupByBoxVisible = true;
                    table.GridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.SunkenLight3D;
                    table.GridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
                    table.GridEX.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Light3D;
                    table.GridEX.GridLines = GridLines.Default;
                    table.GridEX.GridLineStyle = GridLineStyle.SmallDots;
                }

                return IsSucc;
            }
            catch
            {
                throw;
            }

        }
        public static void GridEXBuiltInText(GridEX grid)
        {
            try
            {
                if (!(grid == null))
                {
                    {
                        var withBlock = grid.BuiltInTexts;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo] = FamilyApp.Properties.Resources.GroupByBoxInfoText;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.CalendarNoneButton] = FamilyApp.Properties.Resources.CalendarNoneText;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.CalendarTodayButton] = FamilyApp.Properties.Resources.CalendarTodayText;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.RecordNavigator] = FamilyApp.Properties.Resources.RecordNavigatorString;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.RecordNavigatorError] = FamilyApp.Properties.Resources.RecordNavigatorError;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateEmpty] = FamilyApp.Properties.Resources.OutlookDateEmpty;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateOlder] = FamilyApp.Properties.Resources.OutlookDateOlder;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateLastMonth] = FamilyApp.Properties.Resources.OutlookDateLastMonth;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateEarlierThisMonth] = FamilyApp.Properties.Resources.OutlookDateEarlierThisMonth;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateThreeWeeksAgo] = FamilyApp.Properties.Resources.OutlookDateThreeWeeksAgo;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateTwoWeeksAgo] = FamilyApp.Properties.Resources.OutlookDateTwoWeeksAgo;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateLastWeek] = FamilyApp.Properties.Resources.OutlookDateLastWeek;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateYesterday] = FamilyApp.Properties.Resources.OutlookDateYesterday;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateToday] = FamilyApp.Properties.Resources.OutlookDateToday;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateTomorrow] = FamilyApp.Properties.Resources.OutlookDateTomorrow;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateNextWeek] = FamilyApp.Properties.Resources.OutlookDateNextWeek;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateTwoWeeksAway] = FamilyApp.Properties.Resources.OutlookDateTwoWeeksAway;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateThreeWeeksAway] = FamilyApp.Properties.Resources.OutlookDateThreeWeeksAway;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateLaterThisMonth] = FamilyApp.Properties.Resources.OutlookDateLaterThisMonth;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateNextMonth] = FamilyApp.Properties.Resources.OutlookDateNextMonth;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.OutlookDateBeyondNextMonth] = FamilyApp.Properties.Resources.OutlookDateBeyondNextMonth;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.DropDownOkButton] = "Ok";
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.DropDownCancelButton] = FamilyApp.Properties.Resources.DropDownCancelButton;

                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionBeginsWith] = FamilyApp.Properties.Resources.FilterRowConditionBeginsWith;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionClear] = FamilyApp.Properties.Resources.FilterRowConditionClear;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionContains] = FamilyApp.Properties.Resources.FilterRowConditionContains;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionEndsWith] = FamilyApp.Properties.Resources.EndetMitZeichenfolge;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionEqual] = FamilyApp.Properties.Resources.FilterRowConditionEqual;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionGreaterThan] = FamilyApp.Properties.Resources.FilterRowConditionGreaterThan;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionGreaterThanOrEqual] = FamilyApp.Properties.Resources.FilterRowConditionGreaterThanOrEqual;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionIsEmpty] = FamilyApp.Properties.Resources.FilterRowConditionIsEmpty;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionLessThan] = FamilyApp.Properties.Resources.FilterRowConditionLessThan;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionLessThanOrEqual] = FamilyApp.Properties.Resources.FilterRowConditionLessThanOrEqual;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionNotContains] = FamilyApp.Properties.Resources.FilterRowConditionNotContains;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionNotEqual] = FamilyApp.Properties.Resources.FilterRowConditionNotEqual;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowConditionNotIsEmpty] = FamilyApp.Properties.Resources.FilterRowConditionNotIsEmpty;
                        withBlock[Janus.Windows.GridEX.GridEXBuiltInText.FilterRowInfoText] = FamilyApp.Properties.Resources.FilterRowInfoText;

                    }
                }
            }
            catch {}
        }
        public static void SetGroupRowVisualStyleOutlook2003(GridEX grid)
        {

            grid.GroupRowVisualStyle = GroupRowVisualStyle.Outlook2003;
            grid.GroupRowFormatStyle.Font = new Font(grid.Font.FontFamily, grid.Font.Size, FontStyle.Bold);
            grid.GroupRowFormatStyle.ForeColor = Color.SteelBlue;
            grid.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            grid.RootTable.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            grid.RecordNavigator = false;
            grid.GroupIndent = 16;
            grid.Indent = 32;
            grid.AlternatingColors = false;
            grid.RootTable.ShowGroupConditionCount = true;
            grid.GridLineStyle = GridLineStyle.Solid;
            grid.GridLines = GridLines.Horizontal;

            GridEXBuiltInText(grid);
        }
        public static void SetRowColor(GridEX grid, string formName, object tool)
        {

            try
            {
                if (Convert.ToBoolean(((dynamic)tool).Checked))
                {
                    ((dynamic)tool).Checked = false;
                }
                else
                {
                    ((dynamic)tool).Checked = true;
                }

                grid.Refresh();
                Program.DBReg.SaveSetting(Usage.User, formName, "UseEvenOddColor", ((dynamic)tool).Checked);
            }
            catch
            {
                throw;
            }

        }
        public static bool IsFieldExistByJanusGrid(GridEXTable table, string fieldName)
        {

            foreach (Janus.Windows.GridEX.GridEXColumn col in table.Columns)
            {
                if (col.Key == fieldName)
                {
                    return true;
                }
            }

            return false;

        }
        public static void SetGroupButton(GridEX grid, string formName, object Tool)
        {

            try
            {
                if (Convert.ToBoolean(((dynamic)Tool).Checked))
                {
                    ((dynamic)Tool).Checked = false;
                }
                else
                {
                    ((dynamic)Tool).Checked = true;
                }
                grid.GroupByBoxVisible = ((dynamic)Tool).Checked;
                Program.DBReg.SaveSetting(Usage.User, formName, "GroupButton", ((dynamic)Tool).Checked);
            }
            catch
            {
                throw;
            }

        }
        public static bool FindRecord(GridEX grid, GridEXColumn column, object value)
        {
            bool FindRecordRet = default;
            FindRecordRet = false;
            if (!(grid.RootTable == null))
            {
                try
                {

                    object svalue = null;
                    if (!(value == null))
                    {
                        if (column.Type.Name.ToUpper() == "GUID" & value.GetType().Name.ToUpper() == "STRING")
                        {
                            svalue = new Guid(value.ToString());
                        }
                        else
                        {
                            svalue = value;
                        }
                    }

                    return grid.FindAll(column, Janus.Windows.GridEX.ConditionOperator.Equal, svalue) != 0;
                }

                catch
                {
                    return false;
                }
            }

            return FindRecordRet;
        }
        public static bool FindRecord(GridEX grid, string columnKey, object value)
        {
            bool FindRecordRet = default;
            FindRecordRet = false;
            if (!(grid.RootTable == null))
            {
                try
                {
                    Janus.Windows.GridEX.GridEXColumn column = grid.RootTable.Columns[columnKey];
                    return FindRecord(grid, column, value);
                }
                catch
                {
                    return false;
                }

            }

            return FindRecordRet;
        }
        public static void FindRecordInGrid(GridEX grid, GridEXColumn column, object value)
        {
            grid.FindAll(column, Janus.Windows.GridEX.ConditionOperator.Equal, value);
        }
        public static bool ShowTableSetting(GridEX grid)
        {
            frmGridSettings f = new frmGridSettings();
           
            try
            {
                f.Grid = grid;
                if (f.Execute(Program.cPRO))
                {
                    for (int i = 0, loopTo = grid.RootTable.ChildTables.Count - 1; i <= loopTo; i++)
                    {
                        {
                            var withBlock = grid.RootTable.ChildTables[i];
                            withBlock.AlternatingRowFormatStyle.Reset();
                            withBlock.GridEX.RowHeaders = grid.RootTable.RowHeaders;
                            withBlock.RowHeight = 20;
                            withBlock.AlternatingRowFormatStyle.BackColor = grid.RootTable.AlternatingRowFormatStyle.BackColor;
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
            catch { throw; }
            finally {f.Dispose();}
        }
        public static bool ShowColumnSettings(GridEX grid, UICommand cmdColumns)
        {
            var F = new frmColumnsVisible();
            try
            {
                F.Grid = grid;
                return F.Execute(Program.cPRO, cmdColumns);
            }
            catch { throw; }
            finally
            {
                F.Dispose();
            }
        }
        public static Janus.Windows.UI.InheritableBoolean ToJsBool(bool value)
        {
            if (value)
            {
                return Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                return Janus.Windows.UI.InheritableBoolean.False;
            }
        }
        public static void SetCategoryState(UICommandManager commandBar, string categoryName, bool state)
        {
            foreach (UICommand cm in commandBar.Commands)
            {
                if (cm.CategoryName == categoryName)
                {
                    cm.Enabled = ToJsBool(state);
                }
            }
        }
        public static void SetMenuChecked(UICommand command, string mnueKey, bool setCaption = false)
        {

            foreach (UICommand cm in command.Commands)
                cm.IsChecked = false;
            command.Commands[mnueKey].IsChecked = true;
            command.TagString = mnueKey;

            if (setCaption)
            {
                command.Text = command.Commands[mnueKey].Text;
                if (!(command.Commands[mnueKey].Tag == null))
                {
                    command.Tag = command.Commands[mnueKey].Tag;
                }
                command.Shortcut = command.Commands[mnueKey].Shortcut;
            }
        }
        public static void SetMenuChecked(DropDownCommand command, string mnueKey, bool setCaption = false)
        {

            foreach (ButtonCommand cm in command.Commands)
                cm.Checked = false;
            {
                var withBlock = (ButtonCommand)command.Commands[mnueKey];
                withBlock.Checked = true;
                command.Tag = mnueKey;

                if (setCaption)
                {
                    command.Text = withBlock.Text;
                }

            }
        }
        #endregion

        #region Janus Controls
        public static void SetVisualStyle(System.Windows.Forms.Control control)
        {

            if (!(control == null))
            {
                Program.fMain.vsm.AddControl(control, true);
                if (control is Form)
                {
                    Janus.Windows.Ribbon.OfficeFormAdorner ofa;
                    ofa = new Janus.Windows.Ribbon.OfficeFormAdorner();
                    ofa.Form = (Form)control;
                    ofa.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black; // ics2007
                    Program.AppData.HasOfficeFormAdorner = true;
                }

            }
        }

        public static void SetDefaultGridView(GridEX janusGrid)
        {

            janusGrid.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False;
            janusGrid.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False;
            janusGrid.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            janusGrid.RootTable.CellLayoutMode = CellLayoutMode.UseColumns;
            janusGrid.RootTable.ColumnSets.Clear();
            janusGrid.AllowColumnDrag = true;
            janusGrid.ShowErrors = false;
            janusGrid.RootTable.RowHeight = 20;
            janusGrid.AlternatingColors = true;
            janusGrid.AlternatingRowFormatStyle.BackColor = Color.PeachPuff;

            GridEXBuiltInText(janusGrid);

        }
        public static void SetDefaultGridViewChildTable(GridEX janusGrid, int childTableIndex)
        {

            {
                var withBlock = janusGrid.RootTable.ChildTables[childTableIndex];
                withBlock.SortKeys.Clear();
                withBlock.AlternatingRowFormatStyle.Reset();
                withBlock.AllowChildTableGroups = Janus.Windows.GridEX.InheritableBoolean.False;
                withBlock.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.False;
                withBlock.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
                withBlock.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
                withBlock.GridEX.RowHeaders = janusGrid.RootTable.RowHeaders;
                withBlock.RowHeight = 20;
                withBlock.AlternatingRowFormatStyle.BackColor = janusGrid.RootTable.AlternatingRowFormatStyle.BackColor;
            }

        }

        public static void SetControlState(bool state, Janus.Windows.CalendarCombo.CalendarCombo control, bool isNullDate = false)
        {
            if (!state)
            {
                control.VisualStyleManager = null;
                control.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard;
            }
            else if (control.VisualStyleManager == null)
            {
                UIViewSample.SetVisualStyle(control);
            }
            control.DisabledBackColor = System.Drawing.SystemColors.ControlLight;
            control.DisabledForeColor = System.Drawing.Color.Black;
            control.Enabled = state;
            control.ShowDropDown = state;
            control.IsNullDate = isNullDate;
        }
        public static void SetControlState(bool state, object control, bool setEmpty = false)
        {

            try
            {
                if (state)
                {
                    ((dynamic)control).BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    ((dynamic)control).BackColor = System.Drawing.SystemColors.ControlLight;

                } ((dynamic)control).ReadOnly = !state;

                if (control is Janus.Windows.CalendarCombo.CalendarCombo)
                {
                    ((dynamic)control).ShowDropDown = state;
                    ((dynamic)control).IsNullDate = setEmpty;
                }
                else if (control is Janus.Windows.GridEX.EditControls.EditBox | control is USSoft.Data.TLookUpTextBox | control is USSoft.Data.TNumericEditBox)
                {
                    if (setEmpty)
                        ((dynamic)control).Text = "";
                    ((dynamic)control).ButtonEnabled = state;
                }
                else if (control is USSoft.Data.TComboBox)
                {
                    if (setEmpty)
                        ((dynamic)control).Text = "";
                }
            }

            catch {}

        }
        public static void SetControlsLocked(bool isLocked, Control parentControl)
        {

            foreach (Control ctr in parentControl.Controls)
            {
                if (!(ctr is Label))
                {
                    if (isLocked | ctr is USSoft.Data.TCheckBox)
                    {
                        if (ctr is USSoft.Data.TLookUpTextBox)
                        {
                            ((USSoft.Data.TLookUpTextBox)ctr).Enabled = false;
                        }
                        else if (ctr is USSoft.Data.TComboBox)
                        {
                            ctr.BackColor = System.Drawing.SystemColors.ButtonFace;
                            ((USSoft.Data.TComboBox)ctr).BackColor = System.Drawing.SystemColors.ButtonFace;
                        }
                    }
                    else if (ctr is USSoft.Data.TLookUpTextBox)
                    {
                        if (!((USSoft.Data.TLookUpTextBox)ctr).ReadOnlyData)
                        {
                            ((USSoft.Data.TLookUpTextBox)ctr).Enabled = true;
                        }
                    }
                    else if (ctr is USSoft.Data.TComboBox)
                    {
                        ctr.BackColor = System.Drawing.SystemColors.ButtonFace;
                        ((USSoft.Data.TComboBox)ctr).BackColor = System.Drawing.SystemColors.Window;
                    }
                    else if (isLocked | ctr is USSoft.Data.TCheckBox)
                    {
                    }

                    else if (ctr is UICheckBox)
                    {
                    }
                    // ctr.BackColor = System.Drawing.SystemColors.ButtonFace
                    else if (ctr is UIGroupBox)
                    {
                    }
                    // ctr.BackColor = System.Drawing.SystemColors.ButtonFace
                    else
                    {
                        ctr.BackColor = System.Drawing.SystemColors.Window;

                    }

                    if (ctr is UIGroupBox | ctr is UICheckBox)
                    {
                        ctr.Refresh();
                        ctr.Enabled = true;
                    }
                    else
                    {
                        ctr.Refresh();
                        ctr.Enabled = !isLocked;
                    }

                }
            }

        }

        /// <summary>
        /// Füllt eine ComboBox von USSoft.Data.TComboBox (abgeleitet von Janus.Windows.EditControls.UIComboBox).
        /// Wenn sSQL ="" oder Nothing, dann wird der LookupSQL von der ComboBox verwendet.
        /// </summary>
        public static void FillComboBox(UIComboBox comboBox, DataTable dataTable, object selectValue, string displayMember)
        {

            if (dataTable != null)
            {
                comboBox.DataSource = dataTable;
                comboBox.ValueMember = dataTable.Columns[0].ColumnName;
                comboBox.DisplayMember = displayMember;
                comboBox.SelectedIndex = -1;
                if (selectValue != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[0].ToString() == selectValue.ToString())
                        {
                            comboBox.SelectedValue = row[0];
                            return;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Füllt eine ComboBox von USSoft.Data.TComboBox (abgeleitet von Janus.Windows.EditControls.UIComboBox).
        /// </summary>
        public static void FillComboBox(UIComboBox comboBox, object dataSource, object selectValue, string displayMember)
        {

            if (dataSource != null)
            {
                comboBox.DataSource = dataSource;
                comboBox.ValueMember = "ID";
                comboBox.DisplayMember = displayMember;
                comboBox.SelectedValue = selectValue;
            }

        }
        #endregion
    }
}
