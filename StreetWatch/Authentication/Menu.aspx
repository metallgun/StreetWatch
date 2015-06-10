<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="StreetWatch.Authentication.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="ButtonNewOrder" runat="server" Text="Сделать заказ" OnClick="ButtonNewOrder_Click"/>
        <br />
        <br />
        <asp:Button ID="ButtonMyOrders" runat="server" Text="Мои заказы" OnClick="ButtonMyOrders_Click"/>
        <br />
        <br />
        <asp:Button ID="ButtonJobs" runat="server" Text="Выполняемые заявки" OnClick="ButtonJobs_Click"/>
        <br />
        <br />
        <asp:Button ID="ButtonFindJob" runat="server" Text="Все заявки" OnClick="ButtonFindJob_Click"/><br />
    </div>
    </form>
</body>
</html>
