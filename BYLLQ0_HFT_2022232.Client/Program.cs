using BYLLQ0_HFT_2022232.Repository;
using System;

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
        }
    }
}
