using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharacterAPI.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "", "Luke Skywalker", "Male", "https://www.bing.com/images/search?view=detailV2&ccid=uPTRLR8u&id=FFD59ED05A26A33C503B66BE02C8CFFA05FA8DB3&thid=OIP.uPTRLR8uspCiafiunUqKfQHaMJ&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.b8f4d12d1f2eb290a269f8ae9d4a8a7d%3frik%3ds436BfrPyAK%252bZg%26riu%3dhttp%253a%252f%252fimg1.wikia.nocookie.net%252f__cb20141111160806%252fp__%252fprotagonist%252fimages%252f8%252f84%252fLukeskywalker.jpg%26ehk%3dm5uTAD2IYKS%252fQaidrAfhnz8Zayfpsi%252bFWOaIuXDQBsg%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=2700&expw=1647&q=luke+skywalker&simid=608011882935841673&FORM=IRPRST&ck=64790184029AA8C48281267F9124289B&selectedIndex=0&ajaxhist=0&ajaxserp=0" },
                    { 2, "General Leia", "Princess Leia Organa", "Female", "https://www.bing.com/images/search?view=detailV2&ccid=3pZydBuF&id=F92F82519D255666098AFEB948CC531B01DDD189&thid=OIP.3pZydBuFTbqFwZCnGlbnTwHaEK&mediaurl=https%3a%2f%2fi.ytimg.com%2fvi%2f6N135weupJo%2fmaxresdefault.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.de9672741b854dba85c190a71a56e74f%3frik%3didHdARtTzEi5%252fg%26pid%3dImgRaw%26r%3d0&exph=720&expw=1280&q=general+leia&simid=607998014483292589&FORM=IRPRST&ck=91AFF450F6F4AA6BA505F9AC65D9C24E&selectedIndex=30&ajaxhist=0&ajaxserp=0" },
                    { 3, "", "Yoda", "Unknown", "https://www.bing.com/images/search?view=detailV2&ccid=wNR90pfC&id=FA055E1F8BE265BD8E7AD413E374DCE50205C1D6&thid=OIP.wNR90pfCa2lugA-HiFnToAHaEK&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.c0d47dd297c26b696e800f878859d3a0%3frik%3d1sEFAuXcdOMT1A%26riu%3dhttp%253a%252f%252fcdn.collider.com%252fwp-content%252fuploads%252f2015%252f05%252fstar-wars-the-empire-strikes-back-yoda.jpg%26ehk%3dmeggywpDhNeL1onhqoBnQKzu73X2mugstfuzZfkXQBQ%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1080&expw=1920&q=yoda+the+empire+strikes+back&simid=608056133986490704&FORM=IRPRST&ck=51FD6FA0A02600635EECE4914E81525F&selectedIndex=0&ajaxhist=0&ajaxserp=0" },
                    { 4, "Han", "Han Solo", "Male", "https://www.bing.com/images/search?view=detailV2&ccid=wnvYY2V3&id=62AC2B1843847D7122705C340024146FAD446FE4&thid=OIP.wnvYY2V36FlHDfok2_rcZwHaD1&mediaurl=https%3a%2f%2fcdn.epicstream.com%2fassets%2fuploads%2fnewscover%2f1573594175Han_Solo_empire_strikes_back.png&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.c27bd8636577e859470dfa24dbfadc67%3frik%3d5G9ErW8UJAA0XA%26pid%3dImgRaw%26r%3d0&exph=502&expw=971&q=han+solo+strikes+back&simid=608002880686262851&FORM=IRPRST&ck=65F62C5792C8FCA5E3951352097DCB64&selectedIndex=12&ajaxhist=0&ajaxserp=0" },
                    { 5, "Katniss", "Katniss Everdeen", "Female", "https://www.bing.com/images/search?view=detailV2&ccid=AYQdBYww&id=DD3B6D49880F4AC0565D73B35C3755F9708CD1E2&thid=OIP.AYQdBYwwIZf7j6_NqXuS9QHaE7&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.01841d058c302197fb8fafcda97b92f5%3frik%3d4tGMcPlVN1yzcw%26riu%3dhttp%253a%252f%252fwww4.pictures.livingly.com%252fmp%252fHKAjAPp8IYAx.jpg%26ehk%3d1nKe3ZtaqHCUiQYxpTpMtOc11pltUllxyJXscvy0ytU%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1351&expw=2027&q=katnniss+everdeen&simid=608020490056503169&FORM=IRPRST&ck=A8F6D1BADEB84306B0A13AB853A7D5E2&selectedIndex=0&ajaxhist=0&ajaxserp=0" },
                    { 7, "Prim", "Primrose Everdeen", "Female", "https://www.bing.com/images/search?view=detailV2&ccid=D71QVT%2fj&id=CA471868F7F683E0267F262EB1531F323F050448&thid=OIP.D71QVT_jU4qqgosrAPiL8QHaEK&mediaurl=https%3a%2f%2fdownloadhdwallpapers.in%2fwp-content%2fuploads%2f2018%2f02%2fPrimrose-Everdeen-Hunger-Games-Mockingjay-Part-2-HD-Wallpapers-For-Android.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.0fbd50553fe3538aaa828b2b00f88bf1%3frik%3dSAQFPzIfU7EuJg%26pid%3dImgRaw%26r%3d0&exph=2160&expw=3840&q=Primrose+Everdeen&simid=608010345340751945&form=IRPRST&ck=0163C57B4DB5D0ED605748D48651C69D&selectedindex=0&ajaxhist=0&ajaxserp=0&first=1&tsc=ImageBasicHover" },
                    { 8, "Frodo", "Frodo Baggins", "Male", "https://www.bing.com/images/search?view=detailV2&ccid=QBsuSnqf&id=132CD9F469ED23EB0789D72F03E3F0A25FCCB011&thid=OIP.QBsuSnqfZCGKtNfWUusD3gHaFj&mediaurl=https%3a%2f%2fwww.tribute.ca%2fnews%2fwp-content%2fuploads%2f2014%2f12%2ffrodo.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.401b2e4a7a9f64218ab4d7d652eb03de%3frik%3dEbDMX6Lw4wMv1w%26pid%3dImgRaw%26r%3d0&exph=1201&expw=1600&q=frodo+baggins&simid=608046959938700783&FORM=IRPRST&ck=D277F31CA6D97FB91FF92DD0934AE0C5&selectedIndex=0&ajaxhist=0&ajaxserp=0" },
                    { 9, "Elfstone,Strider", "Aragorn II", "Male", "https://www.bing.com/images/search?view=detailV2&ccid=fcb8LaIe&id=AB42427ACA90194ED741B42D4BD3A06B117E4A98&thid=OIP.fcb8LaIekfmoLfOjft-PewHaEK&mediaurl=https%3a%2f%2fi.ytimg.com%2fvi%2fZUUPM7LXcsw%2fmaxresdefault.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.7dc6fc2da21e91f9a82df3a37edf8f7b%3frik%3dmEp%252bEWug00sttA%26pid%3dImgRaw%26r%3d0&exph=720&expw=1280&q=aragorn&simid=608017427744118409&FORM=IRPRST&ck=14CAFD17F1DCD856AA6EAC3217E1A2B7&selectedIndex=1&ajaxhist=0&ajaxserp=0" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Star Wars is an American epic space opera multimedia franchise created by George Lucas,which began with the eponymous 1977 film and quickly became a worldwide pop - culture phenomenon.The franchise has been expanded into various films and other media.", "Star War" },
                    { 2, "The Hunger Games is a series of young adult dystopian novels written by American author Suzanne Collins.The series is set in the Hunger Games universe, with the first three novels being a trilogy following teenage protagonist Katniss Everdeen", "The Hunger Games" },
                    { 3, "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson,based on the novel written by J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001),The Two Towers (2002), and The Return of the King (2003)", "The Lord of the Rings" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "George Lucas", 1, "Action, Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=SZXySpB0&id=AAC1DAF732490B0599014B4F93F24739044A9371&thid=OIP.SZXySpB0dDv02xQz69ZRqAAAAA&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.4995f24a9074743bf4db1433ebd651a8%3frik%3dcZNKBDlH8pNPSw%26riu%3dhttp%253a%252f%252fis2.mzstatic.com%252fimage%252fthumb%252fVideo6%252fv4%252f61%252f16%252fce%252f6116cec2-d2e8-de26-f80d-38a1685d04b8%252fsource%252f1200x630bb.jpg%26ehk%3dlW2QyaemzCrZCwIvEmPoMKXAwSTQGVUC5HCYTua9zLY%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=630&expw=420&q=star+wars+a+new+hope&simid=608037828834114165&FORM=IRPRST&ck=F9F24A1686A11C492D1EE6755EF6DA62&selectedIndex=0&ajaxhist=0&ajaxserp=0", "1977", "Episode IV - A New Hope", "https://www.youtube.com/watch?v=vZ734NWnAHA" },
                    { 2, "Irvin Kershner", 1, "Action, Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=lNoH%2FeQ7&id=6CD657AA2C2243F1F1AD198CDD6FB57942E37589&thid=OIP.lNoH_eQ7jIDsa3rCRUt-hAHaLH&mediaurl=https%3A%2F%2Fi.redd.it%2Fhytct3hlxjw31.jpg&cdnurl=https%3A%2F%2Fth.bing.com%2Fth%2Fid%2FR.94da07fde43b8c80ec6b7ac2454b7e84%3Frik%3DiXXjQnm1b92MGQ%26pid%3DImgRaw%26r%3D0&exph=1920&expw=1280&q=the+empire+strikes+back&simid=608021984704354256&form=IRPRST&ck=680C3A71C628A0CA45DB4A3EC8BB973B&selectedindex=0&ajaxhist=0&ajaxserp=0&vt=0&sim=11", "1980", "Episode V - The Empire Strikes Back", "https://www.youtube.com/watch?v=JNwNXF9Y6kY" },
                    { 3, "Richard Marquand", 1, "Action, Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=CuBq01if&id=ED612BAE125A84DEADBB400EA6A5DCB14063C43C&thid=OIP.CuBq01if7277fesm_39TNgHaLH&mediaurl=https%3a%2f%2fimage.tmdb.org%2ft%2fp%2foriginal%2fd3tUb6of6TaKDUA34Lsbtu0WJzH.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.0ae06ad3589fef6efb7deb26ff7f5336%3frik%3dPMRjQLHcpaYOQA%26pid%3dImgRaw%26r%3d0&exph=3000&expw=2000&q=return+of+the+jedi&simid=608053698740034753&FORM=IRPRST&ck=E5D93F4A78EE6CEEA78E701823A00A61&selectedIndex=0&ajaxhist=0&ajaxserp=0", "1983", "Episode VI - Return of the Jedi", "https://www.youtube.com/watch?v=p4vIFhk621Q" },
                    { 4, "Gary Ross", 2, "Action, Adventure Film, Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=P7CZlhtH&id=4012CD614D6998FA65C1BE8FDBC4582387DAC29E&thid=OIP.P7CZlhtHRd2R5zkaOM4DVwHaLJ&mediaurl=https%3a%2f%2fwww.avoir-alire.com%2fIMG%2fjpg%2fhunger_games-5.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.3fb099961b4745dd91e7391a38ce0357%3frik%3dnsLahyNYxNuPvg%26pid%3dImgRaw%26r%3d0&exph=1600&expw=1063&q=hunger+games&simid=608011943062498088&FORM=IRPRST&ck=4A7A71442FCFE211FA8011F7F5F5681C&selectedIndex=0&ajaxhist=0&ajaxserp=0", "2012", "The Hunger Games", "https://www.youtube.com/watch?v=mfmrPu43DF8" },
                    { 5, "Francis Lawrence", 2, "Action, Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=ZSJGEiAM&id=F0FF2DC5757AB0AAE8785B6D7FB901010985091D&thid=OIP.ZSJGEiAM4ilVrcAl4wiEAQHaK-&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.65224612200ce22955adc025e3088401%3frik%3dHQmFCQEBuX9tWw%26riu%3dhttp%253a%252f%252fcdn.collider.com%252fwp-content%252fuploads%252fthe-hunger-games-catching-fire-poster-final.jpg%26ehk%3dXl1oNH2iOPG%252bYqGuNaDAT18%252bGXhsjh%252fS5r%252f7GG%252bd%252brw%253d%26risl%3d1%26pid%3dImgRaw%26r%3d0&exph=6000&expw=4050&q=catching+fire&simid=608013124178240446&FORM=IRPRST&ck=748B6542501D029AFE5C1E55D705481D&selectedIndex=0&ajaxhist=0&ajaxserp=0", "2013", "Catching Fire", "https://www.youtube.com/watch?v=EAzGXqJSDJ8" },
                    { 6, "Francis Lawrence", 3, "Action, Adventure,Fantasy,Science Fiction", "https://www.bing.com/images/search?view=detailV2&ccid=GPanlix9&id=90F59E509950D4EA35B139C087423E4485CEE9EA&thid=OIP.GPanlix9KD1gXhO37kB40gHaKg&mediaurl=https%3a%2f%2fcdn.hmv.com%2fr%2fw-1280%2fhmv%2ffiles%2fef%2fefed5bfb-dc0b-4177-a167-7c74f673ddf1.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.18f6a7962c7d283d605e13b7ee4078d2%3frik%3d6unOhUQ%252bQofAOQ%26pid%3dImgRaw%26r%3d0&exph=1815&expw=1280&q=the+fellowship+of+the+ring&simid=608022431375908869&FORM=IRPRST&ck=EF1222A8BE11C69DB407252D3FA02647&selectedIndex=0&ajaxhist=0&ajaxserp=0", "2019", "The fellowship of the Ring", "https://www.youtube.com/watch?v=V75dMMIW2B4" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_MovieId",
                table: "MovieCharacter",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
