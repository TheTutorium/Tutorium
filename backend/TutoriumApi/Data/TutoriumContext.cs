using tutorium.Models;
using tutorium.Utils;

using Microsoft.EntityFrameworkCore;

namespace tutorium.Data
{
    public class TutoriumContext : DbContext
    {
        public TutoriumContext(DbContextOptions<TutoriumContext> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WhiteboardSave> WhiteboardSaves { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            byte[] hash, salt;
            Auth.CreateHash("tutorium", out hash, out salt);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "baris@student",
                    EmailVerifiedStatus = true,
                    FirstName = "Baris Ogun",
                    LastName = "Yoruk",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "00905075711001",
                    PhoneVerifiedStatus = true,
                    UserType = UserType.Student
                },
                new User
                {
                    Id = 2,
                    Email = "cagri@student",
                    EmailVerifiedStatus = true,
                    FirstName = "Mustafa Cagri",
                    LastName = "Durgut",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "0000000000000",
                    PhoneVerifiedStatus = false,
                    PhoneVerificationCode = "00000",
                    UserType = UserType.Student
                },
                new User
                {
                    Id = 3,
                    Email = "oguzhan@student",
                    EmailVerifiedStatus = false,
                    EmailVerificationCode = "00000",
                    FirstName = "Mustafa Cagri",
                    LastName = "Durgut",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "0000000000000",
                    PhoneVerifiedStatus = false,
                    PhoneVerificationCode = "00000",
                    UserType = UserType.Student
                },
                new User
                {
                    Id = 4,
                    Description = "Selamlar",
                    Email = "ozgur@tutor",
                    EmailVerifiedStatus = true,
                    FirstName = "Halil Ozgur",
                    LastName = "Demir",
                    ImagePath = "fake/image/path",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "0000000000000",
                    PhoneVerifiedStatus = true,
                    UserType = UserType.Tutor,
                },
                new User
                {
                    Id = 5,
                    Description = "Merhaba arkadaslar",
                    Email = "yusuf@tutor",
                    EmailVerifiedStatus = true,
                    FirstName = "Yusuf Mirac",
                    LastName = "Uyar",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "0000000000000",
                    PhoneVerifiedStatus = true,
                    UserType = UserType.Tutor,
                },
                new User
                {
                    Id = 6,
                    Description = "Merhaba arkadaslar",
                    Email = "aybala@tutor",
                    EmailVerifiedStatus = true,
                    FirstName = "Aybala",
                    LastName = "Karakaya",
                    PasswordHash = hash,
                    SecondPasswordHash = hash,
                    PasswordSalt = salt,
                    Phone = "0000000000000",
                    PhoneVerificationCode = "1234",
                    PhoneVerifiedStatus = false,
                    UserType = UserType.Tutor,
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Description = "MAT101 Veriyorum",
                    Duration = 60,
                    Name = "MAT101",
                    Subject = SubjectType.Mathematics,
                    VerifiedStatus = VerifiedStatusType.NotVerifable,
                    AffilatedTutorId = 4
                },
                new Course
                {
                    Id = 2,
                    Description = "TOEFL Veriyorum",
                    Duration = 90,
                    Name = "TOEFL",
                    Subject = SubjectType.English,
                    DocumentPath = "/fake/path",
                    ExpirationDate = new DateTime(2023, 2, 15, 17, 0, 0),
                    VerifiedStatus = VerifiedStatusType.NotVerified,
                    AffilatedTutorId = 4
                },
                new Course
                {
                    Id = 3,
                    Description = "GRE Veriyorum",
                    Duration = 30,
                    Name = "GRE",
                    Subject = SubjectType.English,
                    DocumentPath = "/fake/path",
                    ExpirationDate = new DateTime(2023, 3, 15, 17, 0, 0),
                    VerifiedStatus = VerifiedStatusType.Verified,
                    AffilatedTutorId = 5
                }
            );

            modelBuilder.Entity<Material>().HasData(
                new Material
                {
                    Id = 1,
                    CreatedAt = new DateTime(2023, 3, 15, 17, 0, 0),
                    Description = "dasdas",
                    DisplayName = "adsdas",
                    FilePath = "/File/Path/Fake",
                    AffilatedCourseId = 1
                },
                new Material
                {
                    Id = 2,
                    CreatedAt = new DateTime(2023, 3, 15, 17, 0, 0),
                    Description = "dasdas",
                    DisplayName = "adsdas",
                    FilePath = "/File/Path/Fake",
                    UpdatedAt = new DateTime(2024, 3, 15, 17, 0, 0),
                    AffilatedCourseId = 2
                },
                new Material
                {
                    Id = 3,
                    CreatedAt = new DateTime(2023, 3, 15, 17, 0, 0),
                    Description = "dasdas",
                    DisplayName = "adsdas",
                    FilePath = "/File/Path/Fake",
                    AffilatedCourseId = 2
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    Date = new DateTime(2023, 2, 15, 17, 0, 0),
                    AffilatedCourseId = 1,
                    AffilatedStudentId = 1,
                },
                new Booking
                {
                    Id = 2,
                    CanceledBy = CanceledBy.Student,
                    Date = new DateTime(2023, 1, 15, 8, 0, 0),
                    AffilatedCourseId = 2,
                    AffilatedStudentId = 2,
                },
                new Booking
                {
                    Id = 3,
                    Date = new DateTime(2023, 1, 20, 10, 0, 0),
                    CanceledBy = CanceledBy.Tutor,
                    AffilatedCourseId = 2,
                    AffilatedStudentId = 2,
                },
                new Booking
                {
                    Id = 4,
                    CanceledBy = CanceledBy.System,
                    Date = new DateTime(2023, 3, 30, 7, 0, 0),
                    AffilatedCourseId = 3,
                    AffilatedStudentId = 1,
                }
            );

            modelBuilder.Entity<WhiteboardSave>().HasData(
                new WhiteboardSave
                {
                    Id = 1,
                    SavePath = "/File/Path/Fake",
                    SaveTime = new DateTime(2023, 3, 30, 7, 0, 0),
                    AffilatedBookingId = 1,
                },
                new WhiteboardSave
                {
                    Id = 2,
                    SavePath = "/File/Path/Fake",
                    SaveTime = new DateTime(2023, 3, 30, 7, 0, 0),
                    AffilatedBookingId = 3,
                },
                new WhiteboardSave
                {
                    Id = 3,
                    SavePath = "/File/Path/Fake",
                    SaveTime = new DateTime(2023, 3, 30, 7, 0, 0),
                    AffilatedBookingId = 3,
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Comment = "Kotu",
                    CreatedAt = new DateTime(2023, 3, 30, 7, 0, 0),
                    UpdatedAt = new DateTime(2024, 3, 30, 7, 0, 0),
                    Rating = 9.8m,
                    AffilatedCourseId = 1,
                    AffilatedStudentId = 1,
                },
                new Review
                {
                    Id = 2,
                    Comment = "Iyi",
                    CreatedAt = new DateTime(2023, 4, 30, 7, 0, 0),
                    Rating = 6.8m,
                    AffilatedCourseId = 2,
                    AffilatedStudentId = 2,
                },
                new Review
                {
                    Id = 3,
                    Comment = "Vasat",
                    CreatedAt = new DateTime(2023, 5, 30, 7, 0, 0),
                    Rating = 4.8m,
                    AffilatedCourseId = 3,
                    AffilatedStudentId = 1,
                }
            );
        }

    }
}
