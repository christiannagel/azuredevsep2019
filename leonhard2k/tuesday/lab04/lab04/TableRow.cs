using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class TableRow
    {
        public string AccountName { get; set; }
        public string TableName { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }

        public TableContainer TableContainer { get; set; }
    }
}
