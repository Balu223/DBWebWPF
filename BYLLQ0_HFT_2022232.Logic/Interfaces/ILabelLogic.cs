using BYLLQ0_HFT_2022232.Models;
using System.Collections.Generic;
using System.Linq;

namespace BYLLQ0_HFT_2022232.Logic
{
    public interface ILabelLogic
    {
        void Create(Label item);
        void Delete(int id);
        Label Read(int id);
        IQueryable<Label> ReadAll();
        void Update(Label item);
        List<(Label, int)> GetLabelsWithMostAlbums();
    }
}