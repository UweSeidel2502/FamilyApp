using System;
using System.Data;
using System.Linq;
using Dapper;
using FamilyApp;
using FamilyApp.Interfaces;
using FamilyApp.Repositories;
using FamilyApp.Repositories.Registry;
using FamilyApp.Data;
namespace FamilyApp.Repositories
{
    public partial class UnitOfWork : FamilyApp.Interfaces.IUnitOfWork
    {

        private FamilyAppEntities _dataFactory;
        private DBRegistry _dbReg;
        public UnitOfWork()
        {

        }
        public UnitOfWork(FamilyAppEntities dataFactory)
        {
            _dataFactory = dataFactory;
            // ...
            _dbReg = new DBRegistry(_dataFactory);
        }

        public DBRegistry DBReg
        {
            get
            {
                return _dbReg;
            }
        }

        public int SaveChanges()
        {
            return _dataFactory.SaveChanges();
        }

        public void Dispose()
        {
            _dataFactory.Dispose();
        }

        /// <summary>
        /// FilterArgs: SQL, SelectionMode (opt.)
        /// </summary>
        public DataTable GetDataTabelWithSQL(FilterArgs filter)
        {
            var @param = new DynamicParameters();
            return FamilyAppApplication.GetDataTable(_dataFactory, filter.SQL, @param);
        }

        /// <summary>
        /// Prüfen ob ein Datensatz gelöscht wurde. Bitte beachten, dass MPV immer versucht einene Datensatz zu entfernen (endgültiges löschen).
        /// Sollte das nicht klappen, so wird der FLAG in der entsprechenden Tabelle auf "2" gesetzt oder das entsprechenden Feld auf DBNull
        /// </summary>
        public bool CheckUnDoFlag(string tableName)
        {
            string sql = "SELECT TOP 1 FLAG FROM " + tableName + " WHERE FLAG = 2";

            return FamilyAppApplication.GetDataTable(_dataFactory, sql, new DynamicParameters()).Rows.Count > 0;
        }
    }
}