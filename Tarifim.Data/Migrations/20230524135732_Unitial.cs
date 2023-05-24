using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarifim.Data.Migrations
{
    public partial class Unitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 24, 16, 57, 32, 368, DateTimeKind.Local).AddTicks(9468), "anayemek-0f491d7b-b43e-4d17-b3fc-14b4c63643ae.jpg", null, "AnaYemekler" },
                    { 2, new DateTime(2023, 5, 24, 16, 57, 32, 368, DateTimeKind.Local).AddTicks(9479), "corbalar-472f802b-1c0c-4080-b326-ede3f85e7d95.jpg", null, "Çorbalar" },
                    { 3, new DateTime(2023, 5, 24, 16, 57, 32, 368, DateTimeKind.Local).AddTicks(9480), "mezeler-4729d6fd-a77c-4325-9195-21e029d2e96f.jpg", null, "Mezeler" },
                    { 4, new DateTime(2023, 5, 24, 16, 57, 32, 368, DateTimeKind.Local).AddTicks(9481), "tatlılar-b64ccedc-54a3-45fe-83ed-c598b4534ba1.jpg", null, "Tatlılar" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "ModifiedDate", "Name", "Password", "SurName", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(1190), "admin@tarifim.com", null, "admin", "CfDJ8DC3D-lnn2lAppW8IuBNfkNM5UAftOKRLBxOr2kSQyMnqWYp1KVJYNdJQvAgyvizDu0z-niGud9ddnbVhvc4OqSm1bzxNotJAij-Cjpz5x8fsKxJS9u61-MUMCLMp47yyw", "admin", 1 },
                    { 2, new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(1196), "user@tarifim.com", null, "user", "CfDJ8DC3D-lnn2lAppW8IuBNfkNdGzYR8rI5nGppky6qOKf1UAxDLZ_sacMhCv2vGN8PgIOhhf8UMkE6vX2uHS_cPH6N3Rlj81oRxTFyR3jJU2Ntqyiu7TqRWPl_NpNmHE2_pg", "user", 2 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "Description", "ImagePath", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Şerbeti için;\r\n\r\n4 su bardağı şeker\r\n4 su bardağı su\r\n1 tatlı kaşığı limon suyu\r\nHamuru için;\r\n\r\n3,5 su bardağı un\r\n2 adet yumurta\r\n1 çay bardağı sıvı yağ\r\n1 çay bardağı süt\r\n1 yemek kaşığı sirke\r\nÇay kaşığı ucu ile Tuz\r\nHamuru açmak için;\r\n\r\nNişasta\r\nArası için;\r\n\r\n2 su bardağı ceviz kırığı\r\nÜzerine;\r\n\r\n250g tereyağı\r\nYarım çay bardağı sıvı yağ", new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(113), "lk olarak tatlımızın şerbetini hazırlayalım. Bunun için uygun bir tencereye şeker ve suyu alalım.\r\nKarıştırdıktan sonra şerbetimizi kaynamaya bırakalım.\r\nSürenin sonunda limon suyunu da ilave ederek bir kaç dakika daha kaynatalım ve ocaktan alalım.\r\nBaklava hamuru için yoğurma kabına yumurta, sıvı yağ, süt, sirke ve tuzu alarak karıştıralım.\r\nDaha sonra unu yavaş yavaş  ilave ederek hamurumuzu ele yapışmayan bir kıvam alıncaya  kadar yoğuralım.\r\nYoğurduğumuz hamurumuzun üzerini streçleyerek 30 dakika kadar dinlenmeye bırakalım. Bu şekilde hamurumuz çok daha kolay açılacaktır.\r\nSüre sonunda hamurumuzu tezgaha alalım ve bir iki kere daha yoğurarak toparlayalım.\r\nHamurumuzu ilk önce eşit bir şekilde 3 parçaya ayıralım, daha sonra her parçayı da 9 parçaya ayıralım.", "cevizlibaklava-390e4656-bdea-4c3e-ba81-124a5953ed9b-c3c573e6-77c0-4880-9c8c-2ef936d5ca35.png", null, "Cevizli Baklava" },
                    { 2, 1, "500 gr orta yağlı kıyma\r\n1 orta boy rendelenmiş soğan\r\n1 diş sarımsak\r\n1 adet yumurta\r\nYarım çay bardağı galeta unu\r\n1 yemek kaşığı sıvı yağ\r\n1 avuç ince kıyılmış maydanoz\r\n1,5 çay kaşığı tuz\r\nYarım çay kaşığı karabiber\r\n1 çay kaşığı kimyon", new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(116), "Uygun bir yoğurma kabı içerisine kıymamızı alalım. Üzerine rendelenmiş ve suyu sıkılmış soğan, küçük küçük kesilmiş sarımsak, yumurta, galeta unu, sıvı yağ, maydanoz, tuz, karabiber ve kimyonu alalım ve malzemelerimiz güzelce karışana kadar yoğuralım.\r\nHazırladığımız harcımızın üzerini streç ile örtelim ve 30 dakika kadar buzdolabında dinlendirelim.\r\nSürenin sonunda harcımızı dolaptan alalım, elimizle parçalar kopartarak  şekillendirelim. Ben şeklini oval yaptım ancak siz dilediğiniz gibi şekillendirebilirsiniz. Ancak burada köftelerinizin içlerinin de pişmesi için ince olmasına dikkat etmelisiniz.\r\nŞekillendirdiğimiz köftelerimizi uygun bir tabak içerisine alalım. Dilerseniz köftelerinizi bu aşamada da dinlendirebilirsiniz.\r\nKöftelerimizi pişirmek için ocaktaki tavamıza sıvı yağı alalım ve ısıtalım.\r\nArdından köftelerimizi tavamıza alalım ve her iki tarafını da çevirerek pişirelim.", "kofte-755226d7-b991-4fd6-9495-9a127e37409c.jpg", null, "Köfte" },
                    { 3, 2, "2 su bardağı kırmızı mercimek\r\n1 adet soğan\r\n2 yemek kaşığı un\r\n1 adet havuç\r\nYarım yemek kaşığı biber ya da  domates salçası (rengi kırmızı olsun isterseniz artırabilir ya da hiç kullanmayabilirsiniz)\r\n1 tatlı kaşığı tuz\r\nYarım çay kaşığı karabiber\r\n1 çay kaşığı kimyon (isteğe bağlı)\r\n2 litre sıcak su\r\n5 yemek kaşığı sıvı yağ", new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(117), "Kırmızı mercimek çorbası için sıvı yağı tencereye alınarak yemeklik doğranan soğanlar hafif pembeleşinceye kadar kavrulur.\r\nDaha sonra un ilave edilerek kısık ateşte kavurmaya devam edilir.\r\nSalça kullanılacak ise salça ilave edilir, kavrulduktan sonra küp küp doğranmış havuç ve iyice yıkanıp suyu süzülen mercimekler ilave edilir.\r\nÜzerine su eklenerek karıştırılır ve tencerenin kapağı kapatılır. Çorbamız kaynayana kadar orta ateşte, kaynadıktan sonra mercimekler ve havuçlar yumuşayana kadar ara ara karıştırılarak kısık ateşte pişirilir.", "Mercimek-851e29d1-a25a-4e0f-9671-a740a8fd7735-c461e4da-f656-423d-9d1e-9883248244a4-e743721d-b147-4d2b-8c1a-20181fe1caff.jpg", null, "Mercimek Çorbası" },
                    { 4, 4, "1 litre süt\r\n2 adet yumurta sarısı\r\n6 yemek kaşığı toz şeker\r\n3 tepeleme yemek kaşığı kakao\r\n2 tepeleme yemek kaşığı un\r\n2 yemek kaşığı nişasta\r\n2 yemek kaşığı tereyağı\r\n2 paket bitter çikolata (120 gr)\r\nYarım su bardağı soğuk su (100 ml)\r\nKakaolu kek", new DateTime(2023, 5, 24, 16, 57, 32, 369, DateTimeKind.Local).AddTicks(118), "lk olarak daha sonra kullanmak için suyumuzu buzdolabına kaldıralım ve soğutalım.\r\nDaha sonra uygun bir tencereye nişasta, un, toz şeker, kakao ve yumurta sarılarını alarak karıştıralım.\r\nYavaş yavaş sütü ilave ederek pürüzsüz bir hal alıncaya kadar karıştıralım.\r\nSupanglemizi ocağa alalım ve karıştırarak koyulaşıp göz göz oluncaya kadar pişirelim.\r\nKıvam alan supanglemizi ocaktan alalım, içerisine tereyağı ve çikolatamızı ekleyerek her ikisi de eriyene kadar karıştıralım.\r\nSon olarak buzdolabına kaldırdığımız suyu ilave edelim ve karıştıralım.", "supangle-543b6710-e6f7-43b1-a9e0-785be9f3c1b9-e7fd1188-001b-4587-a5df-ff11ff9e12a4-f6a967e8-e1d3-423b-962f-c1c663ed9f42.jpg", null, "Supangle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
