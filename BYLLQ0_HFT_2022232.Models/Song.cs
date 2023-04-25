using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BYLLQ0_HFT_2022232.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public int? AlbumId { get; set; }
        public int? ArtistId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public Song()
        {
            
        }
        public Song(string data)
        {
            string[] d = data.Split('#');
            SongId = int.Parse(d[0]);
            SongName = d[1];
            Genre = d[2];
            AlbumId = int.Parse(d[3]);
            ArtistId = int.Parse(d[4]);
        }
    }
}
