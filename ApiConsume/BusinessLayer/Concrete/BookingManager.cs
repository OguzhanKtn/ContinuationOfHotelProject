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
        public void TBookingStatusChangeApproved(int id)
        {
            _bookingDal.BookingStatusChangeApproved(id);
        }

        public void TBookingStatusChangeCancel(int id)
        {
            _bookingDal.BookingStatusChangeCancel(id);
        }

        public void TBookingStatusChangeWait(int id)
        {
            _bookingDal.BookingStatusChangeWait(id);
        }
        public List<Booking> TLast6Bookings()
        {
            return _bookingDal.Last6Bookings();
        }
        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
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
