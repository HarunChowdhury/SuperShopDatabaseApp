using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShopApp.BLL;
using SuperShopApp.DLL.DAO.View;

namespace SuperShopApp
{
    public partial class SuperShopUI : Form
    {

        private ShopBLL aShopBll = new ShopBLL();
        private ProductBLL aProductBll = new ProductBLL();
        private List<Shop> shops = new List<Shop>();
        private List<Product> products = new List<Product>();
        private List<ShopProduct> aShopProducts = new List<ShopProduct>(); 
        public SuperShopUI()
        {
            InitializeComponent();
        }

        private void shopSaveButton_Click(object sender, EventArgs e)
        {
          Shop aShop = new Shop(nameTextBox.Text,addressTextBox.Text);        
            string msg=aShopBll.Save(aShop);
            MessageBox.Show(msg);
            ShowShopDataInGrid();
        }

        private void ShowShopDataInGrid()
        {
            shops = aShopBll.GetAllShops();
            showDataGridView.DataSource = shops;
        }

        private void productSaveButton_Click(object sender, EventArgs e)
        {
          
            Product aProduct = new Product();        
            aProduct.Product_Id = productIdTextBox.Text;
            aProduct.Product_Quantity = quentityTextBox.Text;          
            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
            ShowProductDataInGrid();

        }
        private void ShowProductDataInGrid()
        {
            products = aProductBll.GetAllProducts();
            showDataGridView.DataSource = products;
        }
       

        private void showDetailsButton_Click(object sender, EventArgs e)
        {

            ShowAllDataInGrid();

        }

        private void ShowAllDataInGrid()
        {
            aShopProducts = aShopBll.ShowSuperShopInfo();
            showDataGridView.DataSource = aShopProducts;
        }
      
      
    }
}
