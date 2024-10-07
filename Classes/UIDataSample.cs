using System;
using System.Data;
using System.Collections;
using USSoft.Data;
using FamilyApp.Classes;
using FamilyApp;

namespace FamilyApp.Classes
{
    public partial class UIDataSample
    {

        public static IEnumerable GetDataSource(FamilyApp.Repositories.FilterArgs filter)
        {
            switch (filter.FilterName)
            {
                case "Stunden":
                    {
                        return FamilyApp.Repositories.Stunden.StundenDataView.StundenHG8DataTable(FamilyAppApplication.DataFactory).AsEnumerable();
                    }

                default:
                    {
                        throw new InvalidOperationException("'" + filter.FilterName + "' nicht vorhanden!");
                    }
            }
        }

        #region Combo-Boxen

        public static void SelectValue(object value, TComboBox comboBox)
        {
            comboBox.SelectedValue = (object)null;
            comboBox.Text = null;
            if (value != null)
            {
                // comboBox.Text = Nothing
                comboBox.SelectedValue = value;
            }
        }
        public static void SetComboBoxDataMembers(TComboBox comboBox, string displayMember, string valueMember = "GUID")
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        #endregion

        #region ComboEdit-Boxen und MultiColumnCombo
        /// <summary>
        /// Komponenten eines Gerätes
        /// </summary>
        public static DataTable ComponentDataTable(Guid inventoryGuid)
        {
            // Return DeviceBaseDataViews.ComponentDataTable(DataFactory, New FilterArgs With {.INVNR_GUID = inventoryGuid.ToString})
            return default;
        }


        #endregion
    }
}
