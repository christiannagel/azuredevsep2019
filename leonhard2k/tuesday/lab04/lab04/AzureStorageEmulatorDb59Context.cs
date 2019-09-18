using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab04
{
    public partial class AzureStorageEmulatorDb59Context : DbContext
    {
        public AzureStorageEmulatorDb59Context()
        {
        }

        public AzureStorageEmulatorDb59Context(DbContextOptions<AzureStorageEmulatorDb59Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Blob> Blob { get; set; }
        public virtual DbSet<BlobContainer> BlobContainer { get; set; }
        public virtual DbSet<BlockData> BlockData { get; set; }
        public virtual DbSet<CommittedBlock> CommittedBlock { get; set; }
        public virtual DbSet<CurrentPage> CurrentPage { get; set; }
        public virtual DbSet<DeletedAccount> DeletedAccount { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<QueueContainer> QueueContainer { get; set; }
        public virtual DbSet<QueueMessage> QueueMessage { get; set; }
        public virtual DbSet<TableContainer> TableContainer { get; set; }
        public virtual DbSet<TableRow> TableRow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AzureStorageEmulatorDb59;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SecondaryKey).HasMaxLength(256);

                entity.Property(e => e.SecondaryReadEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.SecretKey).HasMaxLength(256);
            });

            modelBuilder.Entity<Blob>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp });


                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.BlobName).HasMaxLength(256);

                entity.Property(e => e.VersionTimestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('9999-12-31T23:59:59.997')");

                entity.Property(e => e.ContentMd5)
                    .HasColumnName("ContentMD5")
                    .HasMaxLength(16);

                entity.Property(e => e.ContentType)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DirectoryPath).HasMaxLength(260);

                entity.Property(e => e.FileName).HasMaxLength(260);

                entity.Property(e => e.GenerationId)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.IsLeaseOp).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LeaseDuration).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaseEndTime).HasColumnType("datetime");

                entity.Property(e => e.LeaseState).HasDefaultValueSql("((0))");

                entity.Property(e => e.UncommittedBlockIdLength).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BlobContainer)
                    .WithMany(p => p.Blob)
                    .HasForeignKey(d => new { d.AccountName, d.ContainerName })
                    .HasConstraintName("BlobContainer_Blob");
            });

            modelBuilder.Entity<BlobContainer>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.IsLeaseOp).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LeaseDuration).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaseEndTime).HasColumnType("datetime");

                entity.Property(e => e.LeaseState).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AccountNameNavigation)
                    .WithMany(p => p.BlobContainer)
                    .HasForeignKey(d => d.AccountName)
                    .HasConstraintName("Account_BlobContainer");
            });

            modelBuilder.Entity<BlockData>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp, e.IsCommitted, e.BlockId });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.BlobName).HasMaxLength(256);

                entity.Property(e => e.VersionTimestamp).HasColumnType("datetime");

                entity.Property(e => e.BlockId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath).HasMaxLength(260);
            });

            modelBuilder.Entity<CommittedBlock>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp, e.Offset });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.BlobName).HasMaxLength(256);

                entity.Property(e => e.VersionTimestamp).HasColumnType("datetime");

                entity.Property(e => e.BlockId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BlockVersion).HasColumnType("datetime");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.CommittedBlock)
                    .HasForeignKey(d => new { d.AccountName, d.ContainerName, d.BlobName, d.VersionTimestamp })
                    .HasConstraintName("BlockBlob_CommittedBlock");
            });

            modelBuilder.Entity<CurrentPage>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp, e.StartOffset });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.BlobName).HasMaxLength(256);

                entity.Property(e => e.VersionTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.CurrentPage)
                    .HasForeignKey(d => new { d.AccountName, d.ContainerName, d.BlobName, d.VersionTimestamp })
                    .HasConstraintName("PageBlob_CurrentPage");
            });

            modelBuilder.Entity<DeletedAccount>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.ContainerName, e.BlobName, e.VersionTimestamp, e.StartOffset });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.ContainerName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.BlobName).HasMaxLength(256);

                entity.Property(e => e.VersionTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.Page)
                    .HasForeignKey(d => new { d.AccountName, d.ContainerName, d.BlobName, d.VersionTimestamp })
                    .HasConstraintName("PageBlob_Page");
            });

            modelBuilder.Entity<QueueContainer>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.QueueName });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.QueueName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.AccountNameNavigation)
                    .WithMany(p => p.QueueContainer)
                    .HasForeignKey(d => d.AccountName)
                    .HasConstraintName("Account_QueueContainer");
            });

            modelBuilder.Entity<QueueMessage>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.QueueName, e.VisibilityStartTime, e.MessageId });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.QueueName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.VisibilityStartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.ExpiryTime).HasColumnType("datetime");

                entity.Property(e => e.InsertionTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.QueueContainer)
                    .WithMany(p => p.QueueMessage)
                    .HasForeignKey(d => new { d.AccountName, d.QueueName })
                    .HasConstraintName("QueueContainer_QueueMessage");
            });

            modelBuilder.Entity<TableContainer>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.TableName });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.CasePreservedTableName)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.AccountNameNavigation)
                    .WithMany(p => p.TableContainer)
                    .HasForeignKey(d => d.AccountName)
                    .HasConstraintName("Account_TableContainer");
            });

            modelBuilder.Entity<TableRow>(entity =>
            {
                entity.HasKey(e => new { e.AccountName, e.TableName, e.PartitionKey, e.RowKey });

                entity.Property(e => e.AccountName)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.PartitionKey).HasMaxLength(256);

                entity.Property(e => e.RowKey).HasMaxLength(256);

                entity.Property(e => e.Data).HasColumnType("xml");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.TableContainer)
                    .WithMany(p => p.TableRow)
                    .HasForeignKey(d => new { d.AccountName, d.TableName })
                    .HasConstraintName("TableContainer_TableRow");
            });
        }
    }
}
