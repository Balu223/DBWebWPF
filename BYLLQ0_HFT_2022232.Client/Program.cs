using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using System;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MusicDbContext ctx = new MusicDbContext();

            foreach (var album in ctx.Albums) {
                var albumn = album;
                foreach (var song in ctx.Songs)
                {
                    if (albumn.AlbumId == song.AlbumId)
                    {
                        Console.WriteLine(albumn.AlbumName + " " + song.SongName);
                    }
                }
            }
            //IRepository<Artist> repo = new ArtistRepository(new MusicDbContext());
            //Artist a = new Artist()
            //{
            //    RealName = "Fasz",
            //    StageName = "Kalap",
            //    DateOfBirth = DateTime.Now,
            //    LabelId = 1,
            //};
            //repo.Create(a);
            //var another = repo.Read(2);
            //another.RealName = "Kutya";
            //repo.Update(another);
            //var items = repo.ReadAll().ToArray();
            //;

        }
    }
}
