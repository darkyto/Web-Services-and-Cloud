namespace MusicSystem.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;
    using MusicSystem.Models;

    public class AlbumRepository : GenericRepositority<Album>
    {
        public AlbumRepository(IMusicSystemDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Album> Get()
        {
            return this.All();
        }

        public Album GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Album entity)
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

        public void UpdateEntity(int id, Album newModel)
        {
            var entity = this.Find(id);

            entity.Title = newModel.Title;
            entity.Artists = newModel.Artists;
            entity.Producer = newModel.Producer;
            entity.Songs = newModel.Songs;

            this.SaveChanges();
        }
    }
}
