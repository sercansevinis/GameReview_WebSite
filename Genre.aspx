<%@ Page Title="Genre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Genre.aspx.cs" Inherits="WebApplication2.Genre" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>&nbsp;</h2>
    <table class="nav-justified">
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Name:</b></td>
            <td>
                <asp:Label ID="lblGName" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Score:</b></td>
            <td>
                <asp:Label ID="lblGScore" runat="server" Text="Label"></asp:Label>
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
