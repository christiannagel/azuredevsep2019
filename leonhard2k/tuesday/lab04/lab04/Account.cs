using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class Account
    {
        public Account()
        {
            BlobContainer = new HashSet<BlobContainer>();
            QueueContainer = new HashSet<QueueContainer>();
            TableContainer = new HashSet<TableContainer>();
        }

        public string Name { get; set; }
        public byte[] SecretKey { get; set; }
        public byte[] QueueServiceSettings { get; set; }
        public byte[] BlobServiceSettings { get; set; }
        public byte[] TableServiceSettings { get; set; }
        public byte[] SecondaryKey { get; set; }
        public bool? SecondaryReadEnabled { get; set; }

        public ICollection<BlobContainer> BlobContainer { get; set; }
        public ICollection<QueueContainer> QueueContainer { get; set; }
        public ICollection<TableContainer> TableContainer { get; set; }
    }
}
