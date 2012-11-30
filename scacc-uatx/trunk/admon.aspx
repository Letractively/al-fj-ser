<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="admon.aspx.cs" Inherits="admon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Altas" Value="Altas">
                <asp:MenuItem Text="Sala" Value="Sala" NavigateUrl="~/sala.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Computadora" Value="Computadora" NavigateUrl="~/computadoras.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Bajas" Value="Bajas">
                <asp:MenuItem Text="Sala" Value="Sala" NavigateUrl="~/bsala.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Computadora" Value="Computadora" NavigateUrl="~/bpc.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Apartar_Sala" Value="Apartar_Sala" NavigateUrl="~/apartar.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Generar Reporte" Value="Apartar_Sala" NavigateUrl="~/Reporte.aspx"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>

