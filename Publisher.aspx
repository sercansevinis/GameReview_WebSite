<%@ Page Title="Publisher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Publisher.aspx.cs" Inherits="WebApplication2.Publisher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>&nbsp;</h2>
    <table class="nav-justified">
        <tr>
            <td rowspan="6" style="width: 73px">
                <asp:Literal ID="ltrlImg" runat="server"></asp:Literal>
            </td>
            <td style="width: 134px">&nbsp;&nbsp; <b>Name:</b></td>
            <td>
                <asp:Label ID="lblPName" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Location:</b></td>
            <td>
                <asp:Label ID="lblPLoc" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Score:</b><td>
            <asp:Label ID="lblPScore" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Url for The Site:</b></td>
            <td>
                <asp:Label ID="lblPUrl" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <h2>Games:</h2>
        <p>
            <asp:Literal ID="ltrlGames" runat="server"></asp:Literal>
        </p>
<asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
</asp:Content>
