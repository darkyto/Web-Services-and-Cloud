using System;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using StudentSystem.Models;
    using StudentSystem.Data;
    using StudentSystem.Data.Repositories;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private CourseRepository repository;

        public CourseController()
        {
            this.repository = new CourseRepository(new StudentSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var courses = this.repository.GetCourses().ToList();
            return this.Ok(courses);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            this.repository.Add(newCourse);
            this.repository.Save();

            return this.Ok($"course [{course.Name}] was added and has id : {newCourse.Id}");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var course = this.repository.GetCourseById(id);

            if (course != null)
            {
                this.repository.DeleteCourse(course);
                this.repository.Save();
            }

            return this.Ok($"{course.Name} was deleted");
        }

        [Route("all/{page}")]
        public IHttpActionResult Get(int page, int pageSize = 4)
        {
            var result = this.repository.GetCourses().ToList();

            return this.Ok(result);
        }
    }
}