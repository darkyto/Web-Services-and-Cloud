namespace MusicSystem.Data.Repositories
{
    using System.Linq;
    using MusicSystem.Models;

    public class GenreRepository : GenericRepositority<Genre>
    {
        public GenreRepository(IMusicSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Genre> Get()
        {
            return this.All();
        }

        public Genre GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Genre entity)
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

        public void UpdateEntity(int id, Genre newModel)
        {
            var entity = this.Find(id);

            entity.Name = newModel.Name;

            this.SaveChanges();
        }
    }
}

