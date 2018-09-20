using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDomainSimple.Model.PromotionAggregate.Repositories
{
    public interface IPromotionRepository
    {
        IEnumerable<Promotion> FindAll();
        Promotion Find(int id);
        int Create(Promotion value);
        bool Modify(int id, Promotion value);
        bool Delete(int id);
    }
}
