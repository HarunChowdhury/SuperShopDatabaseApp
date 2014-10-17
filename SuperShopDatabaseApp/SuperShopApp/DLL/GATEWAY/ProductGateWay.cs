using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopApp.DLL.GATEWAY
{
    internal class ProductGateWay
    {
        private SqlConnection connection;

        public ProductGateWay()
        {
            string conn = @"server=BITM-401-PC24\SQLEXPRESS; database=SuperShop;integrated security=true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;

        }

        public string Save(Product aProduct)
        {
            connection.Open();
            string query = String.Format("INSERT INTO t_Product VALUES('{0}','{1}')", aProduct.Product_Id, aProduct.Product_Quantity);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Product Inserted Successfully";
            return "Something problem in System";
        }

        public bool HsaValidProductId(string id)
        {
            connection.Open();
            string query = String.Format("SELECT * FROM t_Product WHERE Product_Id='{0}'", id);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool hasRows = aReader.HasRows;
            connection.Close();
            return hasRows;
        }

        public List<Product> GetAllProducts()
        {
            connection.Open();
            string querry = string.Format("SELECT * FROM t_Product");
            SqlCommand command = new SqlCommand(querry, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> Products = new List<Product>();
            int serial = 1;
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.Serial_No =serial;
                    aProduct.Product_Id = aReader[1].ToString();
                    aProduct.Product_Quantity =  aReader[2].ToString();
               
                    Products.Add(aProduct);

                    serial++;
                }
            }

            connection.Close();
            return Products;
        }

        public string SaveUpdatedQuantity(int newQuantity, string id)
        {
            connection.Open();
            string query = String.Format("UPDATE t_Product SET Product_Quantity=Product_Quantity+{0} WHERE Product_Id='{1}'", newQuantity, id);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Product Updated & Inserted success";
            return "Something problem in System";
        }
    }
}
