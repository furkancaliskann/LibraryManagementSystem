﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "George Orwell, İngiliz yazar, gazeteci ve eleştirmen olarak 20. yüzyılın en etkili isimlerinden biridir. Özellikle totaliter rejimler, propaganda ve ifade özgürlüğü üzerine yazdığı eserlerle tanınır. En ünlü kitapları 1984 ve Hayvan Çiftliği, politik alegorileri ve distopik temalarıyla dikkat çeker. Orwell, yalın ve etkileyici yazım tarzıyla, toplum eleştirisini güçlü bir şekilde yansıtmıştır.",
                            IsDeleted = false,
                            Name = "George Orwell"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "J.R.R. Tolkien, fantastik edebiyatın babası olarak kabul edilir. Orta Dünya evrenini yaratmış ve modern epik anlatıyı şekillendiren yazarlardan biri olmuştur. Yüzüklerin Efendisi ve Hobbit kitapları, fantastik türdeki en büyük eserlerden sayılır. Dilbilim profesörü olarak birçok yapay dil oluşturmuş ve mitolojik öğeleri edebiyata ustalıkla yansıtmıştır.",
                            IsDeleted = false,
                            Name = "J.R.R. Tolkien"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Agatha Christie, \"Polisiye Romanların Kraliçesi\" olarak tanınan İngiliz yazardır. Dedektif romanları ve gizemli hikâyeleri ile dünya çapında en çok satan yazarlardan biri olmuştur. Hercule Poirot ve Miss Marple gibi ikonik dedektif karakterlerini yaratmıştır.",
                            IsDeleted = false,
                            Name = "Agatha Christie"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ISBN")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8326),
                            Description = "Distopik bir dünyada \"Büyük Birader\" yönetimini ele alır.",
                            ISBN = "1000000001",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8335),
                            Description = "Sovyetler Birliği eleştirisi içeren bir fabl.",
                            ISBN = "1000000002",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Title = "Hayvan Çiftliği"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8337),
                            Description = "İngiliz sömürgeciliği üzerine bir roman.",
                            ISBN = "1000000003",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1934, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            Title = "Burma Günleri"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8338),
                            Description = "Orta Dünya'da geçen epik bir macera.",
                            ISBN = "1000000004",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Title = "Yüzüklerin Efendisi"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8339),
                            Description = "Bilbo Baggins'in macerasını anlatan öncül hikâye.",
                            ISBN = "1000000005",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Title = "Hobbit"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8340),
                            Description = "Orta Dünya'nın tarihini anlatan eser.",
                            ISBN = "1000000006",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Title = "Silmarillion"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            CategoryId = 5,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8342),
                            Description = "Bir trende işlenen cinayetin çözülmesi.",
                            ISBN = "1000000007",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 4,
                            Title = "Doğu Ekspresinde Cinayet"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 3,
                            CategoryId = 5,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8344),
                            Description = "Gizemli bir adadaki ölümler.",
                            ISBN = "1000000008",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 4,
                            Title = "On Küçük Zenci"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 3,
                            CategoryId = 5,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 745, DateTimeKind.Utc).AddTicks(8345),
                            Description = "Şok edici bir sonla biten dedektif hikayesi.",
                            ISBN = "1000000009",
                            IsDeleted = false,
                            PublicationDate = new DateTime(1926, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 4,
                            Title = "Roger Ackroyd Cinayeti"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("CopyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ShelfId");

                    b.ToTable("BookCopies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            CopyNumber = "002",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            BookId = 1,
                            CopyNumber = "003",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 2,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            BookId = 2,
                            CopyNumber = "002",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            BookId = 3,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 7,
                            BookId = 4,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 8,
                            BookId = 4,
                            CopyNumber = "002",
                            IsDeleted = false,
                            ShelfId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 9,
                            BookId = 5,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 10,
                            BookId = 6,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 11,
                            BookId = 6,
                            CopyNumber = "002",
                            IsDeleted = false,
                            ShelfId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 12,
                            BookId = 7,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 13,
                            BookId = 8,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 14,
                            BookId = 8,
                            CopyNumber = "002",
                            IsDeleted = false,
                            ShelfId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 15,
                            BookId = 9,
                            CopyNumber = "001",
                            IsDeleted = false,
                            ShelfId = 3,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Distopya"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Siyasi Satir"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Tarihi Kurgu"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Fantastik"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Polisiye"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("FineAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("Fines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FineAmount = 5m,
                            IsDeleted = false,
                            LoanId = 3,
                            Paid = false
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookCopyId = 1,
                            DueDate = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LoanDate = new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            BookCopyId = 4,
                            DueDate = new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LoanDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            BookCopyId = 5,
                            DueDate = new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LoanDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Entities.Concrete.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Secker & Warburg"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Harper & Brothers"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Allen & Unwin"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Collins Crime Club"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookCopyId = 7,
                            IsDeleted = false,
                            ReservationDate = new DateTime(2025, 3, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            BookCopyId = 8,
                            IsDeleted = false,
                            ReservationDate = new DateTime(2025, 3, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shelves");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Location = "Shelf-001"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Location = "Shelf-002"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Location = "Shelf-003"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Location = "Shelf-004"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Location = "Shelf-005"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3632),
                            Email = "admin@example.com",
                            IsDeleted = false,
                            Name = "Admin",
                            PasswordHash = new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 },
                            Phone = "+90 000 000 0000",
                            Role = "Admin",
                            Surname = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3641),
                            Email = "employee@example.com",
                            IsDeleted = false,
                            Name = "Employee",
                            PasswordHash = new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 },
                            Phone = "+90 111 111 1111",
                            Role = "Employee",
                            Surname = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Selçuklu/KONYA",
                            CreatedAt = new DateTime(2025, 3, 19, 12, 13, 59, 746, DateTimeKind.Utc).AddTicks(3642),
                            Email = "furkancaliskan2022@gmail.com",
                            IsDeleted = false,
                            Name = "Furkan",
                            PasswordHash = new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 },
                            Phone = "+90 542 523 4042",
                            Role = "Member",
                            Surname = "Çalışkan"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.HasOne("Entities.Concrete.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Entities.Concrete.BookCopy", b =>
                {
                    b.HasOne("Entities.Concrete.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Shelf", "Shelf")
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Entities.Concrete.Fine", b =>
                {
                    b.HasOne("Entities.Concrete.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Entities.Concrete.Loan", b =>
                {
                    b.HasOne("Entities.Concrete.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Reservation", b =>
                {
                    b.HasOne("Entities.Concrete.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
