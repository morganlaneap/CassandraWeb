using System.Collections.Generic;
using CassandraWeb.Helpers.Interfaces;
using CassandraWeb.Models;
using CassandraWeb.Database;
using System;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
namespace CassandraWeb.Helpers
{
    public class CassandraHelper : ICassandraHelper
    {
        const string GetKeyspacesQuery = "SELECT * FROM system_schema.keyspaces;";
        const string GetTablesInKeyspaceQuery = "SELECT * FROM system_schema.tables WHERE keyspace_name = '{0}';";
        const string GetTableSchemaQuery = "SELECT * FROM system_schema.columns WHERE keyspace_name = '{0}' AND table_name = '{1}';";

        public void Dispose()
        {
            // TODO: add some logic here
        }

        private Connection currentConnection { get; set; }
        private Cluster cluster { get; set; }

        public CassandraHelper(Connection connection)
        {
            currentConnection = connection;

            var options = new SSLOptions(SslProtocols.Tls12, true, ValidateServerCertificate);
            options.SetHostNameResolver((ipAddress) => connection.ContactPoint);
            cluster = Cluster.Builder()
                   .WithCredentials(connection.Username, connection.Password)
                   .WithPort(connection.Port)
                   .AddContactPoint(connection.ContactPoint)
                   .WithSSL(options)
                   .Build();
        }

        public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }

        public List<Keyspace> GetKeyspaces()
        {
            ISession session = cluster.Connect();
            return (from row in session.Execute(GetKeyspacesQuery).ToList()
                    select new Keyspace
                    {
                        KeyspaceName = row.GetValue<string>(0)
                    }).ToList();
        }

        public List<Table> GetTablesInKeyspace(string keyspaceName)
        {
            ISession session = cluster.Connect();
            return (from row in session.Execute(string.Format(GetTablesInKeyspaceQuery, keyspaceName)).ToList()
                    select new Table
                    {
                        KeyspaceName = row.GetValue<string>("keyspace_name"),
                        TableName = row.GetValue<string>("table_name")
                    }
            ).ToList();
        }

        public Table GetTableSchema(string keyspaceName, string tableName)
        {
            ISession session = cluster.Connect();
            Table table = new Table()
            {
                KeyspaceName = keyspaceName,
                TableName = tableName
            };
            table.Columns = (from row in session.Execute(string.Format(GetTableSchemaQuery, keyspaceName, tableName)).ToList()
                             select new Column
                             {
                                 ColumnName = row.GetValue<string>("column_name"),
                                 DataType = row.GetValue<string>("type")
                             }
            ).ToList();
            return table;
        }
    }
}