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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
        public void Delete(Booking item)
        {
            _bookingDal.Delete(item);
        }

        public List<Booking> GetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking GetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public void Insert(Booking item)
        {
            _bookingDal.Insert(item);
        }

        public void Update(Booking item)
        {
            _bookingDal.Update(item);
        }
    }
}
