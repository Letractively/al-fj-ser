<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ApartarSala.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style5
        {
            font-size: medium;
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
                <asp:TextBox ID="tMatriculaAP" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <br />
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
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <span class="style5">Sesion Iniciada</span>
        <asp:Label ID="Label1" runat="server" 
            style="font-size: medium; font-family: 'Arial Alternative'"></asp:Label>
        &nbsp;<asp:Label ID="Label2" runat="server" 
            style="font-family: 'Arial Alternative'; font-size: medium"></asp:Label>
        &nbsp;<asp:Label ID="Label3" runat="server" 
            style="font-family: 'Arial Alternative'; font-size: medium"></asp:Label>
    </asp:Panel>
</asp:Content>
