using System.Data.Entity.Migrations;

namespace MusicSystem.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepositority<Т> : IRepository<Т> where Т : class
    {
        public readonly IMusicSystemDbContext context;
        private readonly IDbSet<Т> set;

        public GenericRepositority(IMusicSystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<Т>();
        }

        public IQueryable<Т> All()
        {
            return this.set;
        }

        public Т Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(Т entity)
        {
            this.ChangeState(entity, EntityState.Added);
            this.set.Add(entity);
        }

        public void Update(Т entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            this.set.AddOrUpdate(entity);
        }

        public void Delete(Т entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            this.set.Remove(entity);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.set.Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(Т entity, EntityState state)
        {
            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
