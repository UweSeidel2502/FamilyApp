using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;

namespace FamilyApp.Repositories.Password
{
    public class PasswordView
    {
        public static DataTable PasswordDataTable(FamilyApp.Data.FamilyAppEntities dataFactory, FilterArgs FilterArgs)
        {
            string sql = "SELECT P.* FROM Password AS P INNER JOIN PasswordTree AS PT ON PT.ID = P.PasswordTreeID";
            var @param = new DynamicParameters();
            sql += " WHERE P.PasswordTreeID = " + FilterArgs.NodeKey;
            sql += " ORDER BY P.FactoryName";

            return FamilyAppApplication.GetDataTable(dataFactory, sql, @param);
        }

    }
}
