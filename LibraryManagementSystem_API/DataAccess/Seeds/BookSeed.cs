using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class BookSeed : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Description = "Distopik bir dünyada \"Büyük Birader\" yönetimini ele alır.",
                    AuthorId = 1,
                    PublisherId = 1,
                    CategoryId = 1,
                    ISBN = "1000000001",
                    PublicationDate = new DateTime(1949, 06, 08),
                },

                new Book
                {
                    Id = 2,
                    Title = "Hayvan Çiftliği",
                    Description = "Sovyetler Birliği eleştirisi içeren bir fabl.",
                    AuthorId = 1,
                    PublisherId = 1,
                    CategoryId = 2,
                    ISBN = "1000000002",
                    PublicationDate = new DateTime(1945, 08, 17),
                },

                new Book
                {
                    Id = 3,
                    Title = "Burma Günleri",
                    Description = "İngiliz sömürgeciliği üzerine bir roman.",
                    AuthorId = 1,
                    PublisherId = 2,
                    CategoryId = 3,
                    ISBN = "1000000003",
                    PublicationDate = new DateTime(1934, 10, 01),
                },

                new Book
                {
                    Id = 4,
                    Title = "Yüzüklerin Efendisi",
                    Description = "Orta Dünya'da geçen epik bir macera.",
                    AuthorId = 2,
                    PublisherId = 3,
                    CategoryId = 4,
                    ISBN = "1000000004",
                    PublicationDate = new DateTime(1954, 07, 29),
                },

                new Book
                {
                    Id = 5,
                    Title = "Hobbit",
                    Description = "Bilbo Baggins'in macerasını anlatan öncül hikâye.",
                    AuthorId = 2,
                    PublisherId = 3,
                    CategoryId = 4,
                    ISBN = "1000000005",
                    PublicationDate = new DateTime(1937, 09, 21),
                },

                new Book
                {
                    Id = 6,
                    Title = "Silmarillion",
                    Description = "Orta Dünya'nın tarihini anlatan eser.",
                    AuthorId = 2,
                    PublisherId = 3,
                    CategoryId = 4,
                    ISBN = "1000000006",
                    PublicationDate = new DateTime(1977, 09, 15),
                },

                new Book
                {
                    Id = 7,
                    Title = "Doğu Ekspresinde Cinayet",
                    Description = "Bir trende işlenen cinayetin çözülmesi.",
                    AuthorId = 3,
                    PublisherId = 4,
                    CategoryId = 5,
                    ISBN = "1000000007",
                    PublicationDate = new DateTime(1934, 01, 01),
                },

                new Book
                {
                    Id = 8,
                    Title = "On Küçük Zenci",
                    Description = "Gizemli bir adadaki ölümler.",
                    AuthorId = 3,
                    PublisherId = 4,
                    CategoryId = 5,
                    ISBN = "1000000008",
                    PublicationDate = new DateTime(1939, 11, 06),
                },

                new Book
                {
                    Id = 9,
                    Title = "Roger Ackroyd Cinayeti",
                    Description = "Şok edici bir sonla biten dedektif hikayesi.",
                    AuthorId = 3,
                    PublisherId = 4,
                    CategoryId = 5,
                    ISBN = "1000000009",
                    PublicationDate = new DateTime(1926, 06, 01),
                }
            );
        }
    }
}
