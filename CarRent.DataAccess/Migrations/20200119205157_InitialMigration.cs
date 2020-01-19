using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Potential = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IsCompany = table.Column<bool>(nullable: true),
                    DriversLicenseNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Coordinator_IsDeleted = table.Column<bool>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    Worker_IsDeleted = table.Column<bool>(nullable: true),
                    CoordinatorId = table.Column<int>(nullable: true),
                    Worker_RegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_People_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Region_Worker_RegionId",
                        column: x => x.Worker_RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlateNumber = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Transmission = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    PricePerDay = table.Column<decimal>(nullable: false),
                    IsDamaged = table.Column<bool>(nullable: false),
                    IsAway = table.Column<bool>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_People_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    RentalTime = table.Column<int>(nullable: false),
                    DeliveryPlace = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    CoordinatorId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_ClientId",
                        column: x => x.ClientId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairReports_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrivenDistance = table.Column<int>(nullable: false),
                    IsDamaged = table.Column<bool>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnReports_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RegionId",
                table: "Cars",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_WorkerId",
                table: "Cars",
                column: "WorkerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CoordinatorId",
                table: "Orders",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegionId",
                table: "Orders",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WorkerId",
                table: "Orders",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_People_RegionId",
                table: "People",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CoordinatorId",
                table: "People",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_Worker_RegionId",
                table: "People",
                column: "Worker_RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairReports_OrderId",
                table: "RepairReports",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturnReports_OrderId",
                table: "ReturnReports",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairReports");

            migrationBuilder.DropTable(
                name: "ReturnReports");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
