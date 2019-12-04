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
                return BadRequest(exception);
            }
        }

        // TODO: this should be receiving json data
        [Route("NewConnection")]
        [HttpPost]
        public IActionResult NewConnection(Connection data)
        {
            try
            {
                using (ConnectionHelper helper = new ConnectionHelper())
                {
                    Connection newConnection = helper.NewConnection(data);
                    return Ok(newConnection);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [Route("DeleteConnection")]
        [HttpPost]
        public IActionResult DeleteConnection(Guid connectionId) {
            try
            {
                using (ConnectionHelper helper = new ConnectionHelper())
                {
                    helper.DeleteConnection(connectionId);
                    return Ok(connectionId);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
