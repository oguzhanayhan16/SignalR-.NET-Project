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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDal;

        public OrderDetailManager(IOrderDetailDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDal.Delete(entity);
        }

        public OrderDetail TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDal.Update(entity);
        }
    }
}
