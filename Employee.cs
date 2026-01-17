using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_SYSTEM
{
    internal class Employee:Specifications
    {
      
        private int MobileNumber {  get; set; }
        private string Email {  get; set; }
        private string Address {  get; set; }
        public Employee(int id, string name, int mobileNumber, string email, string address):base(id,name)
        {
            
           
            MobileNumber = mobileNumber;
            Email = email;
            Address = address;
        }
        public Employee(int id,string name): base(id, name)
        {
          
        }
    }
}
