using System;
using System.Collections.Generic;
using CassandraWeb.Models;
namespace CassandraWeb.Models
{
    public class Table
    {
        public string KeyspaceName { get; set; }
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
    }
}