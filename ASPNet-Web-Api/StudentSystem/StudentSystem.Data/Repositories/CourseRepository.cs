namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Models;

    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(IStudentSystemDbContext context)
            : base(context)
        {

        }

        public IQueryable<Course> All()
        {
            return this.All();
        }

        public IEnumerable<Course> GetCourses()
        {
            return this.context.Courses.ToList();
        }

        public Course GetCourseById(Guid id)
        {
            return this.context.Courses.Find(id);
        }

        public void InsertCourse(Course course)
        {
            this.context.Courses.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            this.context.Courses.Remove(course);
        }

        public void UpdateStudent(Course student)
        {
            this.context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
