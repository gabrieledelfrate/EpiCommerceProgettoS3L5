using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerceProgettoS3L5
{
    public partial class Index : System.Web.UI.Page
    {
        public class Product
        {
            public string ProductID { get; set; }
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                LoadProductData();
            }
            
        }       

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            Button btnAddToCart = (Button)sender;
            string[] args = btnAddToCart.CommandArgument.Split('|');

            string productId = args[0];
            string productName = args[1];
            decimal productPrice = decimal.Parse(args[2]);
            
            Product selectedProduct = new Product
            {
                ProductID = productId,
                ImagePath = ResolveUrl("~/Images/" + productId + ".jpg"), 
                Name = productName,
                Description = "Breve descrizione dell'articolo " + productId,
                Price = productPrice
            };

            AddProductToCart(selectedProduct);
        }

        private void LoadProductData()
        {
            List<Product> products = new List<Product>
               {
                new Product { ProductID = "1", ImagePath = ResolveUrl("~/Images/image1.jpg"), Name = "GeForce RTX 4090", Description = "Meglio della 4070 Ti.", Price = 1000.00m },
                new Product { ProductID = "2", ImagePath = ResolveUrl("~/Images/image2.jpg"), Name = "GeForce RTX 4070 Ti", Description = "Peggio della 4090.", Price = 900.00m },
                new Product { ProductID = "3", ImagePath = ResolveUrl("~/Images/image3.jpg"), Name = "GeForce RTX 4080", Description = "Una via di mezzo.", Price = 950.00m },
                new Product { ProductID = "4", ImagePath = ResolveUrl("~/Images/image4.jpg"), Name = "GeForce RTX 3060", Description = "Non hai soldi? Prendi questa.", Price = 50.00m },
                new Product { ProductID = "5", ImagePath = ResolveUrl("~/Images/image5.jpg"), Name = "AMD Radeon RX 6650 XT", Description = "Inaffidabile come poche cose al mondo.", Price = 200.00m },
                new Product { ProductID = "6", ImagePath = ResolveUrl("~/Images/image6.jpg"), Name = "AMD Radeon RX 580", Description = "Non so se vi conviene.", Price = 400.00m },
               };

            ProductsRepeater.DataSource = products;
            ProductsRepeater.DataBind();
        }

        private void AddProductToCart(Product product)
        {            
            List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();

            cart.Add(product);

            Session["Cart"] = cart;
        }

        protected void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            Button btnViewDetails = (Button)sender;
            string productId = btnViewDetails.CommandArgument;

            Response.Redirect("ProductDetail.aspx?ProductId=" + productId);
        }
    }
}