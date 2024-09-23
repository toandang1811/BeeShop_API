using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IReponsitoryCommon<T> where T : class
    {
        Task<T> Add(T item);
        Task<T> Update (T item);
        Task<bool> Delete(string id);
        Task<IEnumerable<T>> GetAll(string txtSearch, int? page);
        Task<T> GetByID(string id);
    }
}
