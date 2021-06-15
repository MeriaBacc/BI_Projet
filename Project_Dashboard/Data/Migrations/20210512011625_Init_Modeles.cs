using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Dashboard.Data.Migrations
{
    public partial class Init_Modeles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id_admin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id_admin);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    Id_fournisseur = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_fournisseur = table.Column<string>(maxLength: 50, nullable: true),
                    tele_fournisseur = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.Id_fournisseur);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id_Client = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomc = table.Column<string>(maxLength: 50, nullable: true),
                    tele = table.Column<string>(maxLength: 50, nullable: true),
                    age = table.Column<int>(maxLength: 50, nullable: false),
                    AdminId_admin = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id_Client);
                    table.ForeignKey(
                        name: "FK_clients_Admins_AdminId_admin",
                        column: x => x.AdminId_admin,
                        principalTable: "Admins",
                        principalColumn: "Id_admin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    Id_stock = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_stock = table.Column<string>(maxLength: 50, nullable: true),
                    quantite = table.Column<int>(nullable: false),
                    Prix_st = table.Column<float>(nullable: false),
                    date_stock = table.Column<DateTime>(nullable: false),
                    fourniseurId_fournisseur = table.Column<int>(nullable: true),
                    adminId_admin = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.Id_stock);
                    table.ForeignKey(
                        name: "FK_stocks_Admins_adminId_admin",
                        column: x => x.adminId_admin,
                        principalTable: "Admins",
                        principalColumn: "Id_admin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_fournisseurs_fourniseurId_fournisseur",
                        column: x => x.fourniseurId_fournisseur,
                        principalTable: "fournisseurs",
                        principalColumn: "Id_fournisseur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "factures",
                columns: table => new
                {
                    Id_Facture = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_facture = table.Column<DateTime>(nullable: false),
                    prix_facture = table.Column<float>(nullable: false),
                    Nbre_article = table.Column<int>(nullable: false),
                    clientId_Client = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factures", x => x.Id_Facture);
                    table.ForeignKey(
                        name: "FK_factures_clients_clientId_Client",
                        column: x => x.clientId_Client,
                        principalTable: "clients",
                        principalColumn: "Id_Client",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id_Article = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(maxLength: 50, nullable: true),
                    Prix = table.Column<float>(nullable: false),
                    Pourcentage = table.Column<float>(nullable: false),
                    Categorie = table.Column<string>(maxLength: 50, nullable: true),
                    factureId_Facture = table.Column<int>(nullable: true),
                    stockId_stock = table.Column<int>(nullable: true),
                    AdminId_admin = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id_Article);
                    table.ForeignKey(
                        name: "FK_articles_Admins_AdminId_admin",
                        column: x => x.AdminId_admin,
                        principalTable: "Admins",
                        principalColumn: "Id_admin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articles_factures_factureId_Facture",
                        column: x => x.factureId_Facture,
                        principalTable: "factures",
                        principalColumn: "Id_Facture",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articles_stocks_stockId_stock",
                        column: x => x.stockId_stock,
                        principalTable: "stocks",
                        principalColumn: "Id_stock",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_AdminId_admin",
                table: "articles",
                column: "AdminId_admin");

            migrationBuilder.CreateIndex(
                name: "IX_articles_factureId_Facture",
                table: "articles",
                column: "factureId_Facture");

            migrationBuilder.CreateIndex(
                name: "IX_articles_stockId_stock",
                table: "articles",
                column: "stockId_stock");

            migrationBuilder.CreateIndex(
                name: "IX_clients_AdminId_admin",
                table: "clients",
                column: "AdminId_admin");

            migrationBuilder.CreateIndex(
                name: "IX_factures_clientId_Client",
                table: "factures",
                column: "clientId_Client");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_adminId_admin",
                table: "stocks",
                column: "adminId_admin");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_fourniseurId_fournisseur",
                table: "stocks",
                column: "fourniseurId_fournisseur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "factures");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
