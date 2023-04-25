using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BYLLQ0_HFT_2022232.Models
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }
        public string RealName { get; set; }
        public string StageName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? LabelId { get; set; }

        public virtual Label Label { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        public Artist(string data)
        {
            string[] d = data.Split('#');
            ArtistId = int.Parse(d[0]);
            RealName = d[1];
            StageName = d[2];
            DateOfBirth = DateTime.Parse(d[3].Replace('-','.'));
            LabelId = int.Parse(d[4]);
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
    }
}
