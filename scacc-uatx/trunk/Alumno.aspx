<%@ Page Title="Alumno" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Alumno.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Alumno
    </h2>
    <p>
        
    </p>
<asp:Menu ID="Menu1" runat="server">
    <Items>
        <asp:MenuItem NavigateUrl="~/ApartaComputadora.aspx" Text="Aparta Computadora" 
            Value="Aparta Computadora"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/registrarSalida.aspx" Text="Registrar Salida" 
            Value="Registrar Salida"></asp:MenuItem>
    </Items>
</asp:Menu>
</asp:Content>
