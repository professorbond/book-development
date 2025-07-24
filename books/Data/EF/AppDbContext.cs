using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Data.Entities;

namespace MyBlazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<City>().HasData(
                new City { Id = 1, Name = "Караганда" },
                new City { Id = 2, Name = "Астана" },
                new City { Id = 3, Name = "Алмата" },
                new City { Id = 4, Name = "Темиртау" },
                new City { Id = 5, Name = "Шымкент" }
            );

            builder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    LastName = "Иванов",
                    Note = "Сидел 2 года",
                    CityId = 1,
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Петр",
                    MiddleName = "Петрович",
                    LastName = "Петров",
                    Note = "ну просто Петя",
                    CityId = 2,
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Сергей",
                    MiddleName = "Сергеевич",
                    LastName = "Сергеев",
                    Note = "четкий пацан",
                    CityId = 3,
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Дмитрий",
                    MiddleName = "Дмитриевич",
                    LastName = "Дмитриев",
                    Note = "спортсмен",
                    CityId = 4,
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Андрей",
                    MiddleName = "Андреевич",
                    LastName = "Андреев",
                    Note = "в законе",
                    CityId = 5,
                }
            );

            builder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    PhoneNumber = "+77978972679",
                    IsBankLinked = true,
                    PhoneType = "сотовый",
                    PersonId = 1,
                },
                new Phone
                {
                    Id = 2,
                    PhoneNumber = "+77777777777",
                    IsBankLinked = false,
                    PhoneType = "сотовый",
                    PersonId = 2,
                },
                new Phone
                {
                    Id = 3,
                    PhoneNumber = "+77765672456",
                    IsBankLinked = true,
                    PhoneType = "сотовый",
                    PersonId = 3,
                },
                new Phone
                {
                    Id = 4,
                    PhoneNumber = "+77778976655",
                    IsBankLinked = false,
                    PhoneType = "сотовый",
                    PersonId = 4,
                },
                new Phone
                {
                    Id = 5,
                    PhoneNumber = "+77770950095",
                    IsBankLinked = true,
                    PhoneType = "сотовый",
                    PersonId = 5,
                },
                new Phone
                {
                    Id = 6,
                    PhoneNumber = "+77001112233",
                    IsBankLinked = false,
                    PhoneType = "домашний",
                    PersonId = 1,
                },
                new Phone
                {
                    Id = 7,
                    PhoneNumber = "+77005556677",
                    IsBankLinked = true,
                    PhoneType = "рабочий",
                    PersonId = 2,
                }
            );
        }
    }
}
