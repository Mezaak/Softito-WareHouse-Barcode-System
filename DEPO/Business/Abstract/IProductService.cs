using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> ProductListe();
        void Productinsert(Product P);
        void Productupdate(Product P);
        void Productdelete(Product P);
        Product ProductGetById(int id);
    }
}
