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
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        private readonly Context _context;
        public EfRoomDal(Context context) : base(context)
        {
            _context = context;
        }
        public int RoomCount()
        {
            
            var value = _context.Rooms.Count();
            return value;
        }
    }
}
