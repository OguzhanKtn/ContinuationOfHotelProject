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
    public class ServiceManager : IServicesService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Delete(Services item)
        {
            _serviceDal.Delete(item);
        }

        public List<Services> GetAll()
        {
            return _serviceDal.GetAll();    
        }

        public Services GetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public void Insert(Services item)
        {
            _serviceDal.Insert(item);
        }

        public void Update(Services item)
        {
            _serviceDal.Update(item);
        }
    }
}
