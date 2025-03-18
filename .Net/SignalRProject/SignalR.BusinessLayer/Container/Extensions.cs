using Microsoft.Extensions.DependencyInjection;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Container
{
   public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection service)
        {
       

             service.AddScoped<IAboutService, AboutManager>();
             service.AddScoped<IAboutDal, EFAboutDal>();

             service.AddScoped<IBookingService, BookingManager>();
             service.AddScoped<IBookingDal, EFBookingDal>();

             service.AddScoped<ICategoryService, CategoryManager>();
             service.AddScoped<ICategoryDal, EFCategoryDal>();


             service.AddScoped<IContactService, ContactManager>();
             service.AddScoped<IContactDal, EFContactDal>();

             service.AddScoped<IDiscountService, DiscountManager>();
             service.AddScoped<IDiscountDal, EFDiscountDal>();

             service.AddScoped<IProductService, ProductManager>();
             service.AddScoped<IProductDal, EFProductDal>();

             service.AddScoped<IFeatureService, FeatureManager>();
             service.AddScoped<IFeatureDal, EFFeatureDal>();

             service.AddScoped<ISocialMediaService, SocialMediaManager>();
             service.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

             service.AddScoped<ITestimonialService, TestimonialManager>();
             service.AddScoped<ITestimonialDal, EFTestimonialDal>();

             service.AddScoped<IOrderDetailService, OrderDetailManager>();
             service.AddScoped<IOrderDetailDal, EFOrderDetailDal>();


             service.AddScoped<IOrderService, OrderManager>();
             service.AddScoped<IOrderDal, EFOrderDal>();

             service.AddScoped<IMoneyCaseService, MoneyCaseManager>();
             service.AddScoped<IMoneyCaseDal, EFMoneyCaseDal>();


             service.AddScoped<IMoneyCaseService, MoneyCaseManager>();
             service.AddScoped<IMoneyCaseDal, EFMoneyCaseDal>();

             service.AddScoped<ISliderService, SliderManager>();
             service.AddScoped<ISliderDal, EFSliderDal>();

             service.AddScoped<IBasketService, BasketManager>();
             service.AddScoped<IBasketDal, EFBasketDal>();


             service.AddScoped<INotificationService, NotificationManager>();
             service.AddScoped<INotificationDal, EFNotificationDal>();


             service.AddScoped<IMenuTableService, MenuTableManager>();
             service.AddScoped<IMenuTableDal, EFMenuTableDal>();

             service.AddScoped<IMessageService, MessageManager>();
             service.AddScoped<IMessageDal, EFMessageDal>();
        }
    }
}
