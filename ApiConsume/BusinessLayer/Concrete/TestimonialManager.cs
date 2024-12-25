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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal) 
        { 
            _testimonialDal = testimonialDal;
        }
        public void Delete(Testimonial item)
        {
            _testimonialDal.Delete(item);
        }

        public List<Testimonial> GetAll()
        {
            return _testimonialDal.GetAll();
        }

        public Testimonial GetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public void Insert(Testimonial item)
        {
            _testimonialDal.Insert(item);
        }

        public void Update(Testimonial item)
        {
            _testimonialDal.Update(item);
        }
    }
}
