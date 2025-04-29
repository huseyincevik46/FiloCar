using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiloCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class İnitalCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 1111,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Adana", "Berkshire", "Toys" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 2222,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Samsun", "Avon", "Sports & Baby" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 3333,
                columns: new[] { "City", "Name" },
                values: new object[] { "Sakarya", "Books & Home" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 11,
                columns: new[] { "FirstName", "FullName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Aygırak", "Bayrak Küçükler", "Bademci", "4hnb6gjrw4", "+90-398-842-5-779" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 22,
                columns: new[] { "FirstName", "FullName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Arslanyabgu", "Aşantuğrul Baturalp", "Okumuş", "qfls0dgb9b", "+90-761-166-0-236" });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 23,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 32805, new DateTime(2025, 4, 24, 2, 12, 26, 830, DateTimeKind.Local).AddTicks(6195), 69.071781622572644, 38.084491492288159 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 24,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 23859, new DateTime(2025, 4, 21, 19, 31, 24, 413, DateTimeKind.Local).AddTicks(2751), 78.609987615365384, 38.519382708337758 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 25,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 35953, new DateTime(2025, 4, 23, 22, 22, 51, 916, DateTimeKind.Local).AddTicks(8970), 48.227943607585502, 36.773876455589757 });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 615.63, "Esse sunt ekşili okuma exercitationem filmini un.", 275037, new DateTime(2017, 8, 2, 16, 8, 48, 940, DateTimeKind.Local).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 490.66000000000003, "Veritatis ötekinden dignissimos göze.", 150425, new DateTime(2018, 9, 19, 4, 48, 8, 611, DateTimeKind.Local).AddTicks(6551) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 938.94000000000005, "Qui praesentium uzattı aperiam dignissimos sıradanlıktan kutusu dolayı sayfası karşıdakine.", 161101, new DateTime(2020, 9, 25, 9, 40, 3, 664, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Nalbant Sokak 444, Osmaniye, İzlanda", "Akgül, Atan and Akyüz", "+90-581-956-06-62" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Oğuzhan Sokak 8, İstanbul, Avustralya", "Kuday - Berberoğlu", "+90-820-307-8-076" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Oğuzhan Sokak 67b, Gümüşhane, Brunei", "Yorulmaz Inc", "+90-165-362-91-00" });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 50,
                columns: new[] { "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2023, 5, 16, 4, 38, 46, 828, DateTimeKind.Local).AddTicks(8976), "Magnam ratione değerli sıradanlıktan ve quam duyulmamış." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 51,
                columns: new[] { "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2023, 5, 16, 4, 38, 46, 828, DateTimeKind.Local).AddTicks(8976), "Eaque orta et olduğu sıla." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 52,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { null, new DateTime(2023, 5, 16, 4, 38, 46, 828, DateTimeKind.Local).AddTicks(8976), "Kutusu çarpan magni gidecekmiş ipsa." });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "AddTime", "Brand", "IsActive", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2017, 8, 2, 7, 0, 23, 843, DateTimeKind.Local).AddTicks(8222), "Jeep", true, 185785, "Spyder", 2020 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "AddTime", "Brand", "Km", "Model" },
                values: new object[] { new DateTime(2025, 3, 31, 20, 15, 14, 788, DateTimeKind.Local).AddTicks(6948), "Audi", 49973, "Alpine" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "AddTime", "Brand", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2019, 5, 26, 18, 21, 26, 293, DateTimeKind.Local).AddTicks(9729), "Hyundai", 165772, "Malibu", 2021 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 1111,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Siirt", "Buckinghamshire", "Beauty" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 2222,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Edirne", "Cambridgeshire", "Toys, Toys & Clothing" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 3333,
                columns: new[] { "City", "Name" },
                values: new object[] { "Ankara", "Industrial" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 11,
                columns: new[] { "FirstName", "FullName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Bağaşatulu", "Kızılalma Eliçin", "Öymen", "mx5gmnt4lt", "+90-332-460-31-49" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 22,
                columns: new[] { "FirstName", "FullName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Arslan", "Alkabölük Kumcuoğlu", "Erkekli", "sq3e4zq1l1", "+90-197-052-41-69" });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 23,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 32895, new DateTime(2025, 4, 18, 14, 23, 12, 366, DateTimeKind.Local).AddTicks(6147), 75.098612857556105, 33.827015628182259 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 24,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 16466, new DateTime(2025, 4, 24, 8, 10, 56, 891, DateTimeKind.Local).AddTicks(6888), 54.451350319454228, 37.346315823447043 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 25,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 13059, new DateTime(2025, 4, 22, 17, 13, 22, 508, DateTimeKind.Local).AddTicks(7780), 74.196870141311308, 32.669592387590775 });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 662.83000000000004, "Sit umut architecto masanın gitti.", 205830, new DateTime(2018, 5, 7, 23, 31, 31, 529, DateTimeKind.Local).AddTicks(5751) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 197.83000000000001, "Numquam qui eius adipisci rem ona molestiae sequi.", 261933, new DateTime(2020, 11, 2, 3, 33, 48, 632, DateTimeKind.Local).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 945.78999999999996, "Sarmal dolore qui.", 84267, new DateTime(2017, 10, 11, 20, 28, 55, 629, DateTimeKind.Local).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Lütfi Karadirek Caddesi 40a, Bilecik, Vallis ve Futuna, Fransa", "Eronat, Taşlı and Erçetin", "+90-882-013-65-03" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Köypınar Sokak 86, Tunceli, Surinam", "Akışık - Hamzaoğlu", "+90-802-865-55-95" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Okul Sokak 35a, Van, Tonga", "Türkdoğan - Dizdar ", "+90-929-568-2-311" });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 50,
                columns: new[] { "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), "Quae deleniti doloremque filmini non koştum camisi." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 51,
                columns: new[] { "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), "Et ki incidunt molestiae hesap voluptatem sıfat." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 52,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2023, 5, 25, 2, 13, 52, 744, DateTimeKind.Local).AddTicks(7281), new DateTime(2023, 4, 29, 12, 4, 45, 752, DateTimeKind.Local).AddTicks(1190), "Batarya göze tempora et patlıcan." });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "AddTime", "Brand", "IsActive", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2017, 3, 27, 15, 8, 56, 253, DateTimeKind.Local).AddTicks(1379), "Rolls Royce", false, 130376, "El Camino", 2015 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "AddTime", "Brand", "Km", "Model" },
                values: new object[] { new DateTime(2018, 6, 23, 10, 47, 19, 71, DateTimeKind.Local).AddTicks(3328), "Jeep", 179840, "Civic" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "AddTime", "Brand", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2020, 9, 20, 19, 12, 10, 579, DateTimeKind.Local).AddTicks(925), "Bugatti", 123900, "Civic", 2018 });
        }
    }
}
