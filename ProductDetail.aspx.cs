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
            // Recupera l'ID del prodotto dall'URL
            string productId = Request.QueryString["ProductId"];

            if (string.IsNullOrEmpty(productId))
            {
                // ID del prodotto non trovato
                Response.Redirect("Index.aspx");
                return;
            }

            // Recupera i prodotti dal carrello
            List<Product> cart = Session["Cart"] as List<Product>;

            // Cerca il prodotto nella lista in base all'ID
            Product selectedProduct = cart?.FirstOrDefault(p => p.ProductID == productId);

            if (selectedProduct == null)
            {
                // Prodotto non trovato nel carrello
                Response.Redirect("Index.aspx");
                return;
            }

            // Imposta i dettagli del prodotto
            ImagePath.ImageUrl = selectedProduct.ImagePath;
            NameLabel.Text = selectedProduct.Name;
            PriceLabel.Text = $"Prezzo: €{selectedProduct.Price}";
            ExtendedDescriptionLabel.Text = selectedProduct.Description;
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            // Reindirizza alla pagina del carrello per gestire l'aggiunta
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}