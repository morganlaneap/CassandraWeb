using Microsoft.AspNetCore.Mvc;
using System;
using CassandraWeb.Helpers;
using CassandraWeb.Models;
using System.Collections.Generic;
namespace CassandraWeb.Controllers
{
    [Route("api/Connection")]
    public class ConnectionController : Controller
    {
        [Route("GetConnections")]
        [HttpPost]
        public IActionResult GetConnections()
        {
            try
            {
                using (ConnectionHelper helper = new ConnectionHelper())
                {
                    List<Connection> connections = helper.GetConnections();
                    return Ok(connections);
                }
            }
            catch (Exception exception)
            {
                return NotFound(exception);
            }
        }
    }
}
