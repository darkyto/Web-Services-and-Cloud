using System.Linq;

namespace StudentSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    using StudentSystem.Data;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private StudentsRepository repository;

        public StudentController()
        {
            this.repository = new StudentsRepository(new StudentSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var students = this.repository.All().ToList();

            return this.Ok(students);     
        }

        public IHttpActionResult Get(int id)
        {
            var student = this.repository.GetStudentByID(id);

            return this.Ok(student);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level
            };

            this.repository.InsertStudent(newStudent);
            this.repository.Save();

            return this.Ok(student);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            this.repository.DeleteStudent(id);
            this.repository.Save();

            return this.Ok($"Student with id: {id} was deleted");
        }
    }
}