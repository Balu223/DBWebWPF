using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BYLLQ0_HFT_2022232.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MusicDbContext();

            var labelrepo = new LabelRepository(ctx);
            var artistrepo = new ArtistRepository(ctx);
            var albumrepo = new AlbumRepository(ctx);
            var songrepo = new SongRepository(ctx);

            var labellogic = new LabelLogic(labelrepo);
            var artistlogic = new ArtistLogic(artistrepo);
            var albumlogic = new AlbumLogic(albumrepo);
            var songlogic = new SongLogic(songrepo);


            var labelSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Label"))
                .Add("Create", () => Create("Label"))
                .Add("Delete", () => Delete("Label"))
                .Add("Update", () => Update("Label"))
                .Add("Exit", ConsoleMenu.Close);

            var artistSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("Exit", ConsoleMenu.Close);

            var albumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Album"))
                .Add("Create", () => Create("Album"))
                .Add("Delete", () => Delete("Album"))
                .Add("Update", () => Update("Album"))
                .Add("Exit", ConsoleMenu.Close);

            var songSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Labels", () => labelSubMenu.Show())
                .Add("Artists", () => artistSubMenu.Show())
                .Add("Albums", () => albumSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }


        private static void Create(string v)
        {
            throw new NotImplementedException();
        }

        private static void Delete(string v)
        {
            throw new NotImplementedException();
        }

        private static void Update(string v)
        {
            throw new NotImplementedException();
        }

        private static void List(string v)
        {
            throw new NotImplementedException();
        }
    }
}
