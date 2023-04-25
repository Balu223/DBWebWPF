using BYLLQ0_HFT_2022232.Models;
using System;

namespace BYLLQ0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MusicDbContext ctx = new MusicDbContext();

            foreach (var artist in ctx.Artists) {
                Console.WriteLine(artist.RealName);
            }
        }
    }
}
