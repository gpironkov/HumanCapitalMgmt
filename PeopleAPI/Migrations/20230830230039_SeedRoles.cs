using Microsoft.EntityFrameworkCore.Migrations;
using PeopleAPI.Common;

#nullable disable

namespace PeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{Guid.NewGuid()}', '{GlobalConstants.HumanResourcesRoleName}', '{GlobalConstants.HumanResourcesRoleName.ToUpper()}')");
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{Guid.NewGuid()}', '{GlobalConstants.ManagerRoleName}', '{GlobalConstants.ManagerRoleName.ToUpper()}')");
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{Guid.NewGuid()}', '{GlobalConstants.EmployeeRoleName}', '{GlobalConstants.EmployeeRoleName.ToUpper()}')");
        }
    }
}
