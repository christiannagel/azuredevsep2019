using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class QueueMessage
    {
        public string AccountName { get; set; }
        public string QueueName { get; set; }
        public DateTime VisibilityStartTime { get; set; }
        public Guid MessageId { get; set; }
        public DateTime ExpiryTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public int? DequeueCount { get; set; }
        public byte[] Data { get; set; }

        public QueueContainer QueueContainer { get; set; }
    }
}
