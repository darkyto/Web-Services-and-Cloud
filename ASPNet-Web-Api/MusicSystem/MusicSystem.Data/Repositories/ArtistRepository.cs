namespace MusicSystem.Data.Repositories
{
    using System.Linq;
    using MusicSystem.Models;

    public class ArtistRepository : GenericRepositority<Artist>
    {
        public ArtistRepository(IMusicSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Artist> Get()
        {
            return this.All();
        }

        public Artist GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Artist entity)
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

        public void UpdateEntity(int id, Artist newModel)
        {
            var entity = this.Find(id);

            entity.Country = newModel.Country;
            entity.Name = newModel.Name;

            this.SaveChanges();
        }

    }
}
