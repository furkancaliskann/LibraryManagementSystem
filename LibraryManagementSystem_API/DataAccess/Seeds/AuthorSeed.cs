using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class AuthorSeed : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author
                {
                    Id = 1,
                    Name = "George Orwell",
                    Bio = "George Orwell, İngiliz yazar, gazeteci ve eleştirmen olarak 20. yüzyılın en etkili isimlerinden biridir." +
                    " Özellikle totaliter rejimler, propaganda ve ifade özgürlüğü üzerine yazdığı eserlerle tanınır." +
                    " En ünlü kitapları 1984 ve Hayvan Çiftliği, politik alegorileri ve distopik temalarıyla dikkat çeker." +
                    " Orwell, yalın ve etkileyici yazım tarzıyla, toplum eleştirisini güçlü bir şekilde yansıtmıştır.",
                    IsDeleted = false,
                },

                new Author
                {
                    Id = 2,
                    Name = "J.R.R. Tolkien",
                    Bio = "J.R.R. Tolkien, fantastik edebiyatın babası olarak kabul edilir." +
                    " Orta Dünya evrenini yaratmış ve modern epik anlatıyı şekillendiren yazarlardan biri olmuştur." +
                    " Yüzüklerin Efendisi ve Hobbit kitapları, fantastik türdeki en büyük eserlerden sayılır." +
                    " Dilbilim profesörü olarak birçok yapay dil oluşturmuş ve mitolojik öğeleri edebiyata ustalıkla yansıtmıştır.",
                    IsDeleted = false,
                },
                new Author
                {
                    Id = 3,
                    Name = "Agatha Christie",
                    Bio = "Agatha Christie, \"Polisiye Romanların Kraliçesi\" olarak tanınan İngiliz yazardır." +
                    " Dedektif romanları ve gizemli hikâyeleri ile dünya çapında en çok satan yazarlardan biri olmuştur." +
                    " Hercule Poirot ve Miss Marple gibi ikonik dedektif karakterlerini yaratmıştır.",
                    IsDeleted = false,
                }
            );
        }
    }
}
