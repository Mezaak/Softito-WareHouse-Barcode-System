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
    public class InventoryManager : IInventoryService
    {
        IInventoryDal _InventoryDal;
        public void Inventorydelete(Inventory ı)
        {
            _InventoryDal.Delete(ı);
        }

        public Inventory GetById(int id)
        {
            return _InventoryDal.Get(x => x.InventoryId == id);
        }

        public void Inventoryinsert(Inventory ı)
        {
            _InventoryDal.Insert(ı);
        }

        public void Inventoryupdate(Inventory ı)
        {
            _InventoryDal.Update(ı);
        }

        public List<Inventory> Liste()
        {
            return _InventoryDal.GetAll();
        }

        public Inventory InventoryGetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    
    }


