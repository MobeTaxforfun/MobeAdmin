using MobeAdmin.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.Interface
{
    public interface IProductRepostory
    {
        Task<IEnumerable<Product>> ListedProduct();
    }
}
