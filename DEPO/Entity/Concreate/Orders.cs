using Entity.Concreate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

public class Orders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Sadece OrderId Identity olacak
    public int OrderId { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; } // Identity olmamalı

    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public virtual Product Product { get; set; }
}

