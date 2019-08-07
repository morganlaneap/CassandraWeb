using Microsoft.AspNetCore.Mvc;
using System;
using CassandraWeb.Helpers;
using CassandraWeb.Models;
using System.Collections.Generic;
namespace CassandraWeb.Controllers
{
    [Route("api/Cassandra")]
    public class CassandraController : Controller
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
    }
}
