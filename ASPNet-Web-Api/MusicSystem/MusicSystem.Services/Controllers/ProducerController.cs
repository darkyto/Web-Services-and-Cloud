using MusicSystem.Models;
using MusicSystem.Services.Models;

namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using MusicSystem.Data;
    using MusicSystem.Data.Repositories;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/producer")]
    public class ProducerController : ApiController
    {
        private readonly ProducersRepository context;

        public ProducerController()
        {
            this.context = new ProducersRepository(new MusicSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var producers = this.context.All().ToList();

            return this.Ok(producers);
        }
        public IHttpActionResult Get(int id)
        {
            var entity = this.context.Find(id);

            if (entity == null)
            {
                return this.BadRequest("Producer not found!");
            }

            return this.Ok(entity);
        }

        public IHttpActionResult Post([FromBody]ProducerRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = new Producer
            {
                Name = model.Name
            };

            this.context.AddEntity(entity);
            this.context.Save();

            return this.Created(this.Url.ToString(), entity);
        }
    }
}