using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FamilyApp.Repositories
{
   public partial class ToolsView
    {
        public static DataTable ToolsDataTable(Data.FamilyAppEntities dataFactory, FilterArgs FilterArgs)
        {
            string sql = "SELECT T.*, F.Description AS NodeName FROM Tools AS T INNER JOIN FamilyToolsTree AS F ON F.ID = T.FamilyToolsTreeID";
            var @param = new DynamicParameters();

            if (string.IsNullOrEmpty(FilterArgs.InStatement) == false)
            {
                sql += " WHERE T.FamilyToolsTreeID " + FilterArgs.InStatement;
            }

            sql += " ORDER BY T.Description";

            return FamilyAppApplication.GetDataTable(dataFactory, sql, @param);
        }

    }
}
