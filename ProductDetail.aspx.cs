using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static eCommerceProgettoS3L5.Index;

namespace eCommerceProgettoS3L5
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                if (Request.QueryString["ProductId"] != null)
                {
                    string productId = Request.QueryString["ProductId"];                    

                    List<Index.Product> products = GetProducts();
                    Index.Product selectedProduct = products.FirstOrDefault(p => p.ProductID == productId);

                    if (selectedProduct != null)
                    {                        
                        ProductNameLabel.Text = selectedProduct.Name;
                        ProductImage.ImageUrl = selectedProduct.ImagePath;
                        ProductDescriptionLabel.Text = selectedProduct.Description;
                        ProductPriceLabel.Text = "Prezzo: " + selectedProduct.Price.ToString("C"); // Formatta il prezzo come valuta
                    }
                }
            }
        }

        
        private List<Index.Product> GetProducts()
        {
            List<Index.Product> products = new List<Index.Product>
             {
  new Index.Product { ProductID = "1", ImagePath = ResolveUrl("~/Images/image1.jpg"), Name = "GeForce RTX 4090", Description = "Meglio della 4070 Ti.", Price = 1000.00m },
  new Index.Product { ProductID = "2", ImagePath = ResolveUrl("~/Images/image2.jpg"), Name = "GeForce RTX 4070 Ti", Description = "Peggio della 4090.", Price = 900.00m },
  new Index.Product { ProductID = "3", ImagePath = ResolveUrl("~/Images/image3.jpg"), Name = "GeForce RTX 4080", Description = "Una via di mezzo.", Price = 950.00m },
  new Index.Product { ProductID = "4", ImagePath = ResolveUrl("~/Images/image4.jpg"), Name = "GeForce RTX 3060", Description = "Non hai soldi? Prendi questa.", Price = 50.00m },
  new Index.Product { ProductID = "5", ImagePath = ResolveUrl("~/Images/image5.jpg"), Name = "AMD Radeon RX 6650 XT", Description = "Inaffidabile come poche cose al mondo.", Price = 200.00m },
  new Index.Product { ProductID = "6", ImagePath = ResolveUrl("~/Images/image6.jpg"), Name = "AMD Radeon RX 580", Description = "Non so se vi conviene.", Price = 400.00m },
 };

            return products;
        }
    }
}