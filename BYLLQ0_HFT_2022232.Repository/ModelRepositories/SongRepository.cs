using BYLLQ0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Repository
{
    public class SongRepository : Repository<Song>, IRepository<Song>
    {
        public SongRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Song Read(int id)
        {
            return ctx.Songs.FirstOrDefault(t => t.SongId == id);
        }

        public override void Update(Song item)
        {
            var old = Read(item.SongId);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
