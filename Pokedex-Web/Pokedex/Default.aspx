<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola
    </h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <!--
        <%
            foreach (Dominio.Pokemon poke in ListaPokemon)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="<%:poke.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:poke.Nombre %></h5>
                    <p class="card-text"><%:poke.Descripcion %></p>
                    <a href="Detalles.aspx?id=<%:poke.Id %>" class="btn-primary">Ver detalles</a>
                </div>
            </div>
        </div>

        <%}%>-->

        <asp:Repeater runat="server" ID="rptRepeater">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="Detalles.aspx?id=<%#Eval("Id ") %>" class="btn-primary">Ver detalles</a>
                            <asp:Button Text="Elegir" CssClass="btn-primary" ID="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </div>
</asp:Content>
