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
        const string AddTableColumnQuery = "ALTER TABLE {0}.{1} ADD {2} {3};";
        const string DeleteTableColumnQuery = "ALTER TABLE {0}.{1} DROP {2}";
        const string CreateNewTableQuery = "CREATE TABLE {0}.{1} ( {2} );";

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
            if (connection.Username == "" && connection.Password == "")
            {
                cluster = Cluster.Builder()
                   .WithPort(connection.Port)
                   .AddContactPoint(connection.ContactPoint)
                   .Build();
            }
            else
            {
                cluster = Cluster.Builder()
                   .WithCredentials(connection.Username, connection.Password)
                   .WithPort(connection.Port)
                   .AddContactPoint(connection.ContactPoint)
                   .WithSSL(options)
                   .Build();
            }
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

        public bool AddTableColumn(string keyspaceName, string tableName, Column column)
        {
            ISession session = cluster.Connect();
            session.Execute(string.Format(AddTableColumnQuery, keyspaceName, tableName, column.ColumnName, column.DataType));
            return true;
        }

        public bool DeleteTableColumn(string keyspaceName, string tableName, string columnName)
        {
            ISession session = cluster.Connect();
            session.Execute(string.Format(DeleteTableColumnQuery, keyspaceName, tableName, columnName));
            return true;
        }

        public bool CreateNewTable(Table newTable)
        {
            ISession session = cluster.Connect();
            string tableDefinition = "";
            for (int i = 0; i < newTable.Columns.Count; i++)
            {
                Column column = newTable.Columns[i];
                tableDefinition += $"{column.ColumnName} {column.DataType}";
                if (i < newTable.Columns.Count - 1) tableDefinition += ",";
            }
            session.Execute(string.Format(CreateNewTableQuery, newTable.KeyspaceName, newTable.TableName, tableDefinition));
            return true;
        }

        public QueryResult ExecuteQuery(string queryText)
        {
            ISession session = cluster.Connect();
            RowSet rowSet = session.Execute(queryText);

            QueryResult queryResult = new QueryResult();

            foreach (var column in rowSet.Columns)
            {
                QueryResultColumn queryResultColumn = new QueryResultColumn(column.Name);
                queryResult.Columns.Add(queryResultColumn);
            }

            foreach (var row in rowSet.ToList())
            {
                QueryResultRow queryResultRow = new QueryResultRow();

                foreach (var rowValue in row.ToList())
                {
                    QueryResultRowValue queryResultRowValue = new QueryResultRowValue(rowValue);
                    queryResultRow.RowValues.Add(queryResultRowValue);
                }

                queryResult.Rows.Add(queryResultRow);
            }

            return queryResult;
        }
    }
}