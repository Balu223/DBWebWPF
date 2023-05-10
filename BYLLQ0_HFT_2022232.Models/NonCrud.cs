using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Models
{
    public class NonCrud
    {
        public class AlbumInfo
        {
            public Album Album { get; set; }
            public int SongCount { get; set; }

            public override bool Equals(object obj)
            {
                AlbumInfo a = obj as AlbumInfo;
                if (a == null)
                {
                    return false;
                }
                else
                {
                    return this.Album.Equals(a.Album)
                        && this.SongCount == a.SongCount;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Album, this.SongCount);
            }
        }
        public class LabelInfo
        {
            public Label Label { get; set; }
            public int? AlbumCount { get; set; }
            public override bool Equals(object obj)
            {
                LabelInfo l = obj as LabelInfo;
                if (l == null)
                {
                    return false;
                }
                else
                {
                    return this.Label.Equals(l.Label)
                        && this.AlbumCount == l.AlbumCount;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Label, this.AlbumCount);
            }
        }
        public class ArtistInfo
        {
            public Artist Artist { get; set; }
            public int SongCount { get; set; }

            public override bool Equals(object obj)
            {
                ArtistInfo l = obj as ArtistInfo;
                if (l == null)
                {
                    return false;
                }
                else
                {
                    return this.Artist.Equals(l.Artist)
                        && this.SongCount == l.SongCount;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Artist, this.SongCount);
            }
        }
    }
}
