<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="sala.aspx.cs" Inherits="sala" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    Id_sala:
    <asp:TextBox ID="name" runat="server" ></asp:TextBox>
    <br />
    <br />
    Capacidad:
    <asp:TextBox ID="capa" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="save" runat="server" Text="Guardar" onclick="save_Click" 
        BackColor="Silver" BorderColor="Red" />
    <br />
</asp:Content>

