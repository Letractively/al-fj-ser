<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bsala.aspx.cs" Inherits="bsala" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        Id_Sala:
        <asp:TextBox ID="idbsala" runat="server" ></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="delete" runat="server" BackColor="Silver" BorderColor="Red" 
            Text="Eliminar" onclick="delete_Click" style="height: 26px" />
    </p>
</asp:Content>

