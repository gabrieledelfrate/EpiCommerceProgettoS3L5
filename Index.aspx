<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="eCommerceProgettoS3L5.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <h2>Prodotti in offerta</h2>
        <div class="row">
            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card mb-4 shadow-sm">
                            <img class="card-img-top" src='<%# Eval("ImagePath") %>' alt='<%# Eval("Name") %>'>
                            <div class="card-body">
                                <h4 class="card-title"><%# Eval("Name") %></h4>
                                <p class="card-text"><%# Eval("Description") %></p>
                                <p class="card-text">Prezzo: €<%# Eval("Price") %></p>
                                <asp:Button runat="server" ID="AddToCartButton" Text="Aggiungi al carrello" CssClass="btn btn-primary" OnClick="AddToCartButton_Click" CommandArgument='<%# Eval("ProductID") + "|" + Eval("Name") + "|" + Eval("Price") %>' />
                                <button class="btn btn-warning">Vedi dettagli</button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
