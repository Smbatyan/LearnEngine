using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnEngine.Infrastucture.Migrations
{
    public partial class manytomanytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Nodes_Nodes_ParentId",
            //    table: "Nodes");

            //migrationBuilder.DropIndex(
            //    name: "IX_Nodes_ParentId",
            //    table: "Nodes");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Nodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NodeNode",
                columns: table => new
                {
                    ParentNodesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubNodesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodeNode", x => new { x.ParentNodesId, x.SubNodesId });
                    table.ForeignKey(
                        name: "FK_NodeNode_Nodes_ParentNodesId",
                        column: x => x.ParentNodesId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NodeNode_Nodes_SubNodesId",
                        column: x => x.SubNodesId,
                        principalTable: "Nodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NodeNode_SubNodesId",
                table: "NodeNode",
                column: "SubNodesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NodeNode");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Nodes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "Id");
        }
    }
}
