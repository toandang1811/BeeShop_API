using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Object class from DataAcess</typeparam>
    /// <typeparam name="G">Object Class from entities</typeparam>
    public interface IMapperCommon<T, G> where T : class
    {
        T FillFromDomain(G obj);
        G FillFromDataAccess(T obj);
    }
}
