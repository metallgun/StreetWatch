<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StreetWatch.Authentication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lbl1" runat="server" Text="Login"></asp:Label>
        <asp:TextBox ID="loginTb1" runat="server" style="margin-left: 101px" TextMode="Email"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="passTb1" runat="server" style="margin-left: 73px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="firstNameTb" runat="server" style="margin-left: 65px" Width="166px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Second Name"></asp:Label>
        <asp:TextBox ID="secondNameTb" runat="server" style="margin-left: 46px" Width="169px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Delegation"></asp:Label>
        <asp:DropDownList ID="delegationList" runat="server" style="margin-left: 70px">
            <asp:ListItem>Mr</asp:ListItem>
            <asp:ListItem>Mrs</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="submitBtn1" runat="server" Height="22px" Text="Submit" onClick="submitBtn1_Click"/>
    </div>
    </form>
</body>
</html>
