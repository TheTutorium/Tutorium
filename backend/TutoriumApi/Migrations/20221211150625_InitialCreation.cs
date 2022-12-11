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
                    AffilatedTutorId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    DocumentPath = table.Column<string>(type: "text", nullable: true),
                    VerifiedStatus = table.Column<bool>(type: "boolean", nullable: true)
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
                    ImagePath = table.Column<string>(type: "text", nullable: false),
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
                    { 1, "Student", "baris@student", null, true, "Baris Ogun", "Yoruk", new byte[] { 224, 245, 232, 129, 98, 114, 202, 238, 157, 60, 11, 63, 186, 24, 175, 189, 247, 87, 35, 81, 66, 73, 21, 254, 150, 39, 193, 143, 8, 20, 20, 158, 232, 63, 227, 138, 148, 40, 81, 98, 0, 73, 201, 133, 195, 229, 230, 76, 54, 29, 217, 43, 184, 244, 136, 134, 183, 149, 92, 163, 101, 58, 66, 180 }, new byte[] { 191, 9, 213, 80, 243, 112, 51, 218, 229, 187, 71, 50, 152, 106, 31, 128, 36, 130, 126, 215, 73, 74, 121, 47, 110, 217, 199, 15, 165, 28, 239, 11, 146, 177, 92, 28, 125, 138, 93, 139, 111, 181, 214, 216, 97, 202, 204, 125, 189, 177, 65, 230, 101, 238, 185, 182, 36, 84, 2, 45, 56, 198, 92, 74, 96, 137, 21, 63, 121, 106, 151, 88, 105, 213, 158, 160, 67, 108, 4, 136, 192, 32, 4, 85, 227, 61, 119, 197, 41, 0, 247, 214, 167, 169, 80, 17, 63, 194, 140, 225, 240, 170, 146, 227, 155, 129, 118, 55, 142, 79, 255, 6, 198, 17, 48, 60, 254, 171, 122, 168, 129, 226, 151, 196, 241, 15, 63, 200 }, "00905075711001", null, true },
                    { 2, "Student", "cagri@student", null, true, "Mustafa Cagri", "Durgut", new byte[] { 224, 245, 232, 129, 98, 114, 202, 238, 157, 60, 11, 63, 186, 24, 175, 189, 247, 87, 35, 81, 66, 73, 21, 254, 150, 39, 193, 143, 8, 20, 20, 158, 232, 63, 227, 138, 148, 40, 81, 98, 0, 73, 201, 133, 195, 229, 230, 76, 54, 29, 217, 43, 184, 244, 136, 134, 183, 149, 92, 163, 101, 58, 66, 180 }, new byte[] { 191, 9, 213, 80, 243, 112, 51, 218, 229, 187, 71, 50, 152, 106, 31, 128, 36, 130, 126, 215, 73, 74, 121, 47, 110, 217, 199, 15, 165, 28, 239, 11, 146, 177, 92, 28, 125, 138, 93, 139, 111, 181, 214, 216, 97, 202, 204, 125, 189, 177, 65, 230, 101, 238, 185, 182, 36, 84, 2, 45, 56, 198, 92, 74, 96, 137, 21, 63, 121, 106, 151, 88, 105, 213, 158, 160, 67, 108, 4, 136, 192, 32, 4, 85, 227, 61, 119, 197, 41, 0, 247, 214, 167, 169, 80, 17, 63, 194, 140, 225, 240, 170, 146, 227, 155, 129, 118, 55, 142, 79, 255, 6, 198, 17, 48, 60, 254, 171, 122, 168, 129, 226, 151, 196, 241, 15, 63, 200 }, "0000000000000", null, true },
                    { 3, "Student", "oguzhan@student", "1234", false, "Oguzhan", "Ozcelik", new byte[] { 224, 245, 232, 129, 98, 114, 202, 238, 157, 60, 11, 63, 186, 24, 175, 189, 247, 87, 35, 81, 66, 73, 21, 254, 150, 39, 193, 143, 8, 20, 20, 158, 232, 63, 227, 138, 148, 40, 81, 98, 0, 73, 201, 133, 195, 229, 230, 76, 54, 29, 217, 43, 184, 244, 136, 134, 183, 149, 92, 163, 101, 58, 66, 180 }, new byte[] { 191, 9, 213, 80, 243, 112, 51, 218, 229, 187, 71, 50, 152, 106, 31, 128, 36, 130, 126, 215, 73, 74, 121, 47, 110, 217, 199, 15, 165, 28, 239, 11, 146, 177, 92, 28, 125, 138, 93, 139, 111, 181, 214, 216, 97, 202, 204, 125, 189, 177, 65, 230, 101, 238, 185, 182, 36, 84, 2, 45, 56, 198, 92, 74, 96, 137, 21, 63, 121, 106, 151, 88, 105, 213, 158, 160, 67, 108, 4, 136, 192, 32, 4, 85, 227, 61, 119, 197, 41, 0, 247, 214, 167, 169, 80, 17, 63, 194, 140, 225, 240, 170, 146, 227, 155, 129, 118, 55, 142, 79, 255, 6, 198, 17, 48, 60, 254, 171, 122, 168, 129, 226, 151, 196, 241, 15, 63, 200 }, "0000000000000", null, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "Discriminator", "Email", "EmailVerificationCode", "EmailVerifiedStatus", "FirstName", "ImagePath", "LastName", "PasswordHash", "PasswordSalt", "Phone", "PhoneVerificationCode", "PhoneVerifiedStatus" },
                values: new object[,]
                {
                    { 4, "Selamlar", "Tutor", "ozgur@tutor", null, true, "Halil Ozgur", null, "Demir", new byte[] { 224, 245, 232, 129, 98, 114, 202, 238, 157, 60, 11, 63, 186, 24, 175, 189, 247, 87, 35, 81, 66, 73, 21, 254, 150, 39, 193, 143, 8, 20, 20, 158, 232, 63, 227, 138, 148, 40, 81, 98, 0, 73, 201, 133, 195, 229, 230, 76, 54, 29, 217, 43, 184, 244, 136, 134, 183, 149, 92, 163, 101, 58, 66, 180 }, new byte[] { 191, 9, 213, 80, 243, 112, 51, 218, 229, 187, 71, 50, 152, 106, 31, 128, 36, 130, 126, 215, 73, 74, 121, 47, 110, 217, 199, 15, 165, 28, 239, 11, 146, 177, 92, 28, 125, 138, 93, 139, 111, 181, 214, 216, 97, 202, 204, 125, 189, 177, 65, 230, 101, 238, 185, 182, 36, 84, 2, 45, 56, 198, 92, 74, 96, 137, 21, 63, 121, 106, 151, 88, 105, 213, 158, 160, 67, 108, 4, 136, 192, 32, 4, 85, 227, 61, 119, 197, 41, 0, 247, 214, 167, 169, 80, 17, 63, 194, 140, 225, 240, 170, 146, 227, 155, 129, 118, 55, 142, 79, 255, 6, 198, 17, 48, 60, 254, 171, 122, 168, 129, 226, 151, 196, 241, 15, 63, 200 }, "0000000000000", null, true },
                    { 5, "Merhaba arkadaslar", "Tutor", "yusuf@tutor", null, true, "Yusuf Mirac", null, "Uyar", new byte[] { 224, 245, 232, 129, 98, 114, 202, 238, 157, 60, 11, 63, 186, 24, 175, 189, 247, 87, 35, 81, 66, 73, 21, 254, 150, 39, 193, 143, 8, 20, 20, 158, 232, 63, 227, 138, 148, 40, 81, 98, 0, 73, 201, 133, 195, 229, 230, 76, 54, 29, 217, 43, 184, 244, 136, 134, 183, 149, 92, 163, 101, 58, 66, 180 }, new byte[] { 191, 9, 213, 80, 243, 112, 51, 218, 229, 187, 71, 50, 152, 106, 31, 128, 36, 130, 126, 215, 73, 74, 121, 47, 110, 217, 199, 15, 165, 28, 239, 11, 146, 177, 92, 28, 125, 138, 93, 139, 111, 181, 214, 216, 97, 202, 204, 125, 189, 177, 65, 230, 101, 238, 185, 182, 36, 84, 2, 45, 56, 198, 92, 74, 96, 137, 21, 63, 121, 106, 151, 88, 105, 213, 158, 160, 67, 108, 4, 136, 192, 32, 4, 85, 227, 61, 119, 197, 41, 0, 247, 214, 167, 169, 80, 17, 63, 194, 140, 225, 240, 170, 146, 227, 155, 129, 118, 55, 142, 79, 255, 6, 198, 17, 48, 60, 254, 171, 122, 168, 129, 226, 151, 196, 241, 15, 63, 200 }, "0000000000000", "1234", false }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AffilatedTutorId", "Description", "Discriminator", "Duration", "Name", "Subject" },
                values: new object[,]
                {
                    { 1, 4, "MAT101 Veriyorum", "Course", 60, "MAT101", 6 },
                    { 2, 4, "TOEFL Veriyorum", "Course", 90, "TOEFL", 3 },
                    { 3, 4, "GRE Veriyorum", "Course", 30, "GRE", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AffilatedTutorId", "Description", "Discriminator", "DocumentPath", "Duration", "Name", "Subject", "VerifiedStatus" },
                values: new object[,]
                {
                    { 4, 5, "YKS Mat Veriyorum", "VerifableCourse", null, 45, "YKS", 6, false },
                    { 5, 5, "YKS Fizik Veriyorum", "VerifableCourse", "/File/Path/Fake", 45, "YKS", 8, false }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AffilatedCourseId", "AffilatedStudentId", "CanceledBy", "Date" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, null, new DateTime(2023, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 2, null, new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 3, null, new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified) }
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
                columns: new[] { "Id", "AffilatedCourseId", "AffilatedStudentId", "Comment", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, "Kotu", 9.8m },
                    { 2, 2, 1, "Iyi", 6.8m },
                    { 3, 2, 3, "Vasat", 4.8m }
                });

            migrationBuilder.InsertData(
                table: "WhiteboardSaves",
                columns: new[] { "Id", "AffilatedBookingId", "ImagePath", "SaveTime" },
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
