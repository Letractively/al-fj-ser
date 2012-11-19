<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 100%;
            height: 111px;
        }
        .style5
        {
            width: 505px;
            height: 201px;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            color: #3399FF;
        }
        .style8
        {
            color: #0099FF;
        }
        .style9
        {
            height: 64px;
        }
        .style10
        {
            height: 201px;
        }
        .style11
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        .style14
        {
            width: 108px;
            height: 21px;
        }
        .style16
        {
            width: 113px;
        }
        .style17
        {
            width: 113px;
            height: 21px;
        }
        .style20
        {
            width: 108px;
        }
        .style21
        {
            width: 108px;
            height: 26px;
        }
        .style22
        {
            width: 113px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style4">
        <tr>
            <td class="style5">
                <asp:Panel ID="panRegister" runat="server">
                    <h2>Registrar</h2>
                    <table class="style11">
                        <tr>
                            <td class="style20">
                                Usuario:</td>
                            <td class="style16">
                                <asp:TextBox ID="tUser" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style21">
                                Password:</td>
                            <td class="style22">
                                <asp:TextBox ID="tPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                Nombre:</td>
                            <td class="style17">
                                <asp:TextBox ID="tNombre" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                Apellido Paterno:</td>
                            <td class="style16">
                                <asp:TextBox ID="taPaterno" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                Apellido Materno:</td>
                            <td class="style16">
                                <asp:TextBox ID="taMaterno" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                e-mail:</td>
                            <td class="style16">
                                <asp:TextBox ID="tEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                &nbsp;</td>
                            <td class="style16">
                                <asp:Button ID="bRegistrar" runat="server" onclick="bRegistrar_Click" 
                                    Text="Registrar" Width="141px" />
                                <br />
                                <br />
                                <asp:Label ID="statusRegister" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style10">
                <p>
                    <asp:Label ID="statusLogin" runat="server"></asp:Label>
                </p>
                <asp:Panel ID="panLogin" runat="server">
                <h2>Login</h2>
                    <table class="style4">
                        <tr>
                            <td class="style6">
                                <span class="style7">Usuario</span>:</td>
                            <td class="style6">
                                <asp:TextBox ID="userT" runat="server" Width="163px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Password:</td>
                            <td>
                                <asp:TextBox ID="passwordT" runat="server" Width="163px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                            </td>
                            <td style="margin-left: 40px" class="style9">
                                <asp:Button ID="bLogin" runat="server" 
                Text="Iniciar Sesion" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
    </table>
</asp:Content>

