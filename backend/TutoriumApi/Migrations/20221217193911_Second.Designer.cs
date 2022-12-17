﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tutorium.Data;

#nullable disable

namespace TutoriumApi.Migrations
{
    [DbContext(typeof(TutoriumContext))]
    [Migration("20221217193911_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("tutorium.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AffilatedCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("AffilatedStudentId")
                        .HasColumnType("integer");

                    b.Property<int?>("CanceledBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AffilatedCourseId");

                    b.HasIndex("AffilatedStudentId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffilatedCourseId = 1,
                            AffilatedStudentId = 1,
                            Date = new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 2,
                            Date = new DateTime(2023, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 2,
                            Date = new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AffilatedCourseId = 3,
                            AffilatedStudentId = 3,
                            Date = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("tutorium.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AffilatedTutorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocumentPath")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Subject")
                        .HasColumnType("integer");

                    b.Property<int>("VerifiedStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AffilatedTutorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffilatedTutorId = 4,
                            Description = "MAT101 Veriyorum",
                            Duration = 60,
                            Name = "MAT101",
                            Subject = 1,
                            VerifiedStatus = 0
                        },
                        new
                        {
                            Id = 2,
                            AffilatedTutorId = 4,
                            Description = "TOEFL Veriyorum",
                            DocumentPath = "/fake/path",
                            Duration = 90,
                            ExpirationDate = new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "TOEFL",
                            Subject = 0,
                            VerifiedStatus = 1
                        },
                        new
                        {
                            Id = 3,
                            AffilatedTutorId = 4,
                            Description = "GRE Veriyorum",
                            DocumentPath = "/fake/path",
                            Duration = 30,
                            ExpirationDate = new DateTime(2023, 3, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "GRE",
                            Subject = 0,
                            VerifiedStatus = 3
                        });
                });

            modelBuilder.Entity("tutorium.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AffilatedCourseId")
                        .HasColumnType("integer");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AffilatedCourseId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffilatedCourseId = 1,
                            FilePath = "/File/Path/Fake"
                        },
                        new
                        {
                            Id = 2,
                            AffilatedCourseId = 1,
                            FilePath = "/File/Path/Fake"
                        },
                        new
                        {
                            Id = 3,
                            AffilatedCourseId = 2,
                            FilePath = "/File/Path/Fake"
                        });
                });

            modelBuilder.Entity("tutorium.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AffilatedCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("AffilatedStudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3, 1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AffilatedCourseId");

                    b.HasIndex("AffilatedStudentId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffilatedCourseId = 1,
                            AffilatedStudentId = 1,
                            Comment = "Kotu",
                            CreatedAt = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 9.8m,
                            UpdatedAt = new DateTime(2024, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 1,
                            Comment = "Iyi",
                            CreatedAt = new DateTime(2023, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 6.8m
                        },
                        new
                        {
                            Id = 3,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 3,
                            Comment = "Vasat",
                            CreatedAt = new DateTime(2023, 5, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 4.8m
                        });
                });

            modelBuilder.Entity("tutorium.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailVerificationCode")
                        .HasColumnType("text");

                    b.Property<bool>("EmailVerifiedStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneVerificationCode")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneVerifiedStatus")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("tutorium.Models.WhiteboardSave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AffilatedBookingId")
                        .HasColumnType("integer");

                    b.Property<string>("SavePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SaveTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AffilatedBookingId");

                    b.ToTable("WhiteboardSaves");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AffilatedBookingId = 1,
                            SavePath = "/File/Path/Fake",
                            SaveTime = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AffilatedBookingId = 3,
                            SavePath = "/File/Path/Fake",
                            SaveTime = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AffilatedBookingId = 3,
                            SavePath = "/File/Path/Fake",
                            SaveTime = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("tutorium.Models.Student", b =>
                {
                    b.HasBaseType("tutorium.Models.User");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "baris@student",
                            EmailVerifiedStatus = true,
                            FirstName = "Baris Ogun",
                            LastName = "Yoruk",
                            PasswordHash = new byte[] { 162, 202, 51, 189, 55, 188, 235, 85, 219, 100, 9, 117, 195, 195, 9, 118, 109, 134, 9, 48, 46, 96, 221, 159, 33, 142, 133, 119, 60, 4, 232, 189, 22, 157, 70, 172, 218, 50, 91, 130, 65, 134, 239, 153, 211, 68, 1, 100, 181, 80, 97, 33, 8, 31, 63, 36, 108, 223, 167, 146, 251, 151, 118, 35 },
                            PasswordSalt = new byte[] { 91, 251, 157, 206, 246, 107, 236, 51, 214, 10, 128, 111, 220, 255, 24, 184, 253, 177, 165, 96, 66, 113, 227, 61, 170, 166, 222, 99, 176, 94, 11, 87, 173, 81, 27, 245, 99, 3, 228, 0, 52, 149, 149, 114, 98, 206, 179, 53, 91, 255, 68, 178, 118, 62, 255, 94, 16, 209, 19, 243, 253, 110, 2, 109, 88, 178, 51, 18, 43, 91, 235, 136, 223, 164, 99, 168, 150, 62, 8, 186, 161, 54, 201, 179, 31, 237, 163, 84, 100, 59, 250, 59, 19, 20, 20, 234, 211, 193, 169, 184, 86, 37, 34, 240, 224, 90, 49, 73, 125, 37, 108, 211, 92, 170, 125, 238, 227, 60, 232, 76, 168, 103, 152, 16, 51, 1, 18, 166 },
                            Phone = "00905075711001",
                            PhoneVerifiedStatus = true
                        },
                        new
                        {
                            Id = 2,
                            Email = "cagri@student",
                            EmailVerifiedStatus = true,
                            FirstName = "Mustafa Cagri",
                            LastName = "Durgut",
                            PasswordHash = new byte[] { 162, 202, 51, 189, 55, 188, 235, 85, 219, 100, 9, 117, 195, 195, 9, 118, 109, 134, 9, 48, 46, 96, 221, 159, 33, 142, 133, 119, 60, 4, 232, 189, 22, 157, 70, 172, 218, 50, 91, 130, 65, 134, 239, 153, 211, 68, 1, 100, 181, 80, 97, 33, 8, 31, 63, 36, 108, 223, 167, 146, 251, 151, 118, 35 },
                            PasswordSalt = new byte[] { 91, 251, 157, 206, 246, 107, 236, 51, 214, 10, 128, 111, 220, 255, 24, 184, 253, 177, 165, 96, 66, 113, 227, 61, 170, 166, 222, 99, 176, 94, 11, 87, 173, 81, 27, 245, 99, 3, 228, 0, 52, 149, 149, 114, 98, 206, 179, 53, 91, 255, 68, 178, 118, 62, 255, 94, 16, 209, 19, 243, 253, 110, 2, 109, 88, 178, 51, 18, 43, 91, 235, 136, 223, 164, 99, 168, 150, 62, 8, 186, 161, 54, 201, 179, 31, 237, 163, 84, 100, 59, 250, 59, 19, 20, 20, 234, 211, 193, 169, 184, 86, 37, 34, 240, 224, 90, 49, 73, 125, 37, 108, 211, 92, 170, 125, 238, 227, 60, 232, 76, 168, 103, 152, 16, 51, 1, 18, 166 },
                            Phone = "0000000000000",
                            PhoneVerifiedStatus = true
                        },
                        new
                        {
                            Id = 3,
                            Email = "oguzhan@student",
                            EmailVerificationCode = "1234",
                            EmailVerifiedStatus = false,
                            FirstName = "Oguzhan",
                            LastName = "Ozcelik",
                            PasswordHash = new byte[] { 162, 202, 51, 189, 55, 188, 235, 85, 219, 100, 9, 117, 195, 195, 9, 118, 109, 134, 9, 48, 46, 96, 221, 159, 33, 142, 133, 119, 60, 4, 232, 189, 22, 157, 70, 172, 218, 50, 91, 130, 65, 134, 239, 153, 211, 68, 1, 100, 181, 80, 97, 33, 8, 31, 63, 36, 108, 223, 167, 146, 251, 151, 118, 35 },
                            PasswordSalt = new byte[] { 91, 251, 157, 206, 246, 107, 236, 51, 214, 10, 128, 111, 220, 255, 24, 184, 253, 177, 165, 96, 66, 113, 227, 61, 170, 166, 222, 99, 176, 94, 11, 87, 173, 81, 27, 245, 99, 3, 228, 0, 52, 149, 149, 114, 98, 206, 179, 53, 91, 255, 68, 178, 118, 62, 255, 94, 16, 209, 19, 243, 253, 110, 2, 109, 88, 178, 51, 18, 43, 91, 235, 136, 223, 164, 99, 168, 150, 62, 8, 186, 161, 54, 201, 179, 31, 237, 163, 84, 100, 59, 250, 59, 19, 20, 20, 234, 211, 193, 169, 184, 86, 37, 34, 240, 224, 90, 49, 73, 125, 37, 108, 211, 92, 170, 125, 238, 227, 60, 232, 76, 168, 103, 152, 16, 51, 1, 18, 166 },
                            Phone = "0000000000000",
                            PhoneVerifiedStatus = true
                        });
                });

            modelBuilder.Entity("tutorium.Models.Tutor", b =>
                {
                    b.HasBaseType("tutorium.Models.User");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Tutor");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "ozgur@tutor",
                            EmailVerifiedStatus = true,
                            FirstName = "Halil Ozgur",
                            LastName = "Demir",
                            PasswordHash = new byte[] { 162, 202, 51, 189, 55, 188, 235, 85, 219, 100, 9, 117, 195, 195, 9, 118, 109, 134, 9, 48, 46, 96, 221, 159, 33, 142, 133, 119, 60, 4, 232, 189, 22, 157, 70, 172, 218, 50, 91, 130, 65, 134, 239, 153, 211, 68, 1, 100, 181, 80, 97, 33, 8, 31, 63, 36, 108, 223, 167, 146, 251, 151, 118, 35 },
                            PasswordSalt = new byte[] { 91, 251, 157, 206, 246, 107, 236, 51, 214, 10, 128, 111, 220, 255, 24, 184, 253, 177, 165, 96, 66, 113, 227, 61, 170, 166, 222, 99, 176, 94, 11, 87, 173, 81, 27, 245, 99, 3, 228, 0, 52, 149, 149, 114, 98, 206, 179, 53, 91, 255, 68, 178, 118, 62, 255, 94, 16, 209, 19, 243, 253, 110, 2, 109, 88, 178, 51, 18, 43, 91, 235, 136, 223, 164, 99, 168, 150, 62, 8, 186, 161, 54, 201, 179, 31, 237, 163, 84, 100, 59, 250, 59, 19, 20, 20, 234, 211, 193, 169, 184, 86, 37, 34, 240, 224, 90, 49, 73, 125, 37, 108, 211, 92, 170, 125, 238, 227, 60, 232, 76, 168, 103, 152, 16, 51, 1, 18, 166 },
                            Phone = "0000000000000",
                            PhoneVerifiedStatus = true,
                            Description = "Selamlar"
                        },
                        new
                        {
                            Id = 5,
                            Email = "yusuf@tutor",
                            EmailVerifiedStatus = true,
                            FirstName = "Yusuf Mirac",
                            LastName = "Uyar",
                            PasswordHash = new byte[] { 162, 202, 51, 189, 55, 188, 235, 85, 219, 100, 9, 117, 195, 195, 9, 118, 109, 134, 9, 48, 46, 96, 221, 159, 33, 142, 133, 119, 60, 4, 232, 189, 22, 157, 70, 172, 218, 50, 91, 130, 65, 134, 239, 153, 211, 68, 1, 100, 181, 80, 97, 33, 8, 31, 63, 36, 108, 223, 167, 146, 251, 151, 118, 35 },
                            PasswordSalt = new byte[] { 91, 251, 157, 206, 246, 107, 236, 51, 214, 10, 128, 111, 220, 255, 24, 184, 253, 177, 165, 96, 66, 113, 227, 61, 170, 166, 222, 99, 176, 94, 11, 87, 173, 81, 27, 245, 99, 3, 228, 0, 52, 149, 149, 114, 98, 206, 179, 53, 91, 255, 68, 178, 118, 62, 255, 94, 16, 209, 19, 243, 253, 110, 2, 109, 88, 178, 51, 18, 43, 91, 235, 136, 223, 164, 99, 168, 150, 62, 8, 186, 161, 54, 201, 179, 31, 237, 163, 84, 100, 59, 250, 59, 19, 20, 20, 234, 211, 193, 169, 184, 86, 37, 34, 240, 224, 90, 49, 73, 125, 37, 108, 211, 92, 170, 125, 238, 227, 60, 232, 76, 168, 103, 152, 16, 51, 1, 18, 166 },
                            Phone = "0000000000000",
                            PhoneVerificationCode = "1234",
                            PhoneVerifiedStatus = false,
                            Description = "Merhaba arkadaslar"
                        });
                });

            modelBuilder.Entity("tutorium.Models.Booking", b =>
                {
                    b.HasOne("tutorium.Models.Course", "AffilatedCourse")
                        .WithMany("Bookings")
                        .HasForeignKey("AffilatedCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tutorium.Models.Student", "AffilatedStudent")
                        .WithMany("Bookings")
                        .HasForeignKey("AffilatedStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffilatedCourse");

                    b.Navigation("AffilatedStudent");
                });

            modelBuilder.Entity("tutorium.Models.Course", b =>
                {
                    b.HasOne("tutorium.Models.Tutor", "AffilatedTutor")
                        .WithMany("Courses")
                        .HasForeignKey("AffilatedTutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffilatedTutor");
                });

            modelBuilder.Entity("tutorium.Models.Material", b =>
                {
                    b.HasOne("tutorium.Models.Course", "AffilatedCourse")
                        .WithMany("Materials")
                        .HasForeignKey("AffilatedCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffilatedCourse");
                });

            modelBuilder.Entity("tutorium.Models.Review", b =>
                {
                    b.HasOne("tutorium.Models.Course", "AffilatedCourse")
                        .WithMany("Reviews")
                        .HasForeignKey("AffilatedCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tutorium.Models.Student", "AffilatedStudent")
                        .WithMany("Reviews")
                        .HasForeignKey("AffilatedStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffilatedCourse");

                    b.Navigation("AffilatedStudent");
                });

            modelBuilder.Entity("tutorium.Models.WhiteboardSave", b =>
                {
                    b.HasOne("tutorium.Models.Booking", "AffilatedBooking")
                        .WithMany("WhiteboardSaves")
                        .HasForeignKey("AffilatedBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AffilatedBooking");
                });

            modelBuilder.Entity("tutorium.Models.Booking", b =>
                {
                    b.Navigation("WhiteboardSaves");
                });

            modelBuilder.Entity("tutorium.Models.Course", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Materials");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("tutorium.Models.Student", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("tutorium.Models.Tutor", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
