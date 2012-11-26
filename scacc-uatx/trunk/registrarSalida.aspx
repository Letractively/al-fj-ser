<%@ Page Title="Registrar Salida" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="registrarSalida.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 500px;
        }
        .style6
        {
            width: 108px;
        }
        .style7
        {
            width: 108px;
            height: 29px;
        }
        .style8
        {
            width: 500px;
            height: 29px;
        }
        .style9
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Registrar Salida</h2>
    <table class="style4">
        <tr>
            <td class="style7">
                Matricula</td>
            <td class="style8">
                <asp:TextBox ID="tMatriculaSalida" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="statusSalida" runat="server"></asp:Label>
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                <br />
                <asp:Button ID="bRegistrarSalida" runat="server" 
                    onclick="bRegistrarSalida_Click" Text="Regstrar Salida" />
            &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
