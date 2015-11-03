namespace MusicSystem.Data.Repositories
{
    using System.Linq;
    using MusicSystem.Models;

    public class CountryRepository : GenericRepositority<Country>
    {
        public CountryRepository(IMusicSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Country> Get()
        {
            return this.All();
        }

        public Country GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Country entity)
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

        public void UpdateEntity(int id, Country newModel)
        {
            var entity = this.Find(id);

            entity.Name = newModel.Name;

            this.SaveChanges();
        }

    }
}

