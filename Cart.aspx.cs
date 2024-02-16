using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static eCommerceProgettoS3L5.Index;

namespace eCommerceProgettoS3L5
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                List<Product> cart = Session["Cart"] as List<Product>;

                if (cart != null && cart.Count > 0)
                {                    
                    CartRepeater.DataSource = cart;
                    CartRepeater.DataBind();

                    decimal totalAmount = CalculateTotalAmount(cart);
                    totalAmountLabel.InnerText = totalAmount.ToString("0.00");
                }
                else
                {
                    emptyCartMessage.Visible = true;
                }
            }
        }

        private decimal CalculateTotalAmount(List<Product> cart)
        {
            decimal totalAmount = 0;
            foreach (var item in cart)
            {                
                totalAmount += item.Price;
            }
            return totalAmount;
        }
    }
}