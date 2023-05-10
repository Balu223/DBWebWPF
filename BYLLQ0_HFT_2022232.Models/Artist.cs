using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }
        [JsonIgnore]
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
        public override bool Equals(object obj)
        {
            Artist a = obj as Artist;
            if (a == null)
            {
                return false;
            }
            else
            {
                return this.ArtistId == a.ArtistId
                    && this.RealName == a.RealName
                    && this.StageName == a.StageName
                    && this.DateOfBirth == a.DateOfBirth
                    && this.LabelId == a.LabelId;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ArtistId, this.RealName, this.StageName, this.DateOfBirth, this.LabelId);
        }
    }
}
