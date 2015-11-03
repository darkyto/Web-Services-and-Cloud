namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using StudentSystem.Data;
    using StudentSystem.Data.Repositories;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/homework")]
    public class HomeworkController : ApiController
    {
        private HomeworkRepository repository;

        public HomeworkController()
        {
            this.repository = new HomeworkRepository(new StudentSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var homeworks = this.repository.GetHomeworks().ToList();

            return this.Ok(homeworks);
        }
    }
}