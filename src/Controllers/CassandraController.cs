using Microsoft.AspNetCore.Mvc;
using System;
using CassandraWeb.Helpers;
using CassandraWeb.Models;
using System.Collections.Generic;
namespace CassandraWeb.Controllers
{
    [Route("api/Cassandra")]
    public class CassandraController : ControllerBase
    {
        [Route("GetKeyspaces")]
        [HttpPost]
        public IActionResult GetKeyspaces(Guid connectionId)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        List<Keyspace> keyspaces = cassandraHelper.GetKeyspaces();
                        return Ok(keyspaces);
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("GetTablesInKeyspace")]
        [HttpPost]
        public IActionResult GetTablesInKeyspace(Guid connectionId, string keyspaceName)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        List<Table> tables = cassandraHelper.GetTablesInKeyspace(keyspaceName);
                        return Ok(tables);
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("GetTableSchema")]
        [HttpPost]
        public IActionResult GetTableSchema(Guid connectionId, string keyspaceName, string tableName)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        Table table = cassandraHelper.GetTableSchema(keyspaceName, tableName);
                        return Ok(table);
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("AddTableColumn")]
        [HttpPost]
        // TODO: improve this call to not take this many params
        public IActionResult AddTableColumn(Guid connectionId, string keyspaceName, string tableName, string columnName, string dataType)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        cassandraHelper.AddTableColumn(keyspaceName, tableName, new Column()
                        {
                            ColumnName = columnName,
                            DataType = dataType
                        });
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("DeleteTableColumn")]
        [HttpPost]
        public IActionResult DeleteTableColumn(Guid connectionId, string keyspaceName, string tableName, string columnName)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        cassandraHelper.DeleteTableColumn(keyspaceName, tableName, columnName);
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("CreateNewTable")]
        [HttpPost]
        public IActionResult CreateNewTable(TableDTO newTable)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(newTable.ConnectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        cassandraHelper.CreateNewTable(newTable.ToModel());
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("ExecuteQuery")]
        [HttpPost]
        public IActionResult ExecuteQuery(Guid connectionId, string queryText)
        {
            try
            {
                using (ConnectionHelper connectionHelper = new ConnectionHelper())
                {
                    Connection connection = connectionHelper.GetConnectionById(connectionId);

                    using (CassandraHelper cassandraHelper = new CassandraHelper(connection))
                    {
                        Cassandra.RowSet queryResult = cassandraHelper.ExecuteQuery(queryText);
                        return Ok(queryResult);
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
