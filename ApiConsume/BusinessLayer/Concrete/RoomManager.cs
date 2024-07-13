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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void Delete(Room item)
        {
            _roomDal.Delete(item);
        }

        public List<Room> GetAll()
        {
           return _roomDal.GetAll();
        }

        public Room GetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public void Insert(Room item)
        {
            _roomDal.Insert(item);
        }

        public void Update(Room item)
        {
            _roomDal.Update(item);
        }
    }
}
