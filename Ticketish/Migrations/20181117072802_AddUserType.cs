using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketish.Migrations
{
  public partial class AddUserType : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_users",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AddColumn<int>(
          name: "Type",
          table: "tck_users",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_tickets",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_roles",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_products",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_comments",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_attachments",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Type",
          table: "tck_users");

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_users",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_tickets",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_roles",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_products",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_comments",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

      migrationBuilder.AlterColumn<DateTime>(
          name: "CreatedAt",
          table: "tck_attachments",
          nullable: false,
          oldClrType: typeof(DateTime))
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
    }
  }
}
