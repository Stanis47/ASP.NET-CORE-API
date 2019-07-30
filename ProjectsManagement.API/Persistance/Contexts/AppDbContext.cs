using Microsoft.EntityFrameworkCore;
using ProjectsManagement.API.Domain.Models;

namespace ProjectsManagement.API.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<ProjectProgrammer> ProjectProgrammers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectID)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Project>()
                .Property(p => p.FullDescription)
                .HasMaxLength(300);

            modelBuilder.Entity<Project>()
                .Property(p => p.IsCompleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Project>()
                .Property(p => p.DateCreated)
                .HasColumnType("date")
                .HasDefaultValueSql("getDate()");

            modelBuilder.Entity<Project>().HasData
            (
                new Project
                {
                    ProjectID = 100,
                    Name = "First Project",
                    Description = "Shord description for project",
                    FullDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.",
                    IsCompleted = false
                },

                new Project
                {
                    ProjectID = 101,
                    Name = "Second Project",
                    Description = "Shord description for project",
                    FullDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.",
                    IsCompleted = false
                },

                new Project
                {
                    ProjectID = 102,
                    Name = "Third Project",
                    Description = "Shord description for project",
                    FullDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.",
                    IsCompleted = false
                },

                new Project
                {
                    ProjectID = 103,
                    Name = "Fourth Project",
                    Description = "Shord description for project",
                    FullDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Fuga aliquid dolorem ea distinctio exercitationem delectus qui, quas eum architecto, amet quasi accusantium, fugit consequatur ducimus obcaecati numquam molestias hic itaque accusantium doloremque laudantium, totam rem aperiam.",
                    IsCompleted = false
                }
            ); ;

            modelBuilder.Entity<Programmer>()
                .Property(p => p.ProgrammerID)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Programmer>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Programmer>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Programmer>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<Programmer>()
                .Ignore(p => p.Age);

            modelBuilder.Entity<Programmer>().HasData
            (
                new Programmer
                {
                    ProgrammerID = 100,
                    FirstName = "BoJack",
                    LastName = "Horseman",
                    Email = "bojack@mail.com",
                    Phone = "+ 11 111 11 11 111",
                    ImageUrl = "https://localhost:44340/images/bojack.jpg",
                    BirthDate = new System.DateTime(2019 - 07 - 10)
                },

                new Programmer
                {
                    ProgrammerID = 101,
                    FirstName = "Diane",
                    LastName = "Nguyen",
                    Email = "nguyen@mail.com",
                    Phone = "+22 222 22 22 222",
                    ImageUrl = "https://localhost:44340/images/diane.jpg",
                    BirthDate = new System.DateTime(11/14/1985)
                },

                new Programmer
                {
                    ProgrammerID = 102,
                    FirstName = "Todd",
                    LastName = "Chavez",
                    Email = "chavez@mail.com",
                    Phone = "+33 333 33 33 333",
                    ImageUrl = "https://localhost:44340/images/todd.jpg",
                    BirthDate = new System.DateTime(8/17/1994)
                },

                new Programmer
                {
                    ProgrammerID = 103,
                    FirstName = "Mr.",
                    LastName = "Peanutbutter",
                    Email = "peanutbutter@mail.com",
                    Phone = "+44 444 44 44 444",
                    ImageUrl = "https://localhost:44340/images/peanutbutter.jpg",
                    BirthDate = new System.DateTime(9/6/1975)
                },

                new Programmer
                {
                    ProgrammerID = 104,
                    FirstName = "Princess",
                    LastName = "Carolyn",
                    Email = "carolyn@mail.com",
                    Phone = "+55 555 55 55 555",
                    ImageUrl = "https://localhost:44340/images/carolyn.jpg",
                    BirthDate = new System.DateTime(6/28/1988)
                },

                new Programmer
                {
                    ProgrammerID = 105,
                    FirstName = "Judah",
                    LastName = "Mannowdog",
                    Email = "mannowdog@mail.com",
                    Phone = "+66 666 66 66 666",
                    ImageUrl = "https://localhost:44340/images/mannowdog.jpg",
                    BirthDate = new System.DateTime(10/6/1986)
                }
            );

            modelBuilder.Entity<ProjectProgrammer>()
                .HasKey(pp => new { pp.ProjectID, pp.ProgrammerID });

            modelBuilder.Entity<ProjectProgrammer>()
                .HasOne(pp => pp.Project)
                .WithMany(p => p.Programmers)
                .HasForeignKey(pp => pp.ProjectID);

            modelBuilder.Entity<ProjectProgrammer>()
                .HasOne(pp => pp.Programmer)
                .WithMany(p => p.Projects)
                .HasForeignKey(pp => pp.ProgrammerID);

            modelBuilder.Entity<ProjectProgrammer>().HasData
            (
                new ProjectProgrammer
                {
                    ProjectID = 100,
                    ProgrammerID = 100
                },

                new ProjectProgrammer
                {
                    ProjectID = 100,
                    ProgrammerID = 102
                },

                new ProjectProgrammer
                {
                    ProjectID = 100,
                    ProgrammerID = 104
                },

                new ProjectProgrammer
                {
                    ProjectID = 101,
                    ProgrammerID = 101
                },

                new ProjectProgrammer
                {
                    ProjectID = 101,
                    ProgrammerID = 103
                },

                new ProjectProgrammer
                {
                    ProjectID = 101,
                    ProgrammerID = 105
                },

                new ProjectProgrammer
                {
                    ProjectID = 102,
                    ProgrammerID = 100
                },

                new ProjectProgrammer
                {
                    ProjectID = 102,
                    ProgrammerID = 102
                },

                new ProjectProgrammer
                {
                    ProjectID = 102,
                    ProgrammerID = 104
                },

                new ProjectProgrammer
                {
                    ProjectID = 103,
                    ProgrammerID = 102
                },

                new ProjectProgrammer
                {
                    ProjectID = 103,
                    ProgrammerID = 105
                },

                new ProjectProgrammer
                {
                    ProjectID = 103,
                    ProgrammerID = 104
                }
            );
        }
    }
}
