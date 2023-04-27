using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BYLLQ0_HFT_2022232.Models;

#nullable disable

namespace BYLLQ0_HFT_2022232.Repository
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }


        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True;MultipleActiveResultSets=True;
                builder
                    .UseInMemoryDatabase("music")
                        .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ModelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                //entity.Property(e => e.AlbumId)
                //    .ValueGeneratedNever()
                //    .HasColumnName("AlbumID");

                //entity.Property(e => e.AlbumName)
                //    .HasMaxLength(255)
                //    .IsUnicode(false);

                //entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                //entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Albums__ArtistID__3B75D760");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                //entity.Property(e => e.ArtistId)
                //    .ValueGeneratedNever()
                //    .HasColumnName("ArtistID");

                //entity.Property(e => e.DateOfBirth).HasColumnType("date");

                //entity.Property(e => e.LabelId).HasColumnName("LabelID");

                //entity.Property(e => e.RealName)
                //    .HasMaxLength(255)
                //    .IsUnicode(false);

                //entity.Property(e => e.StageName)
                //    .HasMaxLength(255)
                //    .IsUnicode(false);

                entity.HasOne(d => d.Label)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.LabelId)
                    .HasConstraintName("FK__Artists__LabelID__38996AB5");
            });

            //modelBuilder.Entity<Label>(entity =>
            //{
            //    entity.Property(e => e.LabelId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("LabelID");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LabelName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Song>(entity =>
            {
                //entity.Property(e => e.SongId)
                //    .ValueGeneratedNever()
                //    .HasColumnName("SongID");

                //entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                //entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                //entity.Property(e => e.Genre)
                //    .HasMaxLength(255)
                //    .IsUnicode(false);

                //entity.Property(e => e.SongName)
                //    .HasMaxLength(255)
                //    .IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__Songs__AlbumID__3E52440B");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Songs__ArtistID__3F466844");
            });

            //OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Label>().HasData(new Label[]
            {
                new Label("1#Def Jam Recordings#New York, NY"),
                new Label("2#Interscope Records#Santa Monica, CA"),
                new Label("3#Republic Records#New York, NY"),
                new Label("4#Epic Records#New York, NY"),
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist("1#Shawn Corey Carter#Jay-Z#1969-12-04#1"),
                new Artist("2#Aubrey Drake Graham#Drake#1986-10-24#2"),
                new Artist("3#Kendrick Lamar Duckworth#Kendrick Lamar#1987-06-17#2"),
                new Artist("4#Sean Michael Leonard Anderson#Big Sean#1988-03-25#3"),
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album("1#4:44#2017-06-30#1"),
                new Album("2#Scorpion#2018-06-29#2"),
                new Album("3#DAMN.#2017-04-14#3"),
                new Album("4#Detroit 2#2020-09-04#4"),
            });
            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song("1#The Story of O.J.#Hip-Hop#1#1"),
                new Song("2#Nonstop#Hip-Hop#2#2"),
                new Song("3#HUMBLE.#Hip-Hop#3#3"),
                new Song("4#Deep Reverence#Hip-Hop#4#4"),
            });
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
