using CassandraWeb.Models;
using System.Collections.Generic;
namespace CassandraWeb.Models
{
    public class Keyspace
    {
        public string KeyspaceName { get; set; }
        public List<Table> Tables { get; set; }
    }
}