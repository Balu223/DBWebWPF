using BYLLQ0_HFT_2022232.Endpoint.Services;
using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BYLLQ0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        IArtistLogic logic;
        IHubContext<SignalRHub> hub;

        public ArtistController(IArtistLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Artist> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Artist Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Artist value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ArtistCreated",value);
        }


        [HttpPut]
        public void Update([FromBody] Artist value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ArtistUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ArtistDeleted", actorToDelete);
        }

        [HttpGet("GetArtistsByGenre")]
        public IEnumerable<Artist> GetArtistsByGenre(string genre)
        {
            return this.logic.GetArtistsByGenre(genre);
        }
        [HttpGet("GetSongsBylabel")]
        public IEnumerable<Song> GetSongsByLabel(int labelId)
        {
            return this.logic.GetSongsByLabel(labelId);
        }
        [HttpGet("GetArtistWithMostSongsAtLabel")]
        public IEnumerable<NonCrud.ArtistInfo> GetArtistWithMostSongsAtLabel(int labelId)
        {
            return this.logic.GetArtistWithMostSongsAtLabel(labelId);
        }


    }
}
