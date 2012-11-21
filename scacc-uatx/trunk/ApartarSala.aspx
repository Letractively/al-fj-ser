<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ApartarSala.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Apartar Sala</h2>
    <table class="style4">
        <tr>
            <td>
                Seleccionar Sala</td>
            <td>
                Seleccionar Equipo</td>
            <td>
                Matricula:
                <br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="statusMaquina" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="listSala" runat="server" AutoPostBack="True" Height="78px" 
                    onselectedindexchanged="listSala_SelectedIndexChanged1" Width="92px">
                </asp:ListBox>
            </td>
            <td>
                <asp:DropDownList ID="listComputadora" runat="server" Height="28px" 
                    Width="94px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="bRegistrar" runat="server" onclick="bRegistrar_Click" 
                    Text="Registrar Entrada" />
            </td>
        </tr>
    </table>
</asp:Content>
