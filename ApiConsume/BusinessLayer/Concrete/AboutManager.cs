using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Delete(About item)
        {
            _aboutDal.Delete(item);
        }

        public List<About> GetAll()
        {
           return _aboutDal.GetAll();
        }

        public About GetByID(int id)
        {
           return _aboutDal.GetByID(id);
        }

        public void Insert(About item)
        {
            _aboutDal.Insert(item);
        }

        public void Update(About item)
        {
            _aboutDal.Update(item);
        }
    }
}
