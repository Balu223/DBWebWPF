using BYLLQ0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album item);
        void Delete(int id);
        IEnumerable<NonCrud.AlbumInfo> GetAlbumsWithMostSongs();
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
    }
}