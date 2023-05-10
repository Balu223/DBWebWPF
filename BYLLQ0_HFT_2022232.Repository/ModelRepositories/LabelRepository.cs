using BYLLQ0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYLLQ0_HFT_2022232.Repository
{
    public class LabelRepository : Repository<Label>, IRepository<Label>
    {
        public LabelRepository(MusicDbContext ctx) : base(ctx)
        {
        }

        public override Label Read(int id)
        {
            return ctx.Labels.FirstOrDefault(t => t.LabelId == id);
        }

        public override void Update(Label item)
        {
            var old = Read(item.LabelId);
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
