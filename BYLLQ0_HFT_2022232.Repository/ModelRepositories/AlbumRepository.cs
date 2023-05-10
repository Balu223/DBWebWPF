using BYLLQ0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Repository
{
    public class AlbumRepository : Repository<Album>, IRepository<Album>
    {
        public AlbumRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Album Read(int id)
        {
            return ctx.Albums.FirstOrDefault(t => t.AlbumId == id);
        }

        public override void Update(Album item)
        {
            var old = Read(item.AlbumId);
            foreach (var property in old.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    property.SetValue(old, property.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
