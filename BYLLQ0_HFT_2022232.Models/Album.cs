using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BYLLQ0_HFT_2022232.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public Album(string data)
        {
            string[] d = data.Split('#');
            AlbumId = int.Parse(d[0]);
            AlbumName = d[1];
            ReleaseDate = DateTime.Parse(d[2].Replace('-','.'));
            ArtistId = int.Parse(d[3]);
            Songs = new HashSet<Song>();
        }
    }
}
