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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void Delete(SendMessage item)
        {
            _sendMessageDal.Delete(item);
        }

        public List<SendMessage> GetAll()
        {
            return _sendMessageDal.GetAll();
        }

        public SendMessage GetByID(int id)
        {
            return _sendMessageDal.GetByID(id);
        }

        public int GetSendMessageCount()
        {
          return _sendMessageDal.GetSendMessageCount();
        }

        public void Insert(SendMessage item)
        {
            _sendMessageDal.Insert(item);
        }

        public void Update(SendMessage item)
        {
            _sendMessageDal.Update(item);
        }
    }
}
