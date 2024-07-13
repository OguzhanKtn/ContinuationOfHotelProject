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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact item)
        {
            _contactDal.Delete(item);   
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public int GetContactCount()
        {
            return _contactDal.GetContactCount();
        }

        public void Insert(Contact item)
        {
            _contactDal.Insert(item);
        }

        public List<Contact> messageListByCategory(int id)
        {
            return _contactDal.messageListByCategory(id);
        }

        public void Update(Contact item)
        {
            _contactDal.Update(item);
        }
    }
}
