using System;
using System.Collections.Generic;
using CassandraWeb.Models;
using Newtonsoft.Json;
namespace CassandraWeb.Models
{
    [JsonObject, JsonArray]
    public class TableDTO
    {
        [JsonProperty("connectionId")]
        public Guid ConnectionId { get; set; }
        [JsonProperty("keyspaceName")]
        public string KeyspaceName { get; set; }
        [JsonProperty("tableName")]
        public string TableName { get; set; }
        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        public Table ToModel()
        {
            return new Table()
            {
                ConnectionId = ConnectionId,
                KeyspaceName = KeyspaceName,
                TableName = TableName,
                Columns = Columns
            };
        }
    }
}