using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_SYSTEM
{
    internal class Product:Specifications
    {
      
        private int Quantity {  get; set; }
        private float Price {  get; set; }
        private string Category {  get; set; }
        public Product(int id, string name, int quantity, float price, string category):base(id,name)
        {
          
            Quantity = quantity;
            Price = price;
            Category = category;
        }
        public Product(int id,string name,float price):base(id,name)
        {
      
            Price = price;
        }
    }
}
