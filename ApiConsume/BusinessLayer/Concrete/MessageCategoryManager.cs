using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        IMessageCategoryDal _messageCategoryDal;
        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal) 
        { 
            _messageCategoryDal = messageCategoryDal;
        }
        public void Delete(MessageCategory item)
        {
            _messageCategoryDal.Delete(item);
        }

        public List<MessageCategory> GetAll()
        {
            return _messageCategoryDal.GetAll();    
        }

        public MessageCategory GetByID(int id)
        {
            return _messageCategoryDal.GetByID(id);
        }

        public void Insert(MessageCategory item)
        {
            _messageCategoryDal.Insert(item);
        }

        public void Update(MessageCategory item)
        {
            _messageCategoryDal.Update(item);
        }
    }
}
