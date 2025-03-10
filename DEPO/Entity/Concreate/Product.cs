using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Concreate
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? InventoryId { get; set; }
        public string Barcode { get; set; }
        public virtual Inventory Inventory { get; set; }    
        public virtual ICollection<Orders> Orders { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryName
        {
            get { return Category != null ? Category.CategoryName : "Kategori Yok"; }
        }

    }
}
