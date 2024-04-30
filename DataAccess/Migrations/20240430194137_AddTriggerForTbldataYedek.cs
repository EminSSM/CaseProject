using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerForTbldataYedek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER trgAfterInsert
                ON Tbldata
                AFTER INSERT
                AS
                BEGIN
                    INSERT INTO TbldataYedek (Name, Surname, City, CreatedDate, BirthYear)
                    SELECT Name, Surname, City, CreatedDate, BirthYear
                    FROM inserted;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trgAfterInsert ON Tbldata");
        }
    }
}
