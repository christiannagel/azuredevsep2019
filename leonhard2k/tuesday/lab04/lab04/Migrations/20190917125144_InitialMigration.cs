using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab04.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Name = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    SecretKey = table.Column<byte[]>(maxLength: 256, nullable: true),
                    QueueServiceSettings = table.Column<byte[]>(nullable: true),
                    BlobServiceSettings = table.Column<byte[]>(nullable: true),
                    TableServiceSettings = table.Column<byte[]>(nullable: true),
                    SecondaryKey = table.Column<byte[]>(maxLength: 256, nullable: true),
                    SecondaryReadEnabled = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "BlockData",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    BlobName = table.Column<string>(maxLength: 256, nullable: false),
                    VersionTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCommitted = table.Column<bool>(nullable: false),
                    BlockId = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Length = table.Column<long>(nullable: true),
                    StartOffset = table.Column<long>(nullable: false),
                    FilePath = table.Column<string>(maxLength: 260, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockData", x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp, x.IsCommitted, x.BlockId });
                });

            migrationBuilder.CreateTable(
                name: "DeletedAccount",
                columns: table => new
                {
                    Name = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedAccount", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "BlobContainer",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ServiceMetadata = table.Column<byte[]>(nullable: true),
                    Metadata = table.Column<byte[]>(nullable: true),
                    LeaseId = table.Column<Guid>(nullable: true),
                    LeaseState = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    LeaseDuration = table.Column<long>(nullable: true, defaultValueSql: "((0))"),
                    LeaseEndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsLeaseOp = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlobContainer", x => new { x.AccountName, x.ContainerName });
                    table.ForeignKey(
                        name: "Account_BlobContainer",
                        column: x => x.AccountName,
                        principalTable: "Account",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueContainer",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    QueueName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ServiceMetadata = table.Column<byte[]>(nullable: true),
                    Metadata = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueContainer", x => new { x.AccountName, x.QueueName });
                    table.ForeignKey(
                        name: "Account_QueueContainer",
                        column: x => x.AccountName,
                        principalTable: "Account",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableContainer",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    TableName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ServiceMetadata = table.Column<byte[]>(nullable: true),
                    Metadata = table.Column<byte[]>(nullable: true),
                    CasePreservedTableName = table.Column<string>(unicode: false, maxLength: 63, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableContainer", x => new { x.AccountName, x.TableName });
                    table.ForeignKey(
                        name: "Account_TableContainer",
                        column: x => x.AccountName,
                        principalTable: "Account",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blob",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    BlobName = table.Column<string>(maxLength: 256, nullable: false),
                    VersionTimestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('9999-12-31T23:59:59.997')"),
                    BlobType = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getutcdate())"),
                    ContentLength = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    ContentCrc64 = table.Column<long>(nullable: true),
                    ContentMD5 = table.Column<byte[]>(maxLength: 16, nullable: true),
                    ServiceMetadata = table.Column<byte[]>(nullable: true),
                    Metadata = table.Column<byte[]>(nullable: true),
                    LeaseId = table.Column<Guid>(nullable: true),
                    LeaseDuration = table.Column<long>(nullable: true, defaultValueSql: "((0))"),
                    LeaseEndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    SequenceNumber = table.Column<long>(nullable: true),
                    LeaseState = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    IsLeaseOp = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    SnapshotCount = table.Column<int>(nullable: false),
                    GenerationId = table.Column<string>(maxLength: 4000, nullable: false),
                    IsCommitted = table.Column<bool>(nullable: true),
                    HasBlock = table.Column<bool>(nullable: true),
                    UncommittedBlockIdLength = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    DirectoryPath = table.Column<string>(maxLength: 260, nullable: true),
                    MaxSize = table.Column<long>(nullable: true),
                    FileName = table.Column<string>(maxLength: 260, nullable: true),
                    IsIncrementalCopy = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blob", x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp });
                    table.ForeignKey(
                        name: "BlobContainer_Blob",
                        columns: x => new { x.AccountName, x.ContainerName },
                        principalTable: "BlobContainer",
                        principalColumns: new[] { "AccountName", "ContainerName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueMessage",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    QueueName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    VisibilityStartTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    MessageId = table.Column<Guid>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertionTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    DequeueCount = table.Column<int>(nullable: true),
                    Data = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueMessage", x => new { x.AccountName, x.QueueName, x.VisibilityStartTime, x.MessageId });
                    table.ForeignKey(
                        name: "QueueContainer_QueueMessage",
                        columns: x => new { x.AccountName, x.QueueName },
                        principalTable: "QueueContainer",
                        principalColumns: new[] { "AccountName", "QueueName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableRow",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    TableName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    PartitionKey = table.Column<string>(maxLength: 256, nullable: false),
                    RowKey = table.Column<string>(maxLength: 256, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    Data = table.Column<string>(type: "xml", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRow", x => new { x.AccountName, x.TableName, x.PartitionKey, x.RowKey });
                    table.ForeignKey(
                        name: "TableContainer_TableRow",
                        columns: x => new { x.AccountName, x.TableName },
                        principalTable: "TableContainer",
                        principalColumns: new[] { "AccountName", "TableName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommittedBlock",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    BlobName = table.Column<string>(maxLength: 256, nullable: false),
                    VersionTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Offset = table.Column<long>(nullable: false),
                    BlockId = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Length = table.Column<long>(nullable: true),
                    BlockVersion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommittedBlock", x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp, x.Offset });
                    table.ForeignKey(
                        name: "BlockBlob_CommittedBlock",
                        columns: x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp },
                        principalTable: "Blob",
                        principalColumns: new[] { "AccountName", "ContainerName", "BlobName", "VersionTimestamp" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentPage",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    BlobName = table.Column<string>(maxLength: 256, nullable: false),
                    VersionTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartOffset = table.Column<long>(nullable: false),
                    EndOffset = table.Column<long>(nullable: true),
                    SnapshotCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentPage", x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp, x.StartOffset });
                    table.ForeignKey(
                        name: "PageBlob_CurrentPage",
                        columns: x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp },
                        principalTable: "Blob",
                        principalColumns: new[] { "AccountName", "ContainerName", "BlobName", "VersionTimestamp" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    AccountName = table.Column<string>(unicode: false, maxLength: 24, nullable: false),
                    ContainerName = table.Column<string>(unicode: false, maxLength: 63, nullable: false),
                    BlobName = table.Column<string>(maxLength: 256, nullable: false),
                    VersionTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartOffset = table.Column<long>(nullable: false),
                    EndOffset = table.Column<long>(nullable: true),
                    FileOffset = table.Column<long>(nullable: true),
                    SnapshotCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp, x.StartOffset });
                    table.ForeignKey(
                        name: "PageBlob_Page",
                        columns: x => new { x.AccountName, x.ContainerName, x.BlobName, x.VersionTimestamp },
                        principalTable: "Blob",
                        principalColumns: new[] { "AccountName", "ContainerName", "BlobName", "VersionTimestamp" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockData");

            migrationBuilder.DropTable(
                name: "CommittedBlock");

            migrationBuilder.DropTable(
                name: "CurrentPage");

            migrationBuilder.DropTable(
                name: "DeletedAccount");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "QueueMessage");

            migrationBuilder.DropTable(
                name: "TableRow");

            migrationBuilder.DropTable(
                name: "Blob");

            migrationBuilder.DropTable(
                name: "QueueContainer");

            migrationBuilder.DropTable(
                name: "TableContainer");

            migrationBuilder.DropTable(
                name: "BlobContainer");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
