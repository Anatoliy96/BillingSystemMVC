using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.DAO
{
    interface IDao<TModel>
    {
        List<TModel> GetAll();
        void Insert(TModel Entity);
        void Update(TModel Entity);
        void Delete(TModel Entity);
    }
}
