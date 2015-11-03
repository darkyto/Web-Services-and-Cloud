namespace StudentSystem.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Models;

    public class HomeworkRepository : GenericRepository<Homework>
    {
        public HomeworkRepository(IStudentSystemDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Homework> All()
        {
            return this.All();
        }

        public IEnumerable<Homework> GetHomeworks()
        {
            return this.context.Homeworks.ToList();
        }

        public Homework GetHomeworkById(int id)
        {
            return this.context.Homeworks.Find(id);
        }

        public void InsertHomework(Homework homework)
        {
            this.context.Homeworks.Add(homework);
        }

        public void DeleteCourse(Homework homework)
        {
            this.context.Homeworks.Remove(homework);
        }

        public void UpdateStudent(Homework homework)
        {
            this.context.Entry(homework).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
