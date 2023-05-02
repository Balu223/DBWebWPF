using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Logic
{
    public class AlbumLogic
    {

        IRepository<Album> repo;

        public AlbumLogic(IRepository<Album> repo)
        {
            this.repo = repo;
        }

        public void Create(Album item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Album Read(int id)
        {
            var album = this.repo.Read(id);
            if (album == null)
            {
                throw new ArgumentException("Album doesnt exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Album> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Album item)
        {
            this.repo.Update(item);
        }

        public List<(Album, int)> GetAlbumsWithMostSongs()
        {

                var albums = this.repo.ReadAll()
                    .Select(a => new
                    {
                        Album = a,
                        SongCount = a.Songs.Count()
                    })
                    .OrderByDescending(a => a.SongCount)
                    .ToList();

                return albums.Select(a => (a.Album, a.SongCount)).ToList();
            
        }

    }
}
