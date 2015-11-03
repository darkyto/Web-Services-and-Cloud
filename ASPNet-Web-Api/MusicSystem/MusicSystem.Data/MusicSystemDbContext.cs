namespace MusicSystem.Data
{
    using System.Data.Entity;
    using MusicSystem.Data.Migrations;
    using MusicSystem.Models;

    public class MusicSystemDbContext : DbContext, IMusicSystemDbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Producer> Producers { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
