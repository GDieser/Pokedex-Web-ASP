<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="Pokedex.PokemonsLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons: </h1>

    <asp:gridview runat="server" id="dgvPokemon" cssClass="table" AutoGenerateColumns="false" >
        <Columns>   
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Tipo.Descripcion" />
        </Columns>
    </asp:gridview>

</asp:Content>
