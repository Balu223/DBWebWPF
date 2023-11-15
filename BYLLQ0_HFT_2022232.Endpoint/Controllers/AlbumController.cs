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
    public class AlbumController : ControllerBase
    {

        IAlbumLogic logic;
        IHubContext<SignalRHub> hub;

        public AlbumController(IAlbumLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Album value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("AlbumCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Album value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AlbumUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
        }

        [HttpGet("AlbumsWithMostSongs")]
        public IEnumerable<NonCrud.AlbumInfo> GetAlbumsWithMostSongs()
        {
            return this.logic.GetAlbumsWithMostSongs();
        }


    }
}
