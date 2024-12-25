using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeApproved(int id);
        int GetBookingCount();
        List<Booking> Last6Bookings();
        void BookingStatusChangeCancel(int id);
        void BookingStatusChangeWait(int id);
    }
}
