using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CopyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopies_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    FineAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "George Orwell, İngiliz yazar, gazeteci ve eleştirmen olarak 20. yüzyılın en etkili isimlerinden biridir. Özellikle totaliter rejimler, propaganda ve ifade özgürlüğü üzerine yazdığı eserlerle tanınır. En ünlü kitapları 1984 ve Hayvan Çiftliği, politik alegorileri ve distopik temalarıyla dikkat çeker. Orwell, yalın ve etkileyici yazım tarzıyla, toplum eleştirisini güçlü bir şekilde yansıtmıştır.", false, "George Orwell" },
                    { 2, "J.R.R. Tolkien, fantastik edebiyatın babası olarak kabul edilir. Orta Dünya evrenini yaratmış ve modern epik anlatıyı şekillendiren yazarlardan biri olmuştur. Yüzüklerin Efendisi ve Hobbit kitapları, fantastik türdeki en büyük eserlerden sayılır. Dilbilim profesörü olarak birçok yapay dil oluşturmuş ve mitolojik öğeleri edebiyata ustalıkla yansıtmıştır.", false, "J.R.R. Tolkien" },
                    { 3, "Agatha Christie, \"Polisiye Romanların Kraliçesi\" olarak tanınan İngiliz yazardır. Dedektif romanları ve gizemli hikâyeleri ile dünya çapında en çok satan yazarlardan biri olmuştur. Hercule Poirot ve Miss Marple gibi ikonik dedektif karakterlerini yaratmıştır.", false, "Agatha Christie" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Distopya" },
                    { 2, false, "Siyasi Satir" },
                    { 3, false, "Tarihi Kurgu" },
                    { 4, false, "Fantastik" },
                    { 5, false, "Polisiye" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Secker & Warburg" },
                    { 2, false, "Harper & Brothers" },
                    { 3, false, "Allen & Unwin" },
                    { 4, false, "Collins Crime Club" }
                });

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "IsDeleted", "Location" },
                values: new object[,]
                {
                    { 1, false, "Shelf-001" },
                    { 2, false, "Shelf-002" },
                    { 3, false, "Shelf-003" },
                    { 4, false, "Shelf-004" },
                    { 5, false, "Shelf-005" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "IsDeleted", "Name", "PasswordHash", "Phone", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3632), "admin@example.com", false, "Admin", new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 }, "+90 000 000 0000", "Admin", "Admin" },
                    { 2, null, new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3641), "employee@example.com", false, "Employee", new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 }, "+90 111 111 1111", "Employee", "Employee" },
                    { 3, "Selçuklu/KONYA", new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3642), "furkancaliskan2022@gmail.com", false, "Furkan", new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 }, "+90 542 523 4042", "Member", "Çalışkan" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Description", "ISBN", "IsDeleted", "PublicationDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8326), "Distopik bir dünyada \"Büyük Birader\" yönetimini ele alır.", "1000000001", false, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1984" },
                    { 2, 1, 2, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8335), "Sovyetler Birliği eleştirisi içeren bir fabl.", "1000000002", false, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hayvan Çiftliği" },
                    { 3, 1, 3, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8337), "İngiliz sömürgeciliği üzerine bir roman.", "1000000003", false, new DateTime(1934, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Burma Günleri" },
                    { 4, 2, 4, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8338), "Orta Dünya'da geçen epik bir macera.", "1000000004", false, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Yüzüklerin Efendisi" },
                    { 5, 2, 4, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8339), "Bilbo Baggins'in macerasını anlatan öncül hikâye.", "1000000005", false, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Hobbit" },
                    { 6, 2, 4, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8340), "Orta Dünya'nın tarihini anlatan eser.", "1000000006", false, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Silmarillion" },
                    { 7, 3, 5, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8342), "Bir trende işlenen cinayetin çözülmesi.", "1000000007", false, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Doğu Ekspresinde Cinayet" },
                    { 8, 3, 5, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8344), "Gizemli bir adadaki ölümler.", "1000000008", false, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "On Küçük Zenci" },
                    { 9, 3, 5, new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8345), "Şok edici bir sonla biten dedektif hikayesi.", "1000000009", false, new DateTime(1926, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Roger Ackroyd Cinayeti" }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "BookId", "CopyNumber", "IsDeleted", "ShelfId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "001", false, 1, 1 },
                    { 2, 1, "002", false, 1, 0 },
                    { 3, 1, "003", false, 1, 1 },
                    { 4, 2, "001", false, 1, 0 },
                    { 5, 2, "002", false, 1, 0 },
                    { 6, 3, "001", false, 1, 0 },
                    { 7, 4, "001", false, 2, 0 },
                    { 8, 4, "002", false, 2, 0 },
                    { 9, 5, "001", false, 2, 0 },
                    { 10, 6, "001", false, 2, 0 },
                    { 11, 6, "002", false, 2, 0 },
                    { 12, 7, "001", false, 3, 0 },
                    { 13, 8, "001", false, 3, 0 },
                    { 14, 8, "002", false, 3, 0 },
                    { 15, 9, "001", false, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "DueDate", "IsDeleted", "LoanDate", "ReturnDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3 },
                    { 2, 4, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 3, 5, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookCopyId", "IsDeleted", "ReservationDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 7, false, new DateTime(2025, 3, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 2, 8, false, new DateTime(2025, 3, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "Id", "FineAmount", "IsDeleted", "LoanId", "Paid", "PaidDate" },
                values: new object[] { 1, 5m, false, 3, false, null });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookId",
                table: "BookCopies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_ShelfId",
                table: "BookCopies",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_LoanId",
                table: "Fines",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyId",
                table: "Loans",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookCopyId",
                table: "Reservations",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
