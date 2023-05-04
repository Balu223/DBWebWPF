using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace BYLLQ0_HFT_2022232.Client
{
    internal class Program
    {

        static LabelLogic labellogic;
        static ArtistLogic artistlogic;
        static AlbumLogic albumlogic;
        static SongLogic songlogic;
        static void Main(string[] args)
        {
            var ctx = new MusicDbContext();

            var labelrepo = new LabelRepository(ctx);
            var artistrepo = new ArtistRepository(ctx);
            var albumrepo = new AlbumRepository(ctx);
            var songrepo = new SongRepository(ctx);

            labellogic = new LabelLogic(labelrepo);
            artistlogic = new ArtistLogic(artistrepo);
            albumlogic = new AlbumLogic(albumrepo);
            songlogic = new SongLogic(songrepo);


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
            if (v == "Label")
            {
                var item = new Label();
                Console.Write("Label id: ");
                item.LabelId = int.Parse(Console.ReadLine());
                Console.Write("Label name: ");
                item.LabelName = Console.ReadLine();
                Console.Write("Label address: ");
                item.Address = Console.ReadLine();
                labellogic.Create(item);
            }
            else if (v == "Artist")
            {
                var item = new Artist();
                Console.Write("Artist id: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                Console.Write("Real name: ");
                item.RealName = Console.ReadLine();
                Console.Write("Stage name: ");
                item.StageName = Console.ReadLine();
                Console.Write("Date of birth (yyyy.mm.dd): ");
                item.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.Write("Label id: ");
                item.LabelId = int.Parse(Console.ReadLine());
                artistlogic.Create(item);
            }
            else if (v == "Album")
            {
                var item = new Album();
                Console.WriteLine("Album id: ");
                item.AlbumId = int.Parse(Console.ReadLine());
                Console.Write("Album name: ");
                item.AlbumName = Console.ReadLine();
                Console.Write("Release date (yyyy.mm.dd): ");
                item.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Artist id: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                albumlogic.Create(item);
            }
            else if (v == "Song")
            {
                var item = new Song();
                Console.Write("Song id: ");
                item.SongId = int.Parse(Console.ReadLine());
                Console.Write("Song name: ");
                item.SongName = Console.ReadLine();
                Console.Write("Genre: ");
                item.Genre = Console.ReadLine();
                Console.Write("Album id: ");
                item.AlbumId = int.Parse(Console.ReadLine());
                Console.Write("Artist id: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                songlogic.Create(item);
            }
            Console.ReadLine();
        }

        private static void Delete(string v)
        {
            if (v == "Label")
            {
                Console.Write("Label id to delete: ");
                int id = int.Parse(Console.ReadLine());
                labellogic.Delete(id);
            }
            else if (v == "Artist")
            {
                Console.Write("Artist id to delete: ");
                int id = int.Parse(Console.ReadLine());
                artistlogic.Delete(id);
            }
            else if (v == "Album")
            {
                Console.Write("Album id to delete: ");
                int id = int.Parse(Console.ReadLine());
                albumlogic.Delete(id);
            }
            else if (v == "Song")
            {
                Console.Write("Song id to delete: ");
                int id = int.Parse(Console.ReadLine());
                songlogic.Delete(id);
            }
            Console.ReadLine();
        }

        private static void Update(string v)
        {
            if (v == "Label")
            {
                Console.Write("Label to update(id): ");
                int id = int.Parse(Console.ReadLine());
                var item = new Label();
                item.LabelId = id;
                Console.Write("Label name to update: ");
                item.LabelName = Console.ReadLine();
                Console.Write("Label address to update: ");
                item.Address = Console.ReadLine();
                labellogic.Update(item);

            }
            else if (v == "Artst")
            {
                Console.Write("Artist to update (id): ");
                int id = int.Parse(Console.ReadLine());
                var item = new Artist();
                item.ArtistId = id;
                Console.Write("Artist real name to update: ");
                item.RealName = Console.ReadLine();
                Console.Write("Artist Stagename to update: ");
                item.StageName = Console.ReadLine();
                Console.Write("Artist birthdate to update (yyyy.mm.dd): ");
                item.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.Write("Artist label id to update: ");
                item.LabelId = int.Parse(Console.ReadLine());
                artistlogic.Update(item);
            }
            else if (v == "Album")
            {
                Console.Write("Album to update (id): ");
                int id = int.Parse(Console.ReadLine());
                var item = new Album();
                item.AlbumId = id;
                Console.Write("Album name to update : ");
                item.AlbumName = Console.ReadLine();
                Console.Write("Release date to update (yyyy.mm.dd): ");
                item.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Artist id to update: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                albumlogic.Update(item);
            }
            else if (v == "Song")
            {
                Console.Write("Song to update (id): ");
                int id = int.Parse(Console.ReadLine());
                var item = new Song();
                item.SongId = id;
                Console.Write("Song name to update: ");
                item.SongName = Console.ReadLine();
                Console.Write("Genre to update: ");
                item.Genre = Console.ReadLine();
                Console.Write("Album id to update: ");
                item.AlbumId = int.Parse(Console.ReadLine());
                Console.Write("Artist id to update: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                songlogic.Update(item);
            }
            Console.ReadLine();
        }

        private static void List(string v)
        {
            if (v == "Label")
            {
                var items = labellogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.LabelId + "\t" + item.LabelName);
                }
            }
            else if (v == "Artist")
            {
                var items = artistlogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.ArtistId + "\t" + item.RealName + " - " + item.StageName);
                }
            }
            else if (v == "Album")
            {
                var items = albumlogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.AlbumId + "\t" + item.AlbumName + " - " + item.ReleaseDate);
                }
            }
            else if (v == "Song")
            {
                var items = songlogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.SongId + "\t" + item.SongName + "\t" + item.Album.AlbumName + " - " + item.Genre);
                }
            }
            Console.ReadLine();
        }
    }
}
