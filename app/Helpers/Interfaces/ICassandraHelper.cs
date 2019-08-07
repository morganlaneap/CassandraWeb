using System.Collections.Generic;
using CassandraWeb.Models;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
namespace CassandraWeb.Helpers.Interfaces
{
    public interface ICassandraHelper : IDisposable
    {
        bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);
        List<Keyspace> GetKeyspaces();
        List<Table> GetTablesInKeyspace(string keyspaceName);
    }
}