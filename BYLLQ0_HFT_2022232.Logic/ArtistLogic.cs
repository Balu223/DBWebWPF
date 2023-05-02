using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Logic
{
    public class ArtistLogic
    {
        IRepository<Artist> repo;

        public ArtistLogic(IRepository<Artist> repo)
        {
            this.repo = repo;
        }

        public void Create(Artist item)
        {
            if (item.RealName.Length < 3)
            {
                throw new ArgumentException("Name too short.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Artist Read(int id)
        {
            var artist = this.repo.Read(id);
            if (artist == null)
            {
                throw new ArgumentException("Artist doesnt exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Artist item)
        {
            this.repo.Update(item);
        }

        // 5 non crud method
        //Albumonként össz-zene

        //azok közül akik az interscopenál vannak kinek van több száma
        //labelenként összzene
        //össz zeneszám artistonként



        //Songs by Label
        public IEnumerable<Song> GetSongsByLabel(int labelId)
        {
            var songs = this.repo.ReadAll()
                    .Where(a => a.Label.LabelId == labelId)
                    .SelectMany(a => a.Albums)
                    .SelectMany(al => al.Songs)
                    .ToList();

                return songs;
            
        }

        public List<Artist> GetArtistsByGenre(string genre)
        {

                var artistsByGenre = this.repo.ReadAll()
                    .Where(a => a.Songs.Any(al => al.Genre == genre))
                    .ToList();

                return artistsByGenre; 
        }



    }
}
