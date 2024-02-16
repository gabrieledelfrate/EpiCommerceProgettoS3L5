<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="eCommerceProgettoS3L5.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Il tuo Carrello</h2>
    <div class="row">
        <asp:Repeater ID="CartRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <div class="card-body">
                            <h4 class="card-title"><%# Eval("Name") %></h4>
                            <p class="card-text">Prezzo: $<%# Eval("Price") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="text-right">
        <h4>Totale: $<span runat="server" id="totalAmountLabel"></span></h4>
        <asp:Label runat="server" ID="emptyCartMessage" Visible="false" Text="Il carrello è vuoto." CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>