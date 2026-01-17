using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_SYSTEM
{
    internal class Seller:Specifications
    {
    
        private string Email { get; set; }
        private int ContactPerson {  get; set; }
        private string Address {  get; set; }

        public Seller(int id, string name, string email, int contactPerson, string address) : base(id, name)
        {
           
            Email = email;
            ContactPerson = contactPerson;
            Address = address;
        }
        public Seller(int id,string name) : base(id, name)
        {

        }
    }
}
