using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;

namespace FamilyApp.Repositories.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DocumentView
    {
        public static DataTable DocumentsDataTable(FamilyApp.Data.FamilyAppEntities dataFactory, FilterArgs FilterArgs)
        {
            string sql = @"SELECT D.*,
                                CASE WHEN (FileSize/1024)>1024 THEN
                                    FORMAT(CONVERT(money, FileSize)/1024/1024, '###,###0.00 MB')
                                ELSE
                                    FORMAT(CONVERT(money, FileSize)/1024, '###,###0.00 KB') 
                                END AS FileSizeText, NULL as ImageExt
                                FROM DM_Documents AS D INNER JOIN DM_Folders AS F ON F.ID = D.FolderID";
            var @param = new DynamicParameters();

            if (string.IsNullOrEmpty(FilterArgs.InStatement) == false)
            {
                sql += " WHERE D.FolderID " + FilterArgs.InStatement;
            }

            sql += " ORDER BY D.Description";

            return FamilyAppApplication.GetDataTable(dataFactory, sql, @param);

        }
    }
}
