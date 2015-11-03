namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using MusicSystem.Data;
    using MusicSystem.Data.Repositories;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/artist")]
    public class ArtistController : ApiController
    {
        private readonly ArtistRepository context;

        public ArtistController()
        {
            this.context = new ArtistRepository(new MusicSystemDbContext());
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
                return this.BadRequest("No such artist can be found.");
            }

            return this.Ok(entity);
        }
    }
}