using BYLLQ0_HFT_2022232.Logic;
using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Test
{
    [TestFixture]
    public class MusicLogicTester
    {
        LabelLogic labellogic;
        Mock<IRepository<Label>> mockLabelRepo;
        ArtistLogic artistlogic;
        Mock<IRepository<Artist>> mockArtistRepo;
        AlbumLogic albumlogic;
        Mock<IRepository<Album>> mockAlbumRepo;
        SongLogic songlogic;
        Mock<IRepository<Song>> mockSongRepo;

        [SetUp]
        public void Init()
        {
            List<Label> mockRepoDataLabel = new List<Label>()
            {
                
                new Label("1#Interscope Records#Santa Monica, CA"),
                new Label("2#Republic Records#New York, NY"),
                new Label("3#Epic Records#New York, NY"),
                new Label("4#Def Jam Recordings#New York, NY"),
            };
            List<Artist> mockRepoDataArtist = new List<Artist>()
            {
                
                new Artist("1#Aubrey Drake Graham#Drake#1986-10-24#1"),
                new Artist("2#Kendrick Lamar Duckworth#Kendrick Lamar#1987-06-17#1"),
                new Artist("3#Sean Michael Leonard Anderson#Big Sean#1988-03-25#2"),
                new Artist("4#Shawn Corey Carter#Jay-Z#1969-12-04#4"),
            };
            List<Album> mockRepoDataAlbum = new List<Album>()
            {
               
                new Album("1#Scorpion#2018-06-29#1"),
                new Album("2#DAMN.#2017-04-14#2"),
                new Album("3#Detroit 2#2020-09-04#3"),
                new Album("4#If You're Reading This Its Too Late#2015-02-13#1"),
                new Album("5#4:44#2017-06-30#4"),
            };
            List<Song> mockRepoDataSong = new List<Song>()
            {

                new Song("1#Nonstop#Hip-Hop#1#1"),
                new Song("2#Can't Take A Joke#Hip-Hop#1#1"),
                new Song("3#God's Plan#Hip-Hop#1#1"),
                new Song("4#Mob Ties#Hip-Hop#1#1"),
                new Song("5#Emotionless#Hip-Hop#1#1"),
                new Song("6#Nice For What#Hip-Hop#1#1"),
                new Song("7#Jaded#RnB#1#1"),
                new Song("8#Summer Games#Rnb#1#1"),
                new Song("9#Energy#Hip-Hop#4#1"),
                new Song("10#Legend#Hip-Hop#4#1"),
                new Song("11#Know Yourself#Hip-Hop#4#1"),
                new Song("12#10 Bands#Hip-Hop#4#1"),
                new Song("13#Madonna#Hip-Hop#4#1"),
                new Song("14#6 God#Hip-Hop#4#1"),
                new Song("15#Jungle#RnB#4#1"),
                new Song("16#HUMBLE.#Hip-Hop#2#2"),
                new Song("17#DNA.#Hip-Hop#2#2"),
                new Song("18#LOVE.FEAT.ZACARI.#Hip-Hop#2#2"),
                new Song("19#4:44#Hip-Hop#5#4"),
                new Song("20#Bam#Hip-Hop#5#4"),
                new Song("21#Deep Reverence#Hip-Hop#3#3"),
                new Song("22#Wolves#Hip-Hop#3#3"),
                new Song("23#ZTFO#Hip-Hop#3#3"),
                new Song("24#Lithuania#Hip-Hop#3#3"),
                new Song("25#The Story of O.J.#Hip-Hop#5#4"),
            };
            //label virtual props
            foreach (var label in mockRepoDataLabel)
            {
                foreach (var artist in mockRepoDataArtist)
                {
                    if (label.LabelId == artist.LabelId)
                    {
                        label.Artists.Add(artist);
                    }
                    
                }
            }
            //artist virtual props
            foreach (var artist in mockRepoDataArtist)
            {
                foreach(var album in mockRepoDataAlbum)
                {
                    if (album.ArtistId == artist.ArtistId)
                    {
                        artist.Albums.Add(album);
                    }
                }
            }
            foreach (var artist in mockRepoDataArtist)
            {
                foreach (var song in mockRepoDataSong)
                {
                    if (song.ArtistId == artist.ArtistId)
                    {
                        artist.Songs.Add(song);
                    }
                }
            }
            foreach (var artist in mockRepoDataArtist)
            {
                foreach (var label in mockRepoDataLabel)
                {
                    if (label.LabelId == artist.LabelId)
                    {
                        artist.Label = label;
                    }
                }
            }
            //album virtual props
            foreach ( var album in mockRepoDataAlbum)
            {
                foreach (var song in mockRepoDataSong)
                {
                    if (album.ArtistId == song.ArtistId && album.AlbumId == song.AlbumId)
                    {
                        album.Songs.Add(song);
                    }
                }
            }
            foreach( var album in mockRepoDataAlbum)
            {
                foreach ( var artist in mockRepoDataArtist)
                {
                    if (album.ArtistId == artist.ArtistId)
                    {
                        album.Artist = artist;
                    }
                }
            }
            //song virtual props
            foreach (var song in mockRepoDataSong)
            {
                foreach (var artist in mockRepoDataArtist)
                {
                    if (song.ArtistId == artist.ArtistId)
                    {
                        song.Artist = artist;
                    }
                }
            }
            foreach (var song in mockRepoDataSong)
            {
                foreach (var album in mockRepoDataAlbum)
                {
                    if (song.AlbumId == album.AlbumId)
                    {
                        song.Album = album;
                    }
                }
            }
            mockLabelRepo = new Mock<IRepository<Label>>();
            mockArtistRepo = new Mock<IRepository<Artist>>();
            mockAlbumRepo = new Mock<IRepository<Album>>();
            mockSongRepo = new Mock<IRepository<Song>>();
            mockLabelRepo.Setup(l => l.ReadAll()).Returns(mockRepoDataLabel.AsQueryable());
            mockArtistRepo.Setup(l => l.ReadAll()).Returns(mockRepoDataArtist.AsQueryable());
            mockAlbumRepo.Setup(l => l.ReadAll()).Returns(mockRepoDataAlbum.AsQueryable());
            mockSongRepo.Setup(l => l.ReadAll()).Returns(mockRepoDataSong.AsQueryable());
            labellogic = new LabelLogic(mockLabelRepo.Object);
            artistlogic = new ArtistLogic(mockArtistRepo.Object);
            albumlogic = new AlbumLogic(mockAlbumRepo.Object);
            songlogic = new SongLogic(mockSongRepo.Object);
            
        }

        [Test]
        public void GetLabelsWithMostAlbumsTest()
        {
            var actual = labellogic.GetLabelsWithMostAlbums();
            ;
            var expected = new List<NonCrud.LabelInfo>()
            {
                (new NonCrud.LabelInfo
                {
                    Label = new Label("1#Interscope Records#Santa Monica, CA"),
                    AlbumCount = 3
                }),
                (new NonCrud.LabelInfo
                {
                    Label = new Label("2#Republic Records#New York, NY"),
                    AlbumCount = 1
                }),
                (new NonCrud.LabelInfo
                {
                    Label = new Label("4#Def Jam Recordings#New York, NY"),
                    AlbumCount = 1
                }),
                (new NonCrud.LabelInfo
                {
                    Label = new Label("3#Epic Records#New York, NY"),
                    AlbumCount = 0
                })
            };

            Assert.AreEqual(expected, actual);
            ;
        }

        [Test]
        public void GetArtistWithMostSongsAtLabelTest()
        {
            var actual = artistlogic.GetArtistWithMostSongsAtLabel(1);
            var expected = new List<NonCrud.ArtistInfo>()
            {
                (new NonCrud.ArtistInfo{
                    Artist = new Artist("1#Aubrey Drake Graham#Drake#1986-10-24#1"),
                    SongCount = 15 }),
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAlbumsWithMostSongsTest()
        {
            var actual = albumlogic.GetAlbumsWithMostSongs();
            var expected = new List<NonCrud.AlbumInfo>()
            {
                (new NonCrud.AlbumInfo{
                    Album = new Album("1#Scorpion#2018-06-29#1"),
                    SongCount = 8}),
                (new NonCrud.AlbumInfo{
                    Album = new Album("4#If You're Reading This Its Too Late#2015-02-13#1"),
                    SongCount = 7}),
                (new NonCrud.AlbumInfo{
                    Album = new Album("3#Detroit 2#2020-09-04#3"),
                    SongCount = 4}),
                (new NonCrud.AlbumInfo{
                    Album = new Album("2#DAMN.#2017-04-14#2"),
                    SongCount = 3}),
                (new NonCrud.AlbumInfo{
                    Album = new Album("5#4:44#2017-06-30#4"),
                    SongCount = 3}),
             
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArtistsByGenreTest()
        {
            var actual = artistlogic.GetArtistsByGenre("RnB");
            var expected = new List<Artist>()
            {
                new Artist("1#Aubrey Drake Graham#Drake#1986-10-24#1")
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSongsByLabelTest()
        {
            var actual = artistlogic.GetSongsByLabel(1);
            var expected = new List<Song>()
            {
                new Song("1#Nonstop#Hip-Hop#1#1"),
                new Song("2#Can't Take A Joke#Hip-Hop#1#1"),
                new Song("3#God's Plan#Hip-Hop#1#1"),
                new Song("4#Mob Ties#Hip-Hop#1#1"),
                new Song("5#Emotionless#Hip-Hop#1#1"),
                new Song("6#Nice For What#Hip-Hop#1#1"),
                new Song("7#Jaded#RnB#1#1"),
                new Song("8#Summer Games#Rnb#1#1"),
                new Song("9#Energy#Hip-Hop#4#1"),
                new Song("10#Legend#Hip-Hop#4#1"),
                new Song("11#Know Yourself#Hip-Hop#4#1"),
                new Song("12#10 Bands#Hip-Hop#4#1"),
                new Song("13#Madonna#Hip-Hop#4#1"),
                new Song("14#6 God#Hip-Hop#4#1"),
                new Song("15#Jungle#RnB#4#1"),
                new Song("16#HUMBLE.#Hip-Hop#2#2"),
                new Song("17#DNA.#Hip-Hop#2#2"),
                new Song("18#LOVE.FEAT.ZACARI.#Hip-Hop#2#2"),
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateArtistWithIncorrectTitle()
        {
            var artist = new Artist() { RealName = "a" };

            try
            {
                artistlogic.Create(artist);
            }
            catch (Exception)
            {

            }

            mockArtistRepo.Verify(a => a.Create(artist), Times.Never);
        }

        [Test]
        public void CreateArtistWithCorrectProperties()
        {
            var artist = new Artist("5#Farkas Dávid#Tirpa#1987-05-20#3");
            artistlogic.Create(artist);
            mockArtistRepo.Verify(a => a.Create(artist), Times.Once);
        }

        [Test]
        public void CreateLabelWithIncorrectAddress() 
        {
            var label = new Label("5#A Szobám Kiadó#a");
            try
            {
                labellogic.Create(label);
            }
            catch (Exception)
            {
            }
            mockLabelRepo.Verify(a => a.Create(label), Times.Never);
        }

        [Test]
        public void CreateSongWithIncorrectNameTest()
        {
            var song = new Song("25##Hip-Hop#4#1");
            try
            {
                songlogic.Create(song);
            }
            catch (Exception)
            {
            }
            mockSongRepo.Verify(a => a.Create(song), Times.Never);
        }

        [Test]
        public void CreateAlbumWithInvalidArtistTest()
        {
            var album = new Album("6#Gyilkos Krónikák#2012-08-01#-10");
            try
            {
                albumlogic.Create(album);
            }
            catch (Exception)
            {
            }
            mockAlbumRepo.Verify(a => a.Create(album), Times.Never);
        }
        
    }
}
