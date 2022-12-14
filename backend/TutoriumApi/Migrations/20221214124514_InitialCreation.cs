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
                    Duration = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, "Student", "baris@student", null, true, "Baris Ogun", "Yoruk", new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 }, new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 }, "00905075711001", null, true },
                    { 2, "Student", "cagri@student", null, true, "Mustafa Cagri", "Durgut", new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 }, new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 }, "0000000000000", null, true },
                    { 3, "Student", "oguzhan@student", "1234", false, "Oguzhan", "Ozcelik", new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 }, new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 }, "0000000000000", null, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "Discriminator", "Email", "EmailVerificationCode", "EmailVerifiedStatus", "FirstName", "ImagePath", "LastName", "PasswordHash", "PasswordSalt", "Phone", "PhoneVerificationCode", "PhoneVerifiedStatus" },
                values: new object[,]
                {
                    { 4, "Selamlar", "Tutor", "ozgur@tutor", null, true, "Halil Ozgur", null, "Demir", new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 }, new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 }, "0000000000000", null, true },
                    { 5, "Merhaba arkadaslar", "Tutor", "yusuf@tutor", null, true, "Yusuf Mirac", null, "Uyar", new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 }, new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 }, "0000000000000", "1234", false }
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
                columns: new[] { "Id", "AffilatedCourseId", "AffilatedStudentId", "CanceledBy", "Date", "Duration" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 60 },
                    { 2, 2, 2, null, new DateTime(2023, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 3, 2, 2, null, new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 4, 3, 3, null, new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 30 }
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
