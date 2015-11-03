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
    [RoutePrefix("api/genre")]
    public class GenreController : ApiController
    {
        private readonly GenreRepository context;

        public GenreController()
        {
            this.context = new GenreRepository(new MusicSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var genres = this.context.All().ToList();

            return this.Ok(genres);
        }

        public IHttpActionResult Get(int id)
        {
            var entity = this.context.Find(id);

            if (entity == null)
            {
                return this.BadRequest("No such genre can be found.");
            }

            return this.Ok(entity);
        }

        public IHttpActionResult Post([FromBody]GenreRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = new Genre
            {
                Name = model.Name
            };

            this.context.AddEntity(entity);
            this.context.Save();

            return this.Created(this.Url.ToString(), entity);
        }

        public IHttpActionResult Put(int id, [FromBody]GenreRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = this.context.GetById(id);

            if (entity == null)
            {
                return this.BadRequest("Genre not found!");
            }

            this.context.Update(entity);
            this.context.Save();

            return this.Ok("[" + entity.Name + "] genre has been UPDATED!");
        }
    }
}