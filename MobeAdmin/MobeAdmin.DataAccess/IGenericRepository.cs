using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListedAllAsync();
        Task<int> CreateAsync(T model);
        Task<int> UpdateAsync(T model);
        Task<int> DeleteAsync(T model);
        Task<T> GetOne(int Id);
        Task<Tuple<int, IEnumerable<T>>> PaginateAsync(int page, int itemsPerPage);
    }
}
