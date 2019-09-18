using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class Page
    {
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
        public DateTime VersionTimestamp { get; set; }
        public long StartOffset { get; set; }
        public long? EndOffset { get; set; }
        public long? FileOffset { get; set; }
        public int SnapshotCount { get; set; }

        public Blob Blob { get; set; }
    }
}
