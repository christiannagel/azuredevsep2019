using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class BlobContainer
    {
        public BlobContainer()
        {
            Blob = new HashSet<Blob>();
        }

        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public DateTime LastModificationTime { get; set; }
        public byte[] ServiceMetadata { get; set; }
        public byte[] Metadata { get; set; }
        public Guid? LeaseId { get; set; }
        public int? LeaseState { get; set; }
        public long? LeaseDuration { get; set; }
        public DateTime? LeaseEndTime { get; set; }
        public bool? IsLeaseOp { get; set; }

        public Account AccountNameNavigation { get; set; }
        public ICollection<Blob> Blob { get; set; }
    }
}
