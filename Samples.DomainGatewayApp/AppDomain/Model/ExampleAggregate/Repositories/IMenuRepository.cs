using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Model.ExampleAggregate.Repositories
{
    public interface IMenuRepository
    {
        Task<Menu> Find(int id);

        Task<Menu> Create(Menu menu);

        Task<bool> Delete(int id);
    }
}
