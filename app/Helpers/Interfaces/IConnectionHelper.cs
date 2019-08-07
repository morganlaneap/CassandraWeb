using System.Collections.Generic;
using CassandraWeb.Models;
using System;
namespace CassandraWeb.Helpers.Interfaces {
    public interface IConnectionHelper : IDisposable {
        List<Connection> GetConnections();
        Connection GetConnectionById(Guid connectionId);
        Connection NewConnection(Connection newConnectionData);
        bool DeleteConnection(Guid connectionId);
    }
}