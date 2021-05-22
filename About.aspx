<%@ Page Title="Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>&nbsp;<asp:ImageButton ID="imgDelete" runat="server" Height="26px" ImageUrl="~/images/Icons/delete.png" OnClick="imgDelete_Click" Width="23px" />
    </h2>
    <table class="nav-justified" style="height: 140px">
        <tr>
            <td rowspan="7" style="width: 73px">
                <asp:Literal ID="ltrlImg" runat="server"></asp:Literal>
            </td>
            <td style="width: 134px">&nbsp;&nbsp; <b>Name:</b></td>
            <td>
                <asp:Literal ID="ltrlName" runat="server"></asp:Literal>
            &nbsp;
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Genres:</b></td>
            <td>
                <asp:Literal ID="ltrlGenres" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Platforms:</b></td>
            <td>
                <asp:Literal ID="ltrlPlatform" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Publisher:</b><td>
            <asp:Literal ID="ltrlPublisher" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px;">&nbsp;&nbsp; <b>Developer:</b></td>
            <td>
                <asp:Literal ID="ltrlDeveloper" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Release Date:</b></td>
            <td>
                <asp:Literal ID="ltrlDate" runat="server"></asp:Literal>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 134px">&nbsp;&nbsp; <b>Average Rate:</b></td>
            <td>
                <asp:Literal ID="ltrlRate" runat="server"></asp:Literal>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgUpdate" runat="server" Height="16px" ImageUrl="~/images/Icons/delete.png" OnClick="imgUpdate_Click" Width="16px" />
&nbsp;<asp:TextBox ID="txtUpgrade" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-warning btn-lg" Height="25px" Width="72px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <h2>All Comments:</h2>
        <p>
            <asp:Literal ID="ltrlContent" runat="server"></asp:Literal>
        </p>
    <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
<asp:Button ID="btnComment" runat="server" Height="26px" OnClick="Button1_Click" Text="Cmmnt" />
<asp:Button ID="btnClear" runat="server" OnClick="Button2_Click" style="height: 26px" Text="Clear" />
<asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
</asp:Content>