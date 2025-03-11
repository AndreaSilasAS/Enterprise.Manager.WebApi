using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enterprise.Manager.DB.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'EnterpriseManager')
                BEGIN
                    CREATE LOGIN EnterpriseManager WITH PASSWORD = 'test';
                    CREATE USER EnterpriseManager FOR LOGIN EnterpriseManager;
                    ALTER ROLE db_owner ADD MEMBER EnterpriseManager;
                END
            ");
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Company')
                BEGIN
                    CREATE TABLE Company (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Name NVARCHAR(50) NOT NULL,
                        Exchange NVARCHAR(15) NOT NULL,
                        Ticker NVARCHAR(50) NOT NULL,
                        Isin NVARCHAR(12) NOT NULL,
                        Website NVARCHAR(100) NULL
                    )
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
