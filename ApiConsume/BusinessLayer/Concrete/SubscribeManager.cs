using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void Delete(Subscribe item)
        {
            _subscribeDal.Delete(item);
        }

        public List<Subscribe> GetAll()
        {
            return _subscribeDal.GetAll();
        }

        public Subscribe GetByID(int id)
        {
           return _subscribeDal.GetByID(id);
        }

        public void Insert(Subscribe item)
        {
            _subscribeDal.Insert(item);
        }

        public void Update(Subscribe item)
        {
            _subscribeDal.Update(item);
        }
    }
}
