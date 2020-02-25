using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntenTeller.Data.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    teacherid = table.Column<int>(nullable: true),
                    cohortid = table.Column<int>(nullable: true),
                    period = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.id);
                    table.ForeignKey(
                        name: "FK_Course_Cohort_cohortid",
                        column: x => x.cohortid,
                        principalTable: "Cohort",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_teacherid",
                        column: x => x.teacherid,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_cohortid",
                table: "Course",
                column: "cohortid");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacherid",
                table: "Course",
                column: "teacherid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
