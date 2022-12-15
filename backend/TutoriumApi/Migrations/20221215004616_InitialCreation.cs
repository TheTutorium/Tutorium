using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TutoriumApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "text", nullable: true),
                    EmailVerifiedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PhoneVerificationCode = table.Column<string>(type: "text", nullable: true),
                    PhoneVerifiedStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<int>(type: "integer", nullable: false),
                    DocumentPath = table.Column<string>(type: "text", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VerifiedStatus = table.Column<int>(type: "integer", nullable: false),
                    AffilatedTutorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_AffilatedTutorId",
                        column: x => x.AffilatedTutorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CanceledBy = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AffilatedCourseId = table.Column<int>(type: "integer", nullable: false),
                    AffilatedStudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Courses_AffilatedCourseId",
                        column: x => x.AffilatedCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_AffilatedStudentId",
                        column: x => x.AffilatedStudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    AffilatedCourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Courses_AffilatedCourseId",
                        column: x => x.AffilatedCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    AffilatedCourseId = table.Column<int>(type: "integer", nullable: false),
                    AffilatedStudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_AffilatedCourseId",
                        column: x => x.AffilatedCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AffilatedStudentId",
                        column: x => x.AffilatedStudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhiteboardSaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SavePath = table.Column<string>(type: "text", nullable: false),
                    SaveTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AffilatedBookingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiteboardSaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhiteboardSaves_Bookings_AffilatedBookingId",
                        column: x => x.AffilatedBookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "EmailVerificationCode", "EmailVerifiedStatus", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "PhoneVerificationCode", "PhoneVerifiedStatus" },
                values: new object[,]
                {
                    { 1, "Student", "baris@student", null, true, "Baris Ogun", "Yoruk", new byte[] { 46, 120, 221, 209, 203, 75, 128, 21, 122, 10, 215, 126, 23, 197, 112, 37, 105, 148, 9, 1, 30, 116, 108, 233, 82, 65, 0, 44, 200, 145, 155, 191, 68, 57, 68, 228, 1, 107, 83, 86, 161, 162, 82, 55, 202, 82, 170, 221, 0, 61, 203, 11, 199, 0, 16, 13, 64, 85, 21, 236, 9, 51, 247, 212 }, new byte[] { 146, 42, 48, 131, 60, 140, 121, 209, 223, 195, 154, 182, 34, 220, 130, 162, 122, 107, 121, 23, 63, 8, 11, 24, 190, 252, 30, 170, 19, 180, 190, 22, 131, 216, 201, 74, 18, 183, 163, 172, 39, 248, 23, 237, 250, 59, 7, 124, 164, 146, 255, 99, 16, 161, 171, 36, 189, 99, 233, 91, 144, 179, 217, 53, 157, 199, 8, 165, 13, 2, 124, 143, 134, 91, 26, 227, 198, 68, 19, 155, 53, 29, 213, 244, 95, 149, 135, 44, 250, 183, 106, 156, 107, 74, 97, 114, 128, 215, 106, 149, 138, 111, 32, 209, 161, 214, 30, 216, 72, 108, 138, 56, 79, 236, 104, 186, 63, 209, 183, 172, 201, 103, 112, 200, 100, 162, 248, 156 }, "00905075711001", null, true },
                    { 2, "Student", "cagri@student", null, true, "Mustafa Cagri", "Durgut", new byte[] { 46, 120, 221, 209, 203, 75, 128, 21, 122, 10, 215, 126, 23, 197, 112, 37, 105, 148, 9, 1, 30, 116, 108, 233, 82, 65, 0, 44, 200, 145, 155, 191, 68, 57, 68, 228, 1, 107, 83, 86, 161, 162, 82, 55, 202, 82, 170, 221, 0, 61, 203, 11, 199, 0, 16, 13, 64, 85, 21, 236, 9, 51, 247, 212 }, new byte[] { 146, 42, 48, 131, 60, 140, 121, 209, 223, 195, 154, 182, 34, 220, 130, 162, 122, 107, 121, 23, 63, 8, 11, 24, 190, 252, 30, 170, 19, 180, 190, 22, 131, 216, 201, 74, 18, 183, 163, 172, 39, 248, 23, 237, 250, 59, 7, 124, 164, 146, 255, 99, 16, 161, 171, 36, 189, 99, 233, 91, 144, 179, 217, 53, 157, 199, 8, 165, 13, 2, 124, 143, 134, 91, 26, 227, 198, 68, 19, 155, 53, 29, 213, 244, 95, 149, 135, 44, 250, 183, 106, 156, 107, 74, 97, 114, 128, 215, 106, 149, 138, 111, 32, 209, 161, 214, 30, 216, 72, 108, 138, 56, 79, 236, 104, 186, 63, 209, 183, 172, 201, 103, 112, 200, 100, 162, 248, 156 }, "0000000000000", null, true },
                    { 3, "Student", "oguzhan@student", "1234", false, "Oguzhan", "Ozcelik", new byte[] { 46, 120, 221, 209, 203, 75, 128, 21, 122, 10, 215, 126, 23, 197, 112, 37, 105, 148, 9, 1, 30, 116, 108, 233, 82, 65, 0, 44, 200, 145, 155, 191, 68, 57, 68, 228, 1, 107, 83, 86, 161, 162, 82, 55, 202, 82, 170, 221, 0, 61, 203, 11, 199, 0, 16, 13, 64, 85, 21, 236, 9, 51, 247, 212 }, new byte[] { 146, 42, 48, 131, 60, 140, 121, 209, 223, 195, 154, 182, 34, 220, 130, 162, 122, 107, 121, 23, 63, 8, 11, 24, 190, 252, 30, 170, 19, 180, 190, 22, 131, 216, 201, 74, 18, 183, 163, 172, 39, 248, 23, 237, 250, 59, 7, 124, 164, 146, 255, 99, 16, 161, 171, 36, 189, 99, 233, 91, 144, 179, 217, 53, 157, 199, 8, 165, 13, 2, 124, 143, 134, 91, 26, 227, 198, 68, 19, 155, 53, 29, 213, 244, 95, 149, 135, 44, 250, 183, 106, 156, 107, 74, 97, 114, 128, 215, 106, 149, 138, 111, 32, 209, 161, 214, 30, 216, 72, 108, 138, 56, 79, 236, 104, 186, 63, 209, 183, 172, 201, 103, 112, 200, 100, 162, 248, 156 }, "0000000000000", null, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "Discriminator", "Email", "EmailVerificationCode", "EmailVerifiedStatus", "FirstName", "ImagePath", "LastName", "PasswordHash", "PasswordSalt", "Phone", "PhoneVerificationCode", "PhoneVerifiedStatus" },
                values: new object[,]
                {
                    { 4, "Selamlar", "Tutor", "ozgur@tutor", null, true, "Halil Ozgur", null, "Demir", new byte[] { 46, 120, 221, 209, 203, 75, 128, 21, 122, 10, 215, 126, 23, 197, 112, 37, 105, 148, 9, 1, 30, 116, 108, 233, 82, 65, 0, 44, 200, 145, 155, 191, 68, 57, 68, 228, 1, 107, 83, 86, 161, 162, 82, 55, 202, 82, 170, 221, 0, 61, 203, 11, 199, 0, 16, 13, 64, 85, 21, 236, 9, 51, 247, 212 }, new byte[] { 146, 42, 48, 131, 60, 140, 121, 209, 223, 195, 154, 182, 34, 220, 130, 162, 122, 107, 121, 23, 63, 8, 11, 24, 190, 252, 30, 170, 19, 180, 190, 22, 131, 216, 201, 74, 18, 183, 163, 172, 39, 248, 23, 237, 250, 59, 7, 124, 164, 146, 255, 99, 16, 161, 171, 36, 189, 99, 233, 91, 144, 179, 217, 53, 157, 199, 8, 165, 13, 2, 124, 143, 134, 91, 26, 227, 198, 68, 19, 155, 53, 29, 213, 244, 95, 149, 135, 44, 250, 183, 106, 156, 107, 74, 97, 114, 128, 215, 106, 149, 138, 111, 32, 209, 161, 214, 30, 216, 72, 108, 138, 56, 79, 236, 104, 186, 63, 209, 183, 172, 201, 103, 112, 200, 100, 162, 248, 156 }, "0000000000000", null, true },
                    { 5, "Merhaba arkadaslar", "Tutor", "yusuf@tutor", null, true, "Yusuf Mirac", null, "Uyar", new byte[] { 46, 120, 221, 209, 203, 75, 128, 21, 122, 10, 215, 126, 23, 197, 112, 37, 105, 148, 9, 1, 30, 116, 108, 233, 82, 65, 0, 44, 200, 145, 155, 191, 68, 57, 68, 228, 1, 107, 83, 86, 161, 162, 82, 55, 202, 82, 170, 221, 0, 61, 203, 11, 199, 0, 16, 13, 64, 85, 21, 236, 9, 51, 247, 212 }, new byte[] { 146, 42, 48, 131, 60, 140, 121, 209, 223, 195, 154, 182, 34, 220, 130, 162, 122, 107, 121, 23, 63, 8, 11, 24, 190, 252, 30, 170, 19, 180, 190, 22, 131, 216, 201, 74, 18, 183, 163, 172, 39, 248, 23, 237, 250, 59, 7, 124, 164, 146, 255, 99, 16, 161, 171, 36, 189, 99, 233, 91, 144, 179, 217, 53, 157, 199, 8, 165, 13, 2, 124, 143, 134, 91, 26, 227, 198, 68, 19, 155, 53, 29, 213, 244, 95, 149, 135, 44, 250, 183, 106, 156, 107, 74, 97, 114, 128, 215, 106, 149, 138, 111, 32, 209, 161, 214, 30, 216, 72, 108, 138, 56, 79, 236, 104, 186, 63, 209, 183, 172, 201, 103, 112, 200, 100, 162, 248, 156 }, "0000000000000", "1234", false }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AffilatedTutorId", "Description", "DocumentPath", "Duration", "ExpirationDate", "Name", "Subject", "VerifiedStatus" },
                values: new object[,]
                {
                    { 1, 4, "MAT101 Veriyorum", null, 60, null, "MAT101", 1, 0 },
                    { 2, 4, "TOEFL Veriyorum", "/fake/path", 90, new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), "TOEFL", 0, 1 },
                    { 3, 4, "GRE Veriyorum", "/fake/path", 30, new DateTime(2023, 3, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), "GRE", 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AffilatedCourseId", "AffilatedStudentId", "CanceledBy", "Date" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, null, new DateTime(2023, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 2, null, new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 3, null, new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "AffilatedCourseId", "FilePath" },
                values: new object[,]
                {
                    { 1, 1, "/File/Path/Fake" },
                    { 2, 1, "/File/Path/Fake" },
                    { 3, 2, "/File/Path/Fake" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AffilatedCourseId", "AffilatedStudentId", "Comment", "Date", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, "Kotu", new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 9.8m },
                    { 2, 2, 1, "Iyi", new DateTime(2023, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 6.8m },
                    { 3, 2, 3, "Vasat", new DateTime(2023, 5, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 4.8m }
                });

            migrationBuilder.InsertData(
                table: "WhiteboardSaves",
                columns: new[] { "Id", "AffilatedBookingId", "SavePath", "SaveTime" },
                values: new object[,]
                {
                    { 1, 1, "/File/Path/Fake", new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "/File/Path/Fake", new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "/File/Path/Fake", new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AffilatedCourseId",
                table: "Bookings",
                column: "AffilatedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AffilatedStudentId",
                table: "Bookings",
                column: "AffilatedStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AffilatedTutorId",
                table: "Courses",
                column: "AffilatedTutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AffilatedCourseId",
                table: "Materials",
                column: "AffilatedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AffilatedCourseId",
                table: "Reviews",
                column: "AffilatedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AffilatedStudentId",
                table: "Reviews",
                column: "AffilatedStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_WhiteboardSaves_AffilatedBookingId",
                table: "WhiteboardSaves",
                column: "AffilatedBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WhiteboardSaves");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
