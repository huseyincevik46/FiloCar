using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiloCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class İnitialCrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmans",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmans", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelLogId = table.Column<int>(type: "int", nullable: false),
                    StationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drives_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "DepartmanId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanId = table.Column<int>(type: "int", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "DepartmanId");
                });

            migrationBuilder.CreateTable(
                name: "FuelLogs",
                columns: table => new
                {
                    FuelLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    FuelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Liter = table.Column<double>(type: "float", nullable: false),
                    LiterCount = table.Column<double>(type: "float", nullable: false),
                    CurrentKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelLogs", x => x.FuelLogId);
                    table.ForeignKey(
                        name: "FK_FuelLogs_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuelLogs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    KmAtMaintenance = table.Column<int>(type: "int", nullable: false),
                    ServiceCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAssigments",
                columns: table => new
                {
                    VehicleAssigmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    AssignmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignmentEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAssigments", x => x.VehicleAssigmentId);
                    table.ForeignKey(
                        name: "FK_VehicleAssigments_Drives_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drives",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleAssigments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departmans",
                columns: new[] { "DepartmanId", "City", "District", "Name" },
                values: new object[,]
                {
                    { 1111, "Siirt", "Buckinghamshire", "Beauty" },
                    { 2222, "Edirne", "Cambridgeshire", "Toys, Toys & Clothing" },
                    { 3333, "Ankara", "Cambridgeshire", "Industrial" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "FuelLogId", "StationAddress", "StationName", "StationPhone" },
                values: new object[,]
                {
                    { 1, 0, "Lütfi Karadirek Caddesi 40a, Bilecik, Vallis ve Futuna, Fransa", "Eronat, Taşlı and Erçetin", "+90-882-013-65-03" },
                    { 2, 0, "Köypınar Sokak 86, Tunceli, Surinam", "Akışık - Hamzaoğlu", "+90-802-865-55-95" },
                    { 3, 0, "Okul Sokak 35a, Van, Tonga", "Türkdoğan - Dizdar ", "+90-929-568-2-311" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AddTime", "Brand", "DepartmanId", "FuelType", "IsActive", "Km", "Model", "PlateNumber", "Year" },
                values: new object[,]
                {
                    { 2, new DateTime(2018, 6, 23, 10, 47, 19, 71, DateTimeKind.Local).AddTicks(3328), "Jeep", null, "LPG", true, 179840, "Civic", "46ABC463", 2020 },
                    { 3, new DateTime(2020, 9, 20, 19, 12, 10, 579, DateTimeKind.Local).AddTicks(925), "Bugatti", null, "Benzin", true, 123900, "Civic", "46ABD463", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriverId", "DepartmanId", "FirstName", "FullName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 11, 1111, "Bağaşatulu", "Kızılalma Eliçin", "Öymen", "mx5gmnt4lt", "+90-332-460-31-49" },
                    { 22, 2222, "Arslan", "Alkabölük Kumcuoğlu", "Erkekli", "sq3e4zq1l1", "+90-197-052-41-69" }
                });

            migrationBuilder.InsertData(
                table: "FuelLogs",
                columns: new[] { "FuelLogId", "CurrentKm", "FuelDate", "Liter", "LiterCount", "StationId", "VehicleId" },
                values: new object[,]
                {
                    { 24, 16466, new DateTime(2025, 4, 24, 8, 10, 56, 891, DateTimeKind.Local).AddTicks(6888), 54.451350319454228, 37.346315823447043, 2, 2 },
                    { 25, 13059, new DateTime(2025, 4, 22, 17, 13, 22, 508, DateTimeKind.Local).AddTicks(7780), 74.196870141311308, 32.669592387590775, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "Cost", "Description", "KmAtMaintenance", "MaintenanceDate", "ServiceCompanyName", "VehicleId" },
                values: new object[,]
                {
                    { 42, 197.83000000000001, "Numquam qui eius adipisci rem ona molestiae sequi.", 261933, new DateTime(2020, 11, 2, 3, 33, 48, 632, DateTimeKind.Local).AddTicks(4163), null, 2 },
                    { 43, 945.78999999999996, "Sarmal dolore qui.", 84267, new DateTime(2017, 10, 11, 20, 28, 55, 629, DateTimeKind.Local).AddTicks(5209), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AddTime", "Brand", "DepartmanId", "FuelType", "IsActive", "Km", "Model", "PlateNumber", "Year" },
                values: new object[] { 1, new DateTime(2017, 3, 27, 15, 8, 56, 253, DateTimeKind.Local).AddTicks(1379), "Rolls Royce", 2222, "Dizel", false, 130376, "El Camino", "46ABO463", 2015 });

            migrationBuilder.InsertData(
                table: "FuelLogs",
                columns: new[] { "FuelLogId", "CurrentKm", "FuelDate", "Liter", "LiterCount", "StationId", "VehicleId" },
                values: new object[] { 23, 32895, new DateTime(2025, 4, 18, 14, 23, 12, 366, DateTimeKind.Local).AddTicks(6147), 75.098612857556105, 33.827015628182259, 1, 1 });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "Cost", "Description", "KmAtMaintenance", "MaintenanceDate", "ServiceCompanyName", "VehicleId" },
                values: new object[] { 41, 662.83000000000004, "Sit umut architecto masanın gitti.", 205830, new DateTime(2018, 5, 7, 23, 31, 31, 529, DateTimeKind.Local).AddTicks(5751), null, 1 });

            migrationBuilder.InsertData(
                table: "VehicleAssigments",
                columns: new[] { "VehicleAssigmentId", "AssignmentEnd", "AssignmentStart", "DriverId", "Notes", "VehicleId" },
                values: new object[,]
                {
                    { 50, null, new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), 11, "Quae deleniti doloremque filmini non koştum camisi.", 1 },
                    { 51, null, new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), 22, "Et ki incidunt molestiae hesap voluptatem sıfat.", 2 },
                    { 52, new DateTime(2023, 5, 25, 2, 13, 52, 744, DateTimeKind.Local).AddTicks(7281), new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), 22, "Batarya göze tempora et patlıcan.", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DepartmanId",
                table: "Drives",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelLogs_StationId",
                table: "FuelLogs",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelLogs_VehicleId",
                table: "FuelLogs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssigments_DriverId",
                table: "VehicleAssigments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAssigments_VehicleId",
                table: "VehicleAssigments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DepartmanId",
                table: "Vehicles",
                column: "DepartmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelLogs");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "VehicleAssigments");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Departmans");
        }
    }
}
