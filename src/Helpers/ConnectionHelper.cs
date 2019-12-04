using System.Collections.Generic;
using CassandraWeb.Helpers.Interfaces;
using CassandraWeb.Models;
using CassandraWeb.Database;
using System;
namespace CassandraWeb.Helpers
{
    public class ConnectionHelper : IConnectionHelper
    {
        public void Dispose()
        {
            // TODO: add some logic here
        }

        public List<Connection> GetConnections()
        {
            using (DatabaseHelper<Connection> helper = new DatabaseHelper<Connection>())
            {
                return helper.GetAll();
            }
        }

        public Connection GetConnectionById(Guid connectionId) {
             using (DatabaseHelper<Connection> helper = new DatabaseHelper<Connection>())
            {
                return helper.GetByPrimaryKey(connectionId);
            }
        }

        public Connection NewConnection(Connection newConnectionData)
        {
            using (DatabaseHelper<Connection> helper = new DatabaseHelper<Connection>())
            {
                helper.Insert(newConnectionData);
                // TODO: get id of inserted row
                return newConnectionData;
            }
        }

        public bool DeleteConnection(Guid connectionId) {
             using (DatabaseHelper<Connection> helper = new DatabaseHelper<Connection>())
            {
                helper.DeleteByPrimaryKey(connectionId);
                return true;
            }
        }
    }
}