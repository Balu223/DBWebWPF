using System;
using BYLLQ0_HFT_2022232.Models;
using BYLLQ0_HFT_2022232.Repository;
using System.Linq;
using System.Collections.Generic;

namespace BYLLQ0_HFT_2022232.Logic
{
    public class LabelLogic
    {
        IRepository<Label> repo;

        public LabelLogic(IRepository<Label> repo)
        {
            this.repo = repo;
        }

        public void Create(Label item)
        {
            if (item.Address.Length < 3)
            {
                throw new ArgumentException("Address too short.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Label Read(int id)
        {
            var label = this.repo.Read(id);
            if (label == null)
            {
                throw new ArgumentException("Label doesnt exist.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Label> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Label item)
        {
            this.repo.Update(item);
        }

        // 5 non crud method
        //Albumonként össz-zene


        //artistonként hány százaléka a zenéinek hip-hop?
        //azok közül akik az interscopenál vannak kinek van több albuma
        //labelenként összzene
        //átlag zeneszám artistonként
    }
}
