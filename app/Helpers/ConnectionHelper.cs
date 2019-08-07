using System.Collections.Generic;
using CassandraWeb.Helpers.Interfaces;
using CassandraWeb.Models;
using CassandraWeb.Database;
namespace CassandraWeb.Helpers
{
    public class ConnectionHelper : IConnectionHelper
    {
        public List<Connection> GetConnections()
        {
            using (DatabaseHelper<Connection> helper = new DatabaseHelper<Connection>())
            {
                return helper.GetAll();
            }
        }
        public void Dispose()
        {
            // TODO: add some logic here
        }
    }
}