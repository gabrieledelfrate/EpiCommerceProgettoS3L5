<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="eCommerceProgettoS3L5.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container">
            <h2>Dettagli Prodotto</h2>
            <div class="card mb-4 shadow-sm">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Image runat="server" ID="ProductImage" CssClass="card-img-top" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-body" id="product-details">
                            <asp:Label runat="server" class="card-title" ID="ProductNameLabel"></asp:Label>
                            <asp:Label runat="server" class="card-text" ID="ProductPriceLabel"></asp:Label>
                            <asp:Label runat="server" class="card-text" ID="ProductDescriptionLabel"></asp:Label>
                            <asp:Button runat="server" ID="AddToCartButton" Text="Aggiungi al carrello" CssClass="btn btn-primary" OnClick="AddToCartButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
