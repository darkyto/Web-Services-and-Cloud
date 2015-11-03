namespace MusicSystem.Data
{
    using MusicSystem.Data.Repositories;
    using MusicSystem.Models;

    public interface IMusicSystemData
    {
        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Country> Countries { get; }

        IRepository<Genre> Genres { get; }

        IRepository<Producer> Producers { get; }

        IRepository<Song> Songs { get; }

        int Savechanges();
    }
}
