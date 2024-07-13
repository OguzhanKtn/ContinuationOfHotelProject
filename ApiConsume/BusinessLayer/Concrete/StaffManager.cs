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
    public class StaffManager: IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void Delete(Staff item)
        {
            _staffDal.Delete(item);
        }

        public List<Staff> GetAll()
        {
            return _staffDal.GetAll(); 
        }

        public Staff GetByID(int id)
        {
            return _staffDal.GetByID(id);
        }

        public void Insert(Staff item)
        {
            _staffDal.Insert(item);
        }

        public void Update(Staff item)
        {
            _staffDal.Update(item);
        }
    }
}
