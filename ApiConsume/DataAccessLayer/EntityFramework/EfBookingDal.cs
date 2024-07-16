using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusChangeApproved(int id)
        {
            var values = _context.Bookings.Find(id);
            values.Status = "Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            
            var values = _context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            _context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            
            var values = _context.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            _context.SaveChanges();
        }

        public int GetBookingCount()
        {
           
            var value = _context.Bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            
            var values = _context.Bookings.OrderByDescending(x => x.Id).Take(6).ToList();
            return values;
        }
    }
}
