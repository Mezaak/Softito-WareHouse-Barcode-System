using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concreate;

namespace Business.Abstract
{
    public interface IInventoryService
    {
        List<Inventory> Liste();
        void Inventoryinsert(Inventory ı);
        void Inventoryupdate(Inventory ı);
        void Inventorydelete(Inventory ı);
        Inventory InventoryGetById(int id);
    }
}
