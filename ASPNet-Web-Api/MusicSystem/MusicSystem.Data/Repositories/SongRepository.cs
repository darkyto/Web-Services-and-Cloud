namespace MusicSystem.Data.Repositories
{
    using System.Linq;
    using MusicSystem.Models;

    public class SongRepository : GenericRepositority<Song>
    {
        public SongRepository(IMusicSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Song> Get()
        {
            return this.All();
        }

        public Song GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Song entity)
        {
            this.Add(entity);
        }

        public void DeleteEntity(int id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void UpdateEntity(int id, Song newModel)
        {
            var entity = this.Find(id);

            entity.Name = newModel.Name;
            entity.Genre = newModel.Genre;
            entity.Year = newModel.Year;

            this.SaveChanges();
        }
    }
}

