using System.Collections;
using System.Collections.Generic;
using WebGrease.Css.Extensions;

namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using MusicSystem.Data;
    using MusicSystem.Data.Repositories;
    using MusicSystem.Models;
    using MusicSystem.Services.Models;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {
        private static readonly MusicSystemData allData = new MusicSystemData();

        private readonly AlbumRepository context;
      
        public AlbumController()
        {
            this.context = new AlbumRepository(new MusicSystemDbContext());
        }

        public IHttpActionResult Get()
        {
            var entities = this.context.All().ToList();

            return this.Ok(entities);
        }

        public IHttpActionResult Get(int id)
        {
            var entity = this.context.GetById(id);

            if (entity == null)
            {
                return this.BadRequest("Album not found!");
            }

            return this.Ok(entity);
        }

        public IHttpActionResult Post([FromBody]AlbumRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var songIds = model.SongIds.ToList();
            var artistsIds = model.ArtistIds.ToList();

            var album = new Album
            {
                Title = model.Title,
                ProducerId = model.ProducerId
            };

            this.context.AddEntity(album);
            this.context.Save();

            return this.Created(this.Url.ToString(), album);
        }

        public IHttpActionResult Put(int id, [FromBody]AlbumRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = this.context.GetById(id);

            if (album == null)
            {
                return this.BadRequest("Album not found!");
            }

            if (allData.Producers.Find(model.ProducerId) == null)
            {
                return this.BadRequest("No such producer can be found.");
            }

            if (this.AddArtistsToAlbum(model.ArtistIds, album) == null || this.AddSongsToAlbum(model.SongIds, album) == null)
            {
                return this.BadRequest("No such song/artist can be found.");
            }

            this.context.Update(album);
            this.context.Save();

            return this.Ok("[" + album.Title + "] album has been UPDATED!");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var deleted = this.context.GetById(id);
            this.context.DeleteEntity(id);
            this.context.Save();
            return this.Ok("[" + deleted.Title + "] album has been DELETED!");
        }

        private Album AddSongsToAlbum(int[] songIds, Album album)
        {
            album.Songs.Clear();

            foreach (var songId in songIds)
            {
                var songToAdd = allData.Songs.Find(songId);

                if (songToAdd == null)
                {
                    return null;
                }

                album.Songs.Add(songToAdd);
            }

            return album;
        }

        private Album AddArtistsToAlbum(int[] artistIds, Album album)
        {
            album.Artists.Clear();

            foreach (var artistId in artistIds)
            {
                var artistToAdd = allData.Artists.Find(artistId);

                if (artistToAdd == null)
                {
                    return null;
                }

                album.Artists.Add(artistToAdd);
            }

            return album;
        }
    }
}