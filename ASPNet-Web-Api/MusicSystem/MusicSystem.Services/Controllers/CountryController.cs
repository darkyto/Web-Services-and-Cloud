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
    [RoutePrefix("api/contry")]
    public class CountryController : ApiController
    {
        private readonly CountryRepository context;

        public CountryController()
        {
            this.context = new CountryRepository(new MusicSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var entities = this.context.All().ToList();

            return this.Ok(entities);
        }

        public IHttpActionResult Get(int id)
        {
            var entity = this.context.Find(id);

            if (entity == null)
            {
                return this.BadRequest("No such contry can be found.");
            }

            return this.Ok(entity);
        }

        public IHttpActionResult Post([FromBody]CountryRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = new Country()
            {
                Name = model.Name
            };

            this.context.AddEntity(entity);
            this.context.Save();

            return this.Created(this.Url.ToString(), entity);
        }
    }
}