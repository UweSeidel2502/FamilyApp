using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using Dapper;
using FamilyApp.Data;

namespace FamilyApp
{ 
 
    internal static partial class FamilyAppApplication
    {
    public static string ConnectionString { get; set; }
    private static FamilyApp.Repositories.UnitOfWork _unitOfWork;
    
    private static void RegMPVExample()
    {
        var regData = new DataSet("MPV");

        string dir = GetCommonApplicationDataFolder("EngineSoft", "MPV");
        regData.ReadXml(Path.Combine(dir, "MPV.properties"), XmlReadMode.Auto);

        var regRow = regData.Relations[0].ChildTable.Rows[0];
        var test = regRow[0];
        test = regRow[1];
        test = regRow[2];
        test = regRow[3];

        regRow = regData.Relations[1].ChildTable.Rows[1];
        test = regRow[0];
        test = regRow[1];
        test = regRow[2];
        test = regRow[3];

        // Dim T = regData.Tables.Add("DBSettings")
        // T.Columns.Add("ServerName", GetType(String))
        // T.Columns.Add("DataBaseName", GetType(String))
        // T.Columns.Add("UserID", GetType(String))

        // Dim newRow = T.NewRow()
        // newRow.Item("ServerName") = "SONNE\SQLEXPRESS2016"
        // newRow.Item("DataBaseName") = "FamilyApp"
        // newRow.Item("UserID") = "sa"
        // T.Rows.Add(newRow)
        // regData.WriteXml(IO.Path.Combine(dir, "FamilyApp.properties"))
        }
    public static void SetConnectionString()
    {

        var regData = new System.Data.DataSet("FamilyApp");
        string dir = GetCommonApplicationDataFolder("USSoft", "FamilyApp");
        regData.ReadXml(Path.Combine(dir, "FamilyApp.properties"));

        var builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        var regRow = regData.Tables[0].Rows[0];

        builder.DataSource = regRow[0].ToString();
        builder.InitialCatalog = regRow[1].ToString();
        builder.UserID = regRow[2].ToString();
        builder.Password = Crypt.clsCrypt.Decrypt(regRow[3].ToString(), "123");
        builder.PersistSecurityInfo = true;

        ConnectionString = builder.ConnectionString;
        DBApplication.Get.DBContext.Configuration.LazyLoadingEnabled = true;
        Program.DBReg = UnitOfWork.DBReg;
        Program.DBReg.UserID = "1";
        
        SetDependency(builder);
    }

    private static void SetDependency(SqlConnectionStringBuilder builder)
    {
        Program.cPRO.AppName = System.Reflection.Assembly.GetExecutingAssembly().FullName;
        // Program.cPRO.RebindGrid = AddressOf cMain.RebindGrid
        // Program.cPRO.SetVisualStyle = UIViewSample.SetVisualStyle;

        Program.cPRO.ActiveConnection = new System.Data.OleDb.OleDbConnection("Provider=SQLOLEDB;" + builder.ConnectionString);
        Program.cPRO.DBReg.ActiveConnection = Program.cPRO.ActiveConnection;
        Program.cPRO.DBReg.DBIndexField = "ID";
        Program.cPRO.DBReg.IndexKeyType = USSoft.DBModel.DBRegistry.TDBReg.DBRegIndexKeyType.iktAutoincrementel;
        Program.cPRO.UserGuid = Program.DBReg.UserID;
        Program.cPRO.UserName = "useidel";

    }
        public static string GetCommonApplicationDataFolder(string AAssemblyCompany, string AAssemblyProductName)
    {

        string CommonApplicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        if (!CommonApplicationDataFolder.EndsWith(@"\"))
            CommonApplicationDataFolder += @"\";
        CommonApplicationDataFolder += AAssemblyCompany + @"\" + AAssemblyProductName;
        if (!Directory.Exists(CommonApplicationDataFolder))
        {
            Directory.CreateDirectory(CommonApplicationDataFolder);
        }

        return CommonApplicationDataFolder;
    }

    public static FamilyAppEntities DataFactory
    {
        get
        {
            return DBApplication.Get.DBContext;
        }
    }

    public static FamilyApp.Repositories.UnitOfWork UnitOfWork
    {
        get
        {
            if (!(DBApplication.Get.DBContext == null) && _unitOfWork == null)
            {
                _unitOfWork = new FamilyApp.Repositories.UnitOfWork(DBApplication.Get.DBContext);
            }

            return _unitOfWork;
        }
    }

    public static IDbConnection OpenConnection(FamilyAppEntities context)
    {
        IDbConnection connection;

        connection = new System.Data.SqlClient.SqlConnection(context.Database.Connection.ConnectionString);
        connection.Open();

        return connection;
    }

    public static IEnumerable GetTableAsEnumerable<T>(FamilyAppEntities context, string sql, DynamicParameters @param)
    {

        using (var connection = OpenConnection(context))
        {
            return connection.Query<T>(sql, @param);
        }

    }

    public static DataTable GetDataTable(FamilyAppEntities context, string sql, DynamicParameters @params)
    {

        using (var connection = OpenConnection(context))
        {
            var dataTable = new DataTable();
            dataTable.Load(connection.ExecuteReader(sql, @params));

            foreach (DataColumn column in dataTable.Columns)
                column.ReadOnly = false;

            return dataTable;
        }

    }
    }

    public sealed partial class DBApplication
    {

    private static DBApplication _instance = null;
    private FamilyAppEntities _dbContext;
    private static readonly object padlock = new object();

    private DBApplication()
    {
        // ...
    }

    public static DBApplication Get
    {
        get
        {
            lock (padlock)
            {
                if (_instance is null)
                {
                    _instance = new DBApplication();
                }

                return _instance;
            }
        }
    }

    public FamilyAppEntities DBContext
    {
        get
        {
            if (_dbContext == null)
            {
                _dbContext = new FamilyAppEntities();
                // ConnectionString in AppConfig überschreiben
                _dbContext.Database.Connection.ConnectionString = FamilyAppApplication.ConnectionString;
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }

            return _dbContext;
        }
    }

    }
}