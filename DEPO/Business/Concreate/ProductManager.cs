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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> ProductListe()
        {
            return _productDal.GetAll();
        }

        public void Productdelete(Product P)
        {
            _productDal.Delete(P);
        }

        public Product ProductGetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public void ProductInsert(Product product)
        {
            _productDal.Insert(product);
        }



        public void Productupdate(Product P)
        {
           _productDal.Update(P);
        }

        void IProductService.Productinsert(Product P)
        {
            throw new NotImplementedException();
        }
    }
}
