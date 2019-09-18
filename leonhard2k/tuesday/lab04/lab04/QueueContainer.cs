using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class QueueContainer
    {
        public QueueContainer()
        {
            QueueMessage = new HashSet<QueueMessage>();
        }

        public string AccountName { get; set; }
        public string QueueName { get; set; }
        public DateTime LastModificationTime { get; set; }
        public byte[] ServiceMetadata { get; set; }
        public byte[] Metadata { get; set; }

        public Account AccountNameNavigation { get; set; }
        public ICollection<QueueMessage> QueueMessage { get; set; }
    }
}
