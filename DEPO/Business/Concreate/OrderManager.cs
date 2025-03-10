using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstarct;
using Data.EntityFramework;
using Entity.Concreate;

namespace Business.Concreate
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Orders> Liste()
        {
            return _orderDal.GetAll();
        }

        public void Orderinsert(Orders order)
        {
            _orderDal.Insert(order);
        }

        public void Orderupdate(Orders order)
        {
            _orderDal.Update(order);
        }

        public void Orderdelete(Orders order)
        {
            _orderDal.Delete(order);
        }

        public Orders OrderGetById(int id)
        {
            return _orderDal.Get(o => o.OrderId == id);
        }
    }
}




