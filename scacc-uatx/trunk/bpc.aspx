<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bpc.aspx.cs" Inherits="bpc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Id_Sala:
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
    </p>
    <p>
        Id_Computadora:
        <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" BackColor="Silver" BorderColor="Red" 
            Text="Eliminar" onclick="Button1_Click" />
    </p>
</asp:Content>

