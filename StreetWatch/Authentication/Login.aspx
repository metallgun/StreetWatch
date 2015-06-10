<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StreetWatch.Authentication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
        <asp:TextBox ID="loginTb" runat="server" style="margin-left: 70px" TextMode="Email"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="passTb" runat="server" style="margin-left: 46px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="submitBtn" runat="server" Height="22px" Text="Submit" onClick="submitBtn_Click"/>
    
    </div>
    </form>
</body>
</html>
