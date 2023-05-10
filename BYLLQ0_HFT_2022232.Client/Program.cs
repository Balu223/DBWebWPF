using BYLLQ0_HFT_2022232.Models;
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
        static RestService rest;

        private static void Create(string v)
        {
            if (v == "Label")
            {
                var item = new Label();
                Console.Write("Label name: ");
                item.LabelName = Console.ReadLine();
                Console.Write("Label address: ");
                item.Address = Console.ReadLine();
                rest.Post(item, "label");
            }
            else if (v == "Artist")
            {
                var item = new Artist();
                Console.Write("Real name: ");
                item.RealName = Console.ReadLine();
                Console.Write("Stage name: ");
                item.StageName = Console.ReadLine();
                Console.Write("Date of birth (yyyy.mm.dd): ");
                item.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.Write("Label id: ");
                item.LabelId = int.Parse(Console.ReadLine());
                rest.Post(item, "artist");
            }
            else if (v == "Album")
            {
                var item = new Album();
                Console.Write("Album name: ");
                item.AlbumName = Console.ReadLine();
                Console.Write("Release date (yyyy.mm.dd): ");
                item.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Artist id: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                rest.Post(item, "album");
            }
            else if (v == "Song")
            {
                var item = new Song();
                Console.Write("Song name: ");
                item.SongName = Console.ReadLine();
                Console.Write("Genre: ");
                item.Genre = Console.ReadLine();
                Console.Write("Album id: ");
                item.AlbumId = int.Parse(Console.ReadLine());
                Console.Write("Artist id: ");
                item.ArtistId = int.Parse(Console.ReadLine());
                rest.Post(item, "song");
            }
        }

        private static void Delete(string v)
        {
            if (v == "Label")
            {
                Console.Write("Label id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "label");
            }
            else if (v == "Artist")
            {
                Console.Write("Artist id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "artist");
            }
            else if (v == "Album")
            {
                Console.Write("Album id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "album"); ;
            }
            else if (v == "Song")
            {
                Console.Write("Song id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "song"); ;
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
                rest.Put(item, "label");

            }
            else if (v == "Artist")
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
                rest.Put(item, "artist");
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
                rest.Put(item, "album");
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
                rest.Put(item, "song");
            }
        }

        private static void List(string v)
        {
            if (v == "Label")
            {
                var items = rest.Get<Label>("label");
                foreach (var item in items)
                {
                    Console.WriteLine(item.LabelId + "\t" + item.LabelName);
                }
            }
            else if (v == "Artist")
            {
                var items = rest.Get<Artist>("artist");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ArtistId + "\t" + item.RealName + " - " + item.StageName);
                }
            }
            else if (v == "Album")
            {
                var items = rest.Get<Album>("album");
                foreach (var item in items)
                {
                    Console.WriteLine(item.AlbumId + "\t" + item.AlbumName + " - " + item.ReleaseDate);
                }
            }
            else if (v == "Song")
            {
                var items = rest.Get<Song>("song");
                foreach (var item in items)
                {
                    Console.WriteLine(item.SongId + "\t" + item.SongName + "\t" + item.Album.AlbumName + " - " + item.Genre);
                }
            }
            Console.ReadLine();
        }

        private static void GetLabelsWithMostAlbums(string endpoint)
        {
            var items = rest.Get<NonCrud.LabelInfo>($"NC/{endpoint}");
            foreach (var item in items)
            {
                Console.WriteLine(item.Label.LabelName + ", " + item.AlbumCount);
            }
            Console.ReadLine();
        }

        private static void GetArtistsByGenre(string endpoint)
        {
            Console.Write("Genre name: ");
            string name = Console.ReadLine();
            var artists = rest.Get<Artist>($"NC/{endpoint}/{name}");
            Console.WriteLine("Artists that make " + name + " music:");
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.StageName);
            }
            Console.ReadLine();
        }

        private static void GetSongsByLabel(string endpoint)
        {
            Console.WriteLine("Label id: ");
            int ans = int.Parse(Console.ReadLine());
            var items = rest.Get<Song>($"NC/{endpoint}/{ans}");
            Console.WriteLine("Songs by id " + ans + " label: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.SongName);
            }
            Console.ReadLine();
        }

        private static void GetAlbumsWithMostSongs(string endpoint)
        {
            var items = rest.Get<NonCrud.AlbumInfo>($"NC/{endpoint}");
            foreach (var item in items)
            {
                Console.WriteLine(item.Album.AlbumName + ", " + item.SongCount);
            }
            Console.ReadLine();
        }

        private static void GetArtistWithMostSongsAtLabel(string endpoint)
        {
            Console.WriteLine("Label id: ");
            int id = int.Parse(Console.ReadLine());
            var items = rest.Get<NonCrud.ArtistInfo>($"NC/{endpoint}/{id}");
            foreach (var item in items)
            {
                Console.WriteLine(item.Artist.StageName + ", " + item.SongCount);
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:5124/", "swagger");
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

            var nonCrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetArtistWithMostSongsAtLabel", () => GetArtistWithMostSongsAtLabel("GetArtistWithMostSongsAtLabel"))
                .Add("GetAlbumsWithMostSongs", () => GetAlbumsWithMostSongs("GetAlbumsWithMostSongs"))
                .Add("GetArtistsByGenre", () => GetArtistsByGenre("GetArtistsByGenre"))
                .Add("GetSongsByLabel", () => GetSongsByLabel("GetSongsByLabel"))
                .Add("GetLabelsWithMostAlbums", () => GetLabelsWithMostAlbums("GetLabelsWithMostAlbums"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Labels", () => labelSubMenu.Show())
                .Add("Artists", () => artistSubMenu.Show())
                .Add("Albums", () => albumSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Non-CRUD methods", () => nonCrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();      
        }   
    }
}
