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
    public class ArtistController : ControllerBase
    {

        IArtistLogic logic;

        public ArtistController(IArtistLogic logic)
        {
            this.logic = logic;
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
        }


        [HttpPut]
        public void Update([FromBody] Artist value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
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
