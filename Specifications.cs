using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_SYSTEM
{
    internal class Specifications
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public Specifications(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
