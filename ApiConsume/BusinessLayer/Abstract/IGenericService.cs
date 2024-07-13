using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        T GetByID(int id);
        List<T> GetAll();
    }
}
