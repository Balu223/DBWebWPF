using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NCController : ControllerBase
    {
        ILabelLogic labellogic;
        IArtistLogic artistlogic;
        IAlbumLogic albumlogic;

        public NCController(ILabelLogic labellogic, IArtistLogic artistlogic, IAlbumLogic albumlogic)
        {
            this.labellogic = labellogic;
            this.artistlogic = artistlogic;
            this.albumlogic = albumlogic;
        }
        [HttpGet]
        public IEnumerable<NonCrud.LabelInfo> GetLabelsWithMostAlbums()
        {
            return this.labellogic.GetLabelsWithMostAlbums().ToArray();
        }
        [HttpGet("{labelId}")]
        public IEnumerable<Song> GetSongsByLabel(int labelId)
        {
            return this.artistlogic.GetSongsByLabel(labelId);
        }
        [HttpGet("{genre}")]
        public IEnumerable<Artist> GetArtistsByGenre(string genre)
        {
            return this.artistlogic.GetArtistsByGenre(genre);
        }
        [HttpGet("{labelId}")]
        public IEnumerable<NonCrud.ArtistInfo> GetArtistWithMostSongsAtLabel(int labelId)
        {
            return this.artistlogic.GetArtistWithMostSongsAtLabel(labelId);
        }
        [HttpGet]
        public IEnumerable<NonCrud.AlbumInfo> GetAlbumsWithMostSongs()
        {
            return this.albumlogic.GetAlbumsWithMostSongs();
        }
    }
}
