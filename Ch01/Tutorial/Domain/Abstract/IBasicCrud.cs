using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IBasicCrud<T>
    {
        List<T> GetAll();
        T Get(string id);
        bool Update(string id, T entity);
        bool Add(T entity);
        bool Delete(string id);
    }
}