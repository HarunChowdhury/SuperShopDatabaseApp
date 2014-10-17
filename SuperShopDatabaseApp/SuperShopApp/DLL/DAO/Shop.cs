using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopApp
{
    class Shop
    {
        public int  Shop_Id { get; set; }
        public string Shop_Name { get; set; }
        public string Shop_Address { get; set; }
    

        public Shop(string name, string address)
        {
            Shop_Name = name;
            Shop_Address = address;
          
        }

        public Shop()
        {
            
        }
      
        
    }
}
