using BYLLQ0_HFT_2022232.Endpoint.Services;
using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BYLLQ0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        ISongLogic logic;
        IHubContext<SignalRHub> hub;

        public SongController(ISongLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("SongCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Song value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("SongUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("SongDeleted", songToDelete);

        }



    }
}
