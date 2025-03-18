using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
   public class SocialMediaManager:ISocialMediaService
    {
        private readonly ISocialMediaDal _social;

        public SocialMediaManager(ISocialMediaDal social)
        {
            _social = social;
        }

        public void TAdd(SocialMedia entity)
        {
            _social.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _social.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _social.GetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _social.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _social.Update(entity);
        }
    }
}
