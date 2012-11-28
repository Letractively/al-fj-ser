<%@ Page Title="Cerrar Sesiones - Administador" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="cerrarSesionesAlumnoComputadora.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 211px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Cerrar Sesiones Alumnos en Centro de Computo</h2>
    <asp:Panel ID="pCerrarSesiones" runat="server">
        <table class="style4">
            <tr>
                <td class="style5">
                    Cerrar Sesion de Alumno<br />
                    <br />
                    SALA
                </td>
                <td>
                    <br />
                    <br />
                    Computadora</td>
                <td>
                    <br />
                    <br />
                    Alumno usando Maquina</td>
                <td>
                    &nbsp;
                    <asp:Button ID="bCerrarSesiones" runat="server" 
                        Text="Cerrar Todas las Sesiones:" Width="160px" 
                        onclick="bCerrarSesiones_Click" />
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:ListBox ID="selectSala" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="selectSala_SelectedIndexChanged" Width="50px">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:DropDownList ID="listComputadora" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="listComputadora_SelectedIndexChanged" 
                        style="margin-top: 0px">
                    </asp:DropDownList>
                </td>
                <td>
                    <br />
                    <asp:Label ID="lAlumno" runat="server" 
                        style="font-family: 'Perpetua Titling MT'; font-size: medium"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="statusS" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="statusCTS" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <br />
                    <asp:Button ID="cerrarSesionAlumno" runat="server" Text="Cerrar Sesion" 
                        onclick="cerrarSesionAlumno_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
