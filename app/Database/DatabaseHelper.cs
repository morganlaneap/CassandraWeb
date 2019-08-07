using SQLite;
using System;
using System.Collections.Generic;
namespace CassandraWeb.Database
{
    public class DatabaseHelper<T> : IDisposable
        where T : new()
    {
        // TODO: move this to appsettings.json
        const string dbLocation = "CassandraWeb.db3";
        private SQLiteConnection database { get; set; }
        public DatabaseHelper()
        {
            database = new SQLiteConnection(dbLocation);
            database.CreateTable<T>();
        }
        public void Dispose() {
            database.Close();
        }
        public List<T> GetAll() {
            return database.Table<T>().ToList();
        }
        public void Insert(T model)
        {
            database.Insert(model);
        }
        public void Update(T model)
        {
            database.Update(model);
        }
        public void Delete(T model)
        {
            database.Delete(model);
        }
    }
}