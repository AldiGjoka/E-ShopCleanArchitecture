using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBasketService : IBaseRepository<Basket>
    {
        Task<Basket> GetBasketByUserId(string id);
    }
}
