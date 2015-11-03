namespace StudentSystem.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Models;

    public class StudentsRepository : GenericRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context)
            : base(context)
        {

        }

        public IQueryable<Student> AllAsistants()
        {
            return this.All().Where(st => st.Trainees.Count() > 0);
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public Student GetStudentByID(int id)
        {
            return this.context.Students.Find(id);
        }

        public void InsertStudent(Student student)
        {
            this.context.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = context.Students.Find(studentID);
            this.context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            this.context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
