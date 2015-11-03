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
    [RoutePrefix("api/song")]
    public class SongController : ApiController
    {
        private readonly SongRepository context;

        public SongController()
        {
            this.context = new SongRepository(new MusicSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var songs = this.context.All().ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            var entity = this.context.Find(id);

            if (entity == null)
            {
                return this.BadRequest("No such song can be found.");
            }

            return this.Ok(entity);
        }

        public IHttpActionResult Post([FromBody]SongRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = new Song
            {
                Name = model.Name,
                Year = model.Year,
                GenreId = model.GenreId
            };

            this.context.AddEntity(entity);
            this.context.Save();

            return this.Created(this.Url.ToString(), entity);
        }
    }
}