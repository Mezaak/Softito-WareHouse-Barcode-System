using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    public class Inventory
    {
        public int InventoryId { get; set; }     
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }


}
