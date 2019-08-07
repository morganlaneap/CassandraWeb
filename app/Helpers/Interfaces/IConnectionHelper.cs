using System.Collections.Generic;
using CassandraWeb.Models;
using System;
namespace CassandraWeb.Helpers.Interfaces {
    public interface IConnectionHelper : IDisposable {
        List<Connection> GetConnections();
    }
}