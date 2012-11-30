<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="computadoras.aspx.cs" Inherits="computadoras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Id_computadora:
        <asp:TextBox ID="idpc" runat="server"></asp:TextBox>
    </p>
    <p>
        Id_sala:
        <asp:TextBox ID="idsala" runat="server" ></asp:TextBox>
    </p>
    <p>
        Disponibilidad:
        <asp:DropDownList ID="disponibledrop" runat="server">
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="0">No</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Habilitar:
        <asp:DropDownList ID="DropDownList1" runat="server" >
            <asp:ListItem Value="1">Si</asp:ListItem>
            <asp:ListItem Value="0">No</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="save" runat="server" Text="Guardar" onclick="save_Click" 
            BackColor="Silver" BorderColor="Red" />
    </p>
</asp:Content>

