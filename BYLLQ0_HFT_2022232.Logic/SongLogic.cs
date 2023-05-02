using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Logic
{
    public class SongLogic
    {
        IRepository<Song> repo;

        public SongLogic(IRepository<Song> repo)
        {
            this.repo = repo;
        }

        public void Create(Song item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Song Read(int id)
        {
            var song = this.repo.Read(id);
            if (song == null)
            {
                throw new ArgumentException("Song doesnt exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Song> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Song item)
        {
            this.repo.Update(item);
        }

        // RnB Songs Count from Artist
        //public int GetArtistRnBSongCount(int ArtistId)
        //{
        //    var rnbSongCount = this.repo.ReadAll()
        //            .Where(s => s.Artist.ArtistId == ArtistId && s.Genre == "RnB")
        //            .Count();

        //    return rnbSongCount;

        //}
        // Artist with the most songs at the label
        public string GetArtistWithMostSongsAtLabel(int labelId)
        {
            var artistSongs = this.repo.ReadAll()
                .Where(s => s.Artist.LabelId == labelId)
                .GroupBy(m => m.Album.Artist)
                .Select(g => new
                {
                    Artist = g.Key,
                    SongCount = g.Count()
                });
            var mostSongs = artistSongs
                .OrderByDescending(a => a.SongCount)
                .FirstOrDefault().Artist.StageName;

            return mostSongs;

        }

        public List<Artist> GetArtistsWithMostSongs(int n)
        {
            var songs = from song in this.repo.ReadAll()
                                  group song by song.Artist into g
                                  select new
                                  {
                                      Artist = g.Key,
                                      SongCount = g.Count()
                                  };

            var sortedSongs = songs.OrderByDescending(x => x.SongCount).Take(n);

            List<Artist> artists = new List<Artist>();
            foreach (var item in sortedSongs)
            {
                artists.Add(item.Artist);
            }

            return artists;
        }
    }
}
