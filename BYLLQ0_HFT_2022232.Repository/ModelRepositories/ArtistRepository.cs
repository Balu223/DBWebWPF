using BYLLQ0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Repository
{
    public class ArtistRepository : Repository<Artist>, IRepository<Artist>
    {
        public ArtistRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Artist Read(int id)
        {
            return ctx.Artists.FirstOrDefault(t => t.ArtistId == id);
        }

        public override void Update(Artist item)
        {
            var old = Read(item.ArtistId);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
