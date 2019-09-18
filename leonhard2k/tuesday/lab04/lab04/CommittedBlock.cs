using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class CommittedBlock
    {
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
        public DateTime VersionTimestamp { get; set; }
        public long Offset { get; set; }
        public string BlockId { get; set; }
        public long? Length { get; set; }
        public DateTime? BlockVersion { get; set; }

        public Blob Blob { get; set; }
    }
}
