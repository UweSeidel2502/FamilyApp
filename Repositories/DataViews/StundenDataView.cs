using Dapper;
using System.Data;
using FamilyApp.Data;
namespace FamilyApp.Repositories.Stunden
{
    public partial class StundenDataView
    {
        public static DataTable StundenHG8DataTable(FamilyAppEntities dataFactory)
        {
            string sql = "SELECT A.* FROM ArbeitsStunden AS A INNER JOIN Bearbeiter AS B ON A.UserID = B.ID ORDER BY Datum DESC";
            var @param = new DynamicParameters();

            return FamilyAppApplication.GetDataTable(dataFactory, sql, @param);
        }

    }
}