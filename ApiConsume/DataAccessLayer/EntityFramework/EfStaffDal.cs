using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal(Context context) : base(context)
        {
            _context = context; 
        }

        public int GetStaffCount()
        {
            
            var value = _context.Staffs.Count();
            return value;
        }

        public List<Staff> Last4Staff()
        {
           
            var values = _context.Staffs.OrderByDescending(x => x.Id).Take(4).ToList();
            return values;
        }
    }
}
