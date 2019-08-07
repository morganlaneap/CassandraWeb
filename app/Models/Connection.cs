using SQLite;
namespace CassandraWeb.Models
{
    [Table("Connections")]
    public class Connection
    {
        [PrimaryKey, AutoIncrement]
        public int ConnectionId { get; set; }
        public string ConnectionName { get; set; }
        public string ContactPoint { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}