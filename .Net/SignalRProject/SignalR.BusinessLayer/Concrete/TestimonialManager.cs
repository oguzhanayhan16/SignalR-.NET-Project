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
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _test;

        public TestimonialManager(ITestimonialDal test)
        {
            _test = test;
        }

        public void TAdd(Testimonial entity)
        {
            _test.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _test.Delete(entity);
        }

        public Testimonial TGetByID(int id)
        {
            return _test.GetByID(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _test.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _test.Update(entity);
        }
    }
}
