using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class TableContainer
    {
        public TableContainer()
        {
            TableRow = new HashSet<TableRow>();
        }

        public string AccountName { get; set; }
        public string TableName { get; set; }
        public DateTime LastModificationTime { get; set; }
        public byte[] ServiceMetadata { get; set; }
        public byte[] Metadata { get; set; }
        public string CasePreservedTableName { get; set; }

        public Account AccountNameNavigation { get; set; }
        public ICollection<TableRow> TableRow { get; set; }
    }
}
