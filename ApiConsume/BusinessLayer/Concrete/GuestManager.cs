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
    public class GuestManager : IGuestService
    {
        IGuestDal _guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            _guestDal = guestDal;
        }

        public void Delete(Guest item)
        {
            throw new NotImplementedException();
        }

        public List<Guest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guest GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return _guestDal.GuestCount();
        }

        public void Insert(Guest item)
        {
            throw new NotImplementedException();
        }

        public void Update(Guest item)
        {
            throw new NotImplementedException();
        }
    }
}
