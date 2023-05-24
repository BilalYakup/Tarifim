using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifim.Data.Entities
{
    public class FoodEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }
    }
    public class FoodEntityConfiguration : BaseConfiguration<FoodEntity>
    {
        public override void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired(false);
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasData
                (
                new FoodEntity {Id=1,Name="Cevizli Baklava",Content= "Şerbeti için;\r\n\r\n4 su bardağı şeker\r\n4 su bardağı su\r\n1 tatlı kaşığı limon suyu\r\nHamuru için;\r\n\r\n3,5 su bardağı un\r\n2 adet yumurta\r\n1 çay bardağı sıvı yağ\r\n1 çay bardağı süt\r\n1 yemek kaşığı sirke\r\nÇay kaşığı ucu ile Tuz\r\nHamuru açmak için;\r\n\r\nNişasta\r\nArası için;\r\n\r\n2 su bardağı ceviz kırığı\r\nÜzerine;\r\n\r\n250g tereyağı\r\nYarım çay bardağı sıvı yağ",Description= "lk olarak tatlımızın şerbetini hazırlayalım. Bunun için uygun bir tencereye şeker ve suyu alalım.\r\nKarıştırdıktan sonra şerbetimizi kaynamaya bırakalım.\r\nSürenin sonunda limon suyunu da ilave ederek bir kaç dakika daha kaynatalım ve ocaktan alalım.\r\nBaklava hamuru için yoğurma kabına yumurta, sıvı yağ, süt, sirke ve tuzu alarak karıştıralım.\r\nDaha sonra unu yavaş yavaş  ilave ederek hamurumuzu ele yapışmayan bir kıvam alıncaya  kadar yoğuralım.\r\nYoğurduğumuz hamurumuzun üzerini streçleyerek 30 dakika kadar dinlenmeye bırakalım. Bu şekilde hamurumuz çok daha kolay açılacaktır.\r\nSüre sonunda hamurumuzu tezgaha alalım ve bir iki kere daha yoğurarak toparlayalım.\r\nHamurumuzu ilk önce eşit bir şekilde 3 parçaya ayıralım, daha sonra her parçayı da 9 parçaya ayıralım.",ImagePath= "cevizlibaklava-390e4656-bdea-4c3e-ba81-124a5953ed9b-c3c573e6-77c0-4880-9c8c-2ef936d5ca35.png",CategoryId=4 },

                 new FoodEntity { Id = 2, Name = "Köfte", Content = "500 gr orta yağlı kıyma\r\n1 orta boy rendelenmiş soğan\r\n1 diş sarımsak\r\n1 adet yumurta\r\nYarım çay bardağı galeta unu\r\n1 yemek kaşığı sıvı yağ\r\n1 avuç ince kıyılmış maydanoz\r\n1,5 çay kaşığı tuz\r\nYarım çay kaşığı karabiber\r\n1 çay kaşığı kimyon", Description = "Uygun bir yoğurma kabı içerisine kıymamızı alalım. Üzerine rendelenmiş ve suyu sıkılmış soğan, küçük küçük kesilmiş sarımsak, yumurta, galeta unu, sıvı yağ, maydanoz, tuz, karabiber ve kimyonu alalım ve malzemelerimiz güzelce karışana kadar yoğuralım.\r\nHazırladığımız harcımızın üzerini streç ile örtelim ve 30 dakika kadar buzdolabında dinlendirelim.\r\nSürenin sonunda harcımızı dolaptan alalım, elimizle parçalar kopartarak  şekillendirelim. Ben şeklini oval yaptım ancak siz dilediğiniz gibi şekillendirebilirsiniz. Ancak burada köftelerinizin içlerinin de pişmesi için ince olmasına dikkat etmelisiniz.\r\nŞekillendirdiğimiz köftelerimizi uygun bir tabak içerisine alalım. Dilerseniz köftelerinizi bu aşamada da dinlendirebilirsiniz.\r\nKöftelerimizi pişirmek için ocaktaki tavamıza sıvı yağı alalım ve ısıtalım.\r\nArdından köftelerimizi tavamıza alalım ve her iki tarafını da çevirerek pişirelim.", ImagePath = "kofte-755226d7-b991-4fd6-9495-9a127e37409c.jpg", CategoryId = 1 },

                   new FoodEntity { Id = 3, Name = "Mercimek Çorbası", Content = "2 su bardağı kırmızı mercimek\r\n1 adet soğan\r\n2 yemek kaşığı un\r\n1 adet havuç\r\nYarım yemek kaşığı biber ya da  domates salçası (rengi kırmızı olsun isterseniz artırabilir ya da hiç kullanmayabilirsiniz)\r\n1 tatlı kaşığı tuz\r\nYarım çay kaşığı karabiber\r\n1 çay kaşığı kimyon (isteğe bağlı)\r\n2 litre sıcak su\r\n5 yemek kaşığı sıvı yağ", Description = "Kırmızı mercimek çorbası için sıvı yağı tencereye alınarak yemeklik doğranan soğanlar hafif pembeleşinceye kadar kavrulur.\r\nDaha sonra un ilave edilerek kısık ateşte kavurmaya devam edilir.\r\nSalça kullanılacak ise salça ilave edilir, kavrulduktan sonra küp küp doğranmış havuç ve iyice yıkanıp suyu süzülen mercimekler ilave edilir.\r\nÜzerine su eklenerek karıştırılır ve tencerenin kapağı kapatılır. Çorbamız kaynayana kadar orta ateşte, kaynadıktan sonra mercimekler ve havuçlar yumuşayana kadar ara ara karıştırılarak kısık ateşte pişirilir.", ImagePath = "Mercimek-851e29d1-a25a-4e0f-9671-a740a8fd7735-c461e4da-f656-423d-9d1e-9883248244a4-e743721d-b147-4d2b-8c1a-20181fe1caff.jpg", CategoryId = 2 },

                    new FoodEntity { Id = 4, Name = "Supangle", Content = "1 litre süt\r\n2 adet yumurta sarısı\r\n6 yemek kaşığı toz şeker\r\n3 tepeleme yemek kaşığı kakao\r\n2 tepeleme yemek kaşığı un\r\n2 yemek kaşığı nişasta\r\n2 yemek kaşığı tereyağı\r\n2 paket bitter çikolata (120 gr)\r\nYarım su bardağı soğuk su (100 ml)\r\nKakaolu kek", Description = "lk olarak daha sonra kullanmak için suyumuzu buzdolabına kaldıralım ve soğutalım.\r\nDaha sonra uygun bir tencereye nişasta, un, toz şeker, kakao ve yumurta sarılarını alarak karıştıralım.\r\nYavaş yavaş sütü ilave ederek pürüzsüz bir hal alıncaya kadar karıştıralım.\r\nSupanglemizi ocağa alalım ve karıştırarak koyulaşıp göz göz oluncaya kadar pişirelim.\r\nKıvam alan supanglemizi ocaktan alalım, içerisine tereyağı ve çikolatamızı ekleyerek her ikisi de eriyene kadar karıştıralım.\r\nSon olarak buzdolabına kaldırdığımız suyu ilave edelim ve karıştıralım.", ImagePath = "supangle-543b6710-e6f7-43b1-a9e0-785be9f3c1b9-e7fd1188-001b-4587-a5df-ff11ff9e12a4-f6a967e8-e1d3-423b-962f-c1c663ed9f42.jpg", CategoryId = 4 }

                );
        }
    }
}
