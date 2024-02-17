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
                        new Index.Product 
                        { 
                            ProductID = "1", 
                            ImagePath = ResolveUrl("~/Images/image1.jpg"), 
                            Name = "GeForce RTX 4090", 
                            Description = "NVIDIA® GeForce RTX™ 4090 è la GPU GeForce definitiva. Si tratta di un enorme passo avanti in termini di prestazioni, efficienza e grafica basata su IA. Scopri il gaming ad altissime prestazioni, mondi virtuali incredibilmente dettagliati, produttività senza precedenti e nuovi modi di creare. Basata sull'architettura NVIDIA Ada Lovelace e include 24 GB di memoria G6X per offrire l'esperienza definitiva per giocatori e creativi.", 
                            Price = 1000.00m },
                        new Index.Product 
                        { 
                            ProductID = "2", 
                            ImagePath = ResolveUrl("~/Images/image2.jpg"), 
                            Name = "GeForce RTX 4070 Ti", 
                            Description = "La GeForce RTX 4070 Ti è una scheda grafica di NVIDIA, lanciata il 3 gennaio 2023. Costruita con processo a 5 nm e basata sul processore grafico AD104, nella sua variante AD104-400-A1, la scheda supporta DirectX 12. Ciò garantisce che tutti i giochi moderni funzionino su GeForce RTX 4070 Ti. Inoltre, la funzionalità DirectX 12 Ultimate garantisce il supporto per raytracing hardware, shading a velocità variabile e altro ancora nei prossimi videogiochi.", 
                            Price = 900.00m },
                        new Index.Product 
                        { 
                            ProductID = "3", 
                            ImagePath = ResolveUrl("~/Images/image3.jpg"), 
                            Name = "GeForce RTX 4080", 
                            Description = "Potenzia il tuo PC con NVIDIA® GeForce RTX™ 4080 SUPER e RTX 4080. Dai vita ai tuoi giochi e progetti creativi con la grafica accelerata basata su ray-tracing e IA. Le schede grafiche si basano sull'architettura ultra efficiente NVIDIA Ada Lovelace, con 16 GB di memoria G6X super veloce.", 
                            Price = 950.00m },
                        new Index.Product 
                        {
                            ProductID = "4", 
                            ImagePath = ResolveUrl("~/Images/image4.jpg"), 
                            Name = "GeForce RTX 3060", 
                            Description = "GeForce RTXTM 3060 Ti e RTX 3060 permettono di sfruttare i giochi più recenti con la potenza di Ampere, l'architettura NVIDIA RTX di seconda generazione. Prestazioni incredibili con ray-tracing Core migliorati e Tensor Core, nuovi multiprocessori di streaming e memoria ad alta velocità.", 
                            Price = 50.00m },
                        new Index.Product 
                        { 
                            ProductID = "5", 
                            ImagePath = ResolveUrl("~/Images/image5.jpg"), 
                            Name = "AMD Radeon RX 6650 XT", 
                            Description = "Radeon RX 6650 XT è dotata di 8 GB di memoria GDDR6, su bus a 128 bit con una frequenza di clock di 16 Gbps per una bandwidth complessiva di 256 GB/s. La GPU Navi 23 opera con una frequenza di base clock di 2410 MHz, potendosi spingere sino a 2635 MHz come frequenza di clock massima. ", 
                            Price = 200.00m },
                        new Index.Product 
                        { 
                            ProductID = "6", 
                            ImagePath = ResolveUrl("~/Images/image6.jpg"), 
                            Name = "AMD Radeon RX 580", 
                            Description = "La scheda Radeon RX 580 di AMD è stata introdotta sul mercato nel 2017, usa una GPU Polaris 20 con 5,7 miliardi di transistor ed è basata su architettura GCN 4.0. Mette a disposizione un totale di 2304 stream processor, abbinati a 144 TMU e 32 ROPs. La scheda è dotata di 4/8GB di memoria GDDR5, su bus a 256 bit. La memoria opera a 8000MHz.", 
                            Price = 400.00m },
            };

            return products;
        }

        private void AddProductToCart(Product product)
        {
            List<Product> cart = Session["Cart"] as List<Product> ?? new List<Product>();

            cart.Add(product);

            Session["Cart"] = cart;
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                string productId = Request.QueryString["ProductId"];

                List<Product> products = GetProducts(); 
                Product selectedProduct = products.FirstOrDefault(p => p.ProductID == productId);                

                if (selectedProduct != null)
                {
                    AddProductToCart(selectedProduct);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}