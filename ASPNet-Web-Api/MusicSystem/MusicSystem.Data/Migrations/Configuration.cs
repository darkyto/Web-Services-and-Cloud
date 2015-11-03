using System.Linq;
using MusicSystem.Models;

namespace MusicSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MusicSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MusicSystemDbContext context)
        {
            context.Genres.AddOrUpdate(
                  x => x.Name,
                  new Genre { Name = "Classics" },
                  new Genre { Name = "Alternative" },
                  new Genre { Name = "Esoteric" },
                  new Genre { Name = "Rap" });

            context.Producers.AddOrUpdate(
                x => x.Name,
                new Producer { Name = "Goldstein" },
                new Producer { Name = "Moche" },
                new Producer { Name = "Goldenberg" },
                new Producer { Name = "Bue" });

            context.Countries.AddOrUpdate(
                x => x.Name,
                new Country { Name = "USA" },
                new Country { Name = "Germany" },
                new Country { Name = "Italy" },
                new Country { Name = "India" });

            context.SaveChanges();

            context.Songs.AddOrUpdate(
                x => x.Name,
                new Song { Year = 1995, Name = "Test song", GenreId = 1 },
                new Song { Year = 2005, Name = "New song", GenreId = 2 },
                new Song { Year = 1999, Name = "Another sound", GenreId = 2 },
                new Song { Year = 2014, Name = "Tralala", GenreId = 3 });

            context.Artists.AddOrUpdate(
                x => x.Name,
                new Artist { Name = "Pesho Petrov", CountryId = 3 },
                new Artist { Name = "Lil Dicky", CountryId = 1 },
                new Artist { Name = "Tricky", CountryId = 2 },
                new Artist { Name = "ANonymious", CountryId = 4 });

            context.SaveChanges();

            var firstAlbum = new Album { Title = "Album name", ProducerId = 1};

            context.Albums.AddOrUpdate(
                x => x.Title,
                firstAlbum,
                new Album { Title = "Album name", ProducerId = 2},
                new Album { Title = "New Album name", ProducerId = 3},
                new Album { Title = "Save that money", ProducerId = 4});

            firstAlbum.Artists.Add(context.Artists.First());
            firstAlbum.Songs.Add(context.Songs.First());

            context.SaveChanges();
        }
    }
}
