using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperShopApp.DLL.GATEWAY;

namespace SuperShopApp.BLL
{
    class ProductBLL
    {
        private ProductGateWay aProductGateWay;
        private List<Product> products;
      //  private int updatedQuantity;
        public ProductBLL()
        {
            aProductGateWay = new ProductGateWay();
            products = aProductGateWay.GetAllProducts();
        }

        public string Save(Product aProduct)
        {
            if (aProduct.Product_Id== string.Empty || aProduct.Product_Quantity==string.Empty)
            {
                return "Please Fill Up Product Fields";
            }
            else
            {
                if (HsaValidProductId(aProduct.Product_Id))
                {                               
                   int newQuantity = Convert.ToInt32(aProduct.Product_Quantity);
                  return aProductGateWay.SaveUpdatedQuantity(newQuantity,aProduct.Product_Id);
                  
                }
                else
                {
                     return aProductGateWay.Save(aProduct);
                    
                }
            }
         
        }

        private bool HsaValidProductId(string id)
        {
            return aProductGateWay.HsaValidProductId(id);
        }

        public List<Product> GetAllProducts()
        {
            return aProductGateWay.GetAllProducts();
        }
    }
}
