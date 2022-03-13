using MobeAdmin.DataAccess.DbCore.Base;
using MobeAdmin.DataAccess.Interface;
using MobeAdmin.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.Repository
{
    public class ProductRepostory : BaseRepository<Product>, IProductRepostory
    {
        public ProductRepostory(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {


        }

        public Task<IEnumerable<Product>> ListedProduct()
        {
            throw new NotImplementedException();
        }
    }

}
