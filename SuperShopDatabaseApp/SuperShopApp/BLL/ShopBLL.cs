using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperShopApp.DLL.DAO.View;
using SuperShopApp.DLL.GATEWAY;

namespace SuperShopApp.BLL
{
    class ShopBLL
    {
        private ShopGateWay aShopGateWay;
     
        public ShopBLL()
        {

            aShopGateWay = new ShopGateWay();
        }

        public string Save(Shop aShop)
        {
            if (aShop.Shop_Name==string.Empty || aShop.Shop_Address==string.Empty)
            {
                return "Please Fill Up Shop Fields";
            }
            else
            {
                if (HsaValidShopName(aShop.Shop_Name))
                {
                    return "Name Already Exists";
                }
                else
                {
                    return aShopGateWay.Save(aShop);
                }
            }
         
          
        }

        private bool HsaValidShopName(string name)
        {
            return aShopGateWay.HsaValidShopName(name);
        }

        public List<Shop> GetAllShops()
        {
            return aShopGateWay.GetAllShops();
        }


        public List<ShopProduct> ShowSuperShopInfo()
        {
            return aShopGateWay.ShowSuperShopInfo();
        }
       
    }
}
