using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class changeTAbleAndColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Books_BookID",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Studens_StudentID",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Operasyonlar");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Yazarlar");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_BookID",
                table: "Operasyonlar",
                newName: "IX_Operasyonlar_BookID");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Yazarlar",
                newName: "Soyisim");

            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "Yazarlar",
                newName: "Isim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operasyonlar",
                table: "Operasyonlar",
                columns: new[] { "StudentID", "BookID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Yazarlar_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Yazarlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operasyonlar_Books_BookID",
                table: "Operasyonlar",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operasyonlar_Studens_StudentID",
                table: "Operasyonlar",
                column: "StudentID",
                principalTable: "Studens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Yazarlar_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Operasyonlar_Books_BookID",
                table: "Operasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Operasyonlar_Studens_StudentID",
                table: "Operasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operasyonlar",
                table: "Operasyonlar");

            migrationBuilder.RenameTable(
                name: "Yazarlar",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "Operasyonlar",
                newName: "Operations");

            migrationBuilder.RenameColumn(
                name: "Soyisim",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Isim",
                table: "Authors",
                newName: "FristName");

            migrationBuilder.RenameIndex(
                name: "IX_Operasyonlar_BookID",
                table: "Operations",
                newName: "IX_Operations_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                columns: new[] { "StudentID", "BookID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Books_BookID",
                table: "Operations",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Studens_StudentID",
                table: "Operations",
                column: "StudentID",
                principalTable: "Studens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
