using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.Data
{
    public class InventoryManagementSystem1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public InventoryManagementSystem1Context() : base("name=InventoryManagementSystem1Context")
        {
        }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Product> Products { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<InventoryManagementSystem1.Report> Reports { get; set; }
    }
}
