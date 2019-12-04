using System;
using System.Collections.Generic;
namespace CassandraWeb.Models
{
    public class Table
    {
        public Guid ConnectionId { get; set; }
        public string KeyspaceName { get; set; }
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
    }
}