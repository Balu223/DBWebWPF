using BYLLQ0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Logic
{
    public interface IArtistLogic
    {
        void Create(Artist item);
        void Delete(int id);
        IEnumerable<Artist> GetArtistsByGenre(string genre);
        IEnumerable<Song> GetSongsByLabel(int labelId);
        IEnumerable<(Artist, int)> GetArtistWithMostSongsAtLabel(int labelId);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
    }
}