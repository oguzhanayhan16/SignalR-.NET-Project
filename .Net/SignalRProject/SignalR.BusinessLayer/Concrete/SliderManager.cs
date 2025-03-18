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
    public class SliderManager:ISliderService
    {
        private readonly ISliderDal sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            this.sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
            sliderDal.Delete(entity);
        }

        public Slider TGetByID(int id)
        {
            return sliderDal.GetByID(id);
        }

        public List<Slider> TGetListAll()
        {
            return sliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            sliderDal.Update(entity);
        }
    }
}
