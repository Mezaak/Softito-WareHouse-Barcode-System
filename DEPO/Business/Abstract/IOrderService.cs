using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Orders> Liste();
        void Orderinsert(Orders O);
        void Orderupdate(Orders O);
        void Orderdelete(Orders O);
        Orders OrderGetById(int id);
    }
}
