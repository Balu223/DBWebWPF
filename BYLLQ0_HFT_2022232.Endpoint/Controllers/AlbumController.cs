using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace BYLLQ0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        IAlbumLogic logic;

        public AlbumController(IAlbumLogic logic)
        {
            this.logic = logic;
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
        }


        [HttpPut]
        public void Update([FromBody] Album value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("AlbumsWithMostSongs")]
        public IEnumerable<NonCrud.AlbumInfo> GetAlbumsWithMostSongs()
        {
            return this.logic.GetAlbumsWithMostSongs();
        }


    }
}
