using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiloCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class İnitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Drives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 1111,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Nevşehir", "Borders", "Tools" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 2222,
                columns: new[] { "District", "Name" },
                values: new object[] { "Buckinghamshire", "Industrial & Grocery" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 3333,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Çorum", "Avon", "Games, Games & Tools" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 11,
                columns: new[] { "FirstName", "FullName", "IsActive", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Avluç", "Baymünke Körmükçü", true, "Akman", "tsg7tuqc80", "+90-923-791-21-48" });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriverId",
                keyValue: 22,
                columns: new[] { "FirstName", "FullName", "IsActive", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[] { "Baybora", "Gülegen Karaböcek", false, "Elçiboğa", "b34w21ppga", "+90-271-167-84-03" });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 23,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 14959, new DateTime(2025, 4, 20, 10, 7, 0, 20, DateTimeKind.Local).AddTicks(9667), 57.879830193653021, 34.011291054630377 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 24,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 71648, new DateTime(2025, 4, 22, 14, 47, 21, 321, DateTimeKind.Local).AddTicks(4719), 38.418985906067945, 38.308913434841585 });

            migrationBuilder.UpdateData(
                table: "FuelLogs",
                keyColumn: "FuelLogId",
                keyValue: 25,
                columns: new[] { "CurrentKm", "FuelDate", "Liter", "LiterCount" },
                values: new object[] { 84497, new DateTime(2025, 4, 23, 20, 20, 21, 801, DateTimeKind.Local).AddTicks(6175), 39.266278188668196, 30.730190321038503 });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 305.38999999999999, "Quia molestiae ut quia.", 174055, new DateTime(2016, 2, 27, 6, 28, 27, 371, DateTimeKind.Local).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 501.47000000000003, "Ad orta kulu olduğu.", 176032, new DateTime(2022, 8, 28, 11, 5, 8, 796, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Cost", "Description", "KmAtMaintenance", "MaintenanceDate" },
                values: new object[] { 712.54999999999995, "Salladı hesap et et voluptatem blanditiis nihil qui ratione ki.", 253293, new DateTime(2021, 5, 23, 4, 58, 12, 478, DateTimeKind.Local).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 1,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Sevgi Sokak 48b, Mardin, Hırvatistan", "Süleymanoğlu, Avan and Koçoğlu", "+90-189-852-43-54" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 2,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Mevlana Sokak 535, Karaman, Yeni Kaledonya, Fransa", "Bademci Inc", "+90-970-479-6-482" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "StationId",
                keyValue: 3,
                columns: new[] { "StationAddress", "StationName", "StationPhone" },
                values: new object[] { "Lütfi Karadirek Caddesi 5, Ankara, Küba", "Akal Inc", "+90-934-261-46-84" });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 50,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2025, 2, 19, 22, 25, 9, 676, DateTimeKind.Local).AddTicks(1776), new DateTime(2023, 11, 15, 10, 48, 4, 859, DateTimeKind.Local).AddTicks(3014), "Ex sunt koşuyorlar sıfat quis." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 51,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2024, 3, 26, 6, 36, 23, 800, DateTimeKind.Local).AddTicks(3268), new DateTime(2023, 11, 15, 10, 48, 4, 859, DateTimeKind.Local).AddTicks(3014), "Sarmal sinema blanditiis sit et." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 52,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { new DateTime(2025, 3, 23, 17, 16, 20, 226, DateTimeKind.Local).AddTicks(8433), new DateTime(2023, 11, 15, 10, 48, 4, 859, DateTimeKind.Local).AddTicks(3014), "Karşıdakine patlıcan dignissimos." });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "AddTime", "Brand", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2015, 10, 1, 11, 40, 39, 46, DateTimeKind.Local).AddTicks(5223), "BMW", 68531, "Focus", 2023 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "AddTime", "Brand", "IsActive", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2019, 12, 27, 1, 24, 24, 442, DateTimeKind.Local).AddTicks(9554), "BMW", false, 72813, "Malibu", 2016 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "AddTime", "Brand", "FuelType", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2018, 12, 24, 16, 14, 14, 298, DateTimeKind.Local).AddTicks(773), "Bentley", "LPG", 80069, "Fortwo", 2016 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Drives");

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
                columns: new[] { "District", "Name" },
                values: new object[] { "Avon", "Sports & Baby" });

            migrationBuilder.UpdateData(
                table: "Departmans",
                keyColumn: "DepartmanId",
                keyValue: 3333,
                columns: new[] { "City", "District", "Name" },
                values: new object[] { "Sakarya", "Cambridgeshire", "Books & Home" });

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
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { null, new DateTime(2023, 5, 16, 4, 38, 46, 828, DateTimeKind.Local).AddTicks(8976), "Magnam ratione değerli sıradanlıktan ve quam duyulmamış." });

            migrationBuilder.UpdateData(
                table: "VehicleAssigments",
                keyColumn: "VehicleAssigmentId",
                keyValue: 51,
                columns: new[] { "AssignmentEnd", "AssignmentStart", "Notes" },
                values: new object[] { null, new DateTime(2023, 5, 16, 4, 38, 46, 828, DateTimeKind.Local).AddTicks(8976), "Eaque orta et olduğu sıla." });

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
                columns: new[] { "AddTime", "Brand", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2017, 8, 2, 7, 0, 23, 843, DateTimeKind.Local).AddTicks(8222), "Jeep", 185785, "Spyder", 2020 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "AddTime", "Brand", "IsActive", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2025, 3, 31, 20, 15, 14, 788, DateTimeKind.Local).AddTicks(6948), "Audi", true, 49973, "Alpine", 2020 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "AddTime", "Brand", "FuelType", "Km", "Model", "Year" },
                values: new object[] { new DateTime(2019, 5, 26, 18, 21, 26, 293, DateTimeKind.Local).AddTicks(9729), "Hyundai", "Benzin", 165772, "Malibu", 2021 });
        }
    }
}
