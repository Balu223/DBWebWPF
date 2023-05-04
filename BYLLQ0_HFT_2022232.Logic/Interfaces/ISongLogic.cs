using BYLLQ0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Logic
{
    public interface ISongLogic
    {
        void Create(Song item);
        void Delete(int id);

        string GetArtistWithMostSongsAtLabel(int labelId);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
    }
}