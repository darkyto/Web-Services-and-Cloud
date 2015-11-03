namespace MusicSystem.Data.Repositories
{
    using System.Linq;
    using MusicSystem.Models;

    public class ProducersRepository : GenericRepositority<Producer>
    {
        public ProducersRepository(IMusicSystemDbContext context)
            : base(context)
        {
        }

        public IQueryable<Producer> Get()
        {
            return this.All();
        }

        public Producer GetById(int id)
        {
            var entity = this.Find(id);

            return entity;
        }

        public void AddEntity(Producer entity)
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

        public void UpdateEntity(int id, Producer newModel)
        {
            var entity = this.Find(id);

            entity.Name = newModel.Name;

            this.SaveChanges();
        }
    }
}

