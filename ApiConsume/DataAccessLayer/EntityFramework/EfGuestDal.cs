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
    public class EfGuestDal : GenericRepository<Guest>, IGuestDal
    {
        private readonly Context _context; 
        public EfGuestDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GuestCount()
        {
            return _context.Guests.Count();
        }
    }
}
