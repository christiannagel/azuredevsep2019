﻿using System;
using System.Collections.Generic;

namespace lab04
{
    public partial class Blob
    {
        public Blob()
        {
            CommittedBlock = new HashSet<CommittedBlock>();
            CurrentPage = new HashSet<CurrentPage>();
            Page = new HashSet<Page>();
        }

        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
        public DateTime VersionTimestamp { get; set; }
        public int? BlobType { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public long? ContentCrc64 { get; set; }
        public byte[] ContentMd5 { get; set; }
        public byte[] ServiceMetadata { get; set; }
        public byte[] Metadata { get; set; }
        public Guid? LeaseId { get; set; }
        public long? LeaseDuration { get; set; }
        public DateTime? LeaseEndTime { get; set; }
        public long? SequenceNumber { get; set; }
        public int? LeaseState { get; set; }
        public bool? IsLeaseOp { get; set; }
        public int SnapshotCount { get; set; }
        public string GenerationId { get; set; }
        public bool? IsCommitted { get; set; }
        public bool? HasBlock { get; set; }
        public int? UncommittedBlockIdLength { get; set; }
        public string DirectoryPath { get; set; }
        public long? MaxSize { get; set; }
        public string FileName { get; set; }
        public bool? IsIncrementalCopy { get; set; }

        public BlobContainer BlobContainer { get; set; }
        public ICollection<CommittedBlock> CommittedBlock { get; set; }
        public ICollection<CurrentPage> CurrentPage { get; set; }
        public ICollection<Page> Page { get; set; }
    }
}
