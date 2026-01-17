using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_SYSTEM
{
    internal class Category:Specifications
    {
   
        private string CategoryDescription {  get; set; }
        public Category(int id, string name, string categoryDescription) : base(id, name)
        {
          
            CategoryDescription = categoryDescription;
        }
        
    }
}
