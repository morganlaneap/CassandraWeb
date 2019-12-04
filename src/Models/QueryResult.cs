using System.Collections.Generic;
namespace CassandraWeb
{
    public class QueryResult
    {
        public List<QueryResultColumn> Columns { get; set; }
        public List<QueryResultRow> Rows { get; set; }
        public QueryResult()
        {
            Columns = new List<QueryResultColumn>();
            Rows = new List<QueryResultRow>();
        }
    }

    public class QueryResultColumn
    {
        public string ColumnName { get; set; }
        public QueryResultColumn(string columnName)
        {
            ColumnName = columnName;
        }
    }

    public class QueryResultRow
    {
        public List<QueryResultRowValue> RowValues { get; set; }
        public QueryResultRow()
        {
            RowValues = new List<QueryResultRowValue>();
        }
    }

    public class QueryResultRowValue
    {
        public object Value { get; set; }
        public QueryResultRowValue(object value)
        {
            Value = value;
        }
    }
}