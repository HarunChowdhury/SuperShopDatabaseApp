using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using SuperShopApp.DLL.DAO.View;

namespace SuperShopApp.DLL.GATEWAY
{
    class ShopGateWay
    {
        private  SqlConnection connection;

        public ShopGateWay()
        {
            string conn = @"server=BITM-401-PC24\SQLEXPRESS; database=SuperShop;integrated security=true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;

        }

        public string Save(Shop aShop)
        {
            connection.Open();
            string query =String.Format("INSERT INTO t_Shop VALUES('{0}','{1}')",aShop.Shop_Name,aShop.Shop_Address);
            SqlCommand command = new SqlCommand(query,connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows>0)           
                return "Shop insert Success";
            return "Something problem in System";

            

        }

        public bool HsaValidShopName(string name)
        {
            connection.Open();
            string query = String.Format("SELECT * FROM t_Shop WHERE Shop_Name='{0}'",name);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool hasRows = aReader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Shop> GetAllShops()
        {

            connection.Open();
            string querry = string.Format("SELECT * FROM t_Shop");
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Shop> shops = new List<Shop>();
          
            if (aReader.HasRows)
            {
                int serial = 1;
                while (aReader.Read())
                {
                    Shop aShop = new Shop();
                    aShop.Shop_Id=serial;
                    aShop.Shop_Name = aReader[1].ToString();
                    aShop.Shop_Address= aReader[2].ToString();
                    shops.Add(aShop);
                    serial++;
                }

               
            }

            connection.Close();
            return shops;
        }

        public List<ShopProduct> ShowSuperShopInfo()
        {

            connection.Open();       
            string querry =string.Format("SELECT * FROM t_Shop ,t_Product");
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<ShopProduct> shopProducts = new List<ShopProduct>();

            if (aReader.HasRows)
            {
                int serial = 1;
                while (aReader.Read())
                {
                    ShopProduct aShopProduct = new ShopProduct();
                    aShopProduct.Shop_Id= serial;
                    aShopProduct.Shop_Name = aReader[1].ToString();
                    aShopProduct.Shop_Address = aReader[2].ToString();
                    aShopProduct.Product_Id= aReader[4].ToString();
                    aShopProduct.Product_Quantity = aReader[5].ToString();
                   shopProducts.Add(aShopProduct);
                    serial++;
                }


            }

            connection.Close();
            return shopProducts;
        }
    }
}
