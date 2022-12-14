﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tutorium.Data;

#nullable disable

namespace TutoriumApi.Migrations
{
    [DbContext(typeof(TutoriumContext))]
    partial class TutoriumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

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
                            Date = new DateTime(2023, 2, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = 60
                        },
                        new
                        {
                            Id = 2,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 2,
                            Date = new DateTime(2023, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = 90
                        },
                        new
                        {
                            Id = 3,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 2,
                            Date = new DateTime(2023, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = 90
                        },
                        new
                        {
                            Id = 4,
                            AffilatedCourseId = 3,
                            AffilatedStudentId = 3,
                            Date = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = 30
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

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(2, 1)");

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
                            Date = new DateTime(2023, 3, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 9.8m
                        },
                        new
                        {
                            Id = 2,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 1,
                            Comment = "Iyi",
                            Date = new DateTime(2023, 4, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 6.8m
                        },
                        new
                        {
                            Id = 3,
                            AffilatedCourseId = 2,
                            AffilatedStudentId = 3,
                            Comment = "Vasat",
                            Date = new DateTime(2023, 5, 30, 7, 0, 0, 0, DateTimeKind.Unspecified),
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
                            PasswordHash = new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 },
                            PasswordSalt = new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 },
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
                            PasswordHash = new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 },
                            PasswordSalt = new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 },
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
                            PasswordHash = new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 },
                            PasswordSalt = new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 },
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
                            PasswordHash = new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 },
                            PasswordSalt = new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 },
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
                            PasswordHash = new byte[] { 28, 119, 117, 132, 98, 110, 59, 77, 5, 58, 215, 171, 59, 16, 255, 69, 211, 89, 49, 182, 173, 1, 148, 11, 225, 83, 250, 122, 124, 225, 217, 207, 29, 197, 96, 200, 232, 40, 165, 223, 241, 84, 27, 194, 172, 127, 153, 34, 111, 229, 70, 17, 207, 118, 169, 84, 145, 23, 94, 120, 47, 56, 104, 68 },
                            PasswordSalt = new byte[] { 110, 11, 203, 181, 227, 124, 93, 215, 5, 186, 224, 221, 168, 181, 23, 44, 236, 48, 232, 0, 199, 169, 96, 16, 55, 84, 202, 196, 140, 159, 114, 53, 94, 196, 63, 78, 39, 170, 217, 116, 223, 79, 67, 107, 78, 120, 147, 90, 21, 247, 92, 188, 76, 37, 189, 157, 23, 181, 57, 213, 77, 92, 116, 178, 133, 240, 105, 183, 50, 38, 11, 29, 67, 105, 151, 158, 32, 192, 72, 76, 26, 93, 162, 205, 81, 187, 158, 68, 73, 190, 250, 109, 84, 114, 3, 24, 132, 37, 71, 196, 104, 225, 200, 238, 148, 36, 234, 79, 137, 42, 49, 145, 117, 42, 94, 5, 61, 158, 51, 34, 56, 141, 88, 90, 167, 208, 48, 9 },
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
                        .WithMany()
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
                });

            modelBuilder.Entity("tutorium.Models.Tutor", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
