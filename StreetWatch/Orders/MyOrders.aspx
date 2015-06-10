<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="StreetWatch.Orders.MyOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="toFulfilled" runat="server" Text="К выполненным" OnClick="toFulfilled_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif" Text="Все заказы"></asp:Label>
        <br />
        <br/>
    <asp:DataList runat="server" id="orderList" DataKeyField="IDЗаказа" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <ItemTemplate>
            IDЗаказа:
            <asp:Label ID="IDЗаказаLabel" runat="server" Text='<%# Eval("IDЗаказа") %>' />
            <br />
            Координата X:
            <asp:Label ID="Координата_XLabel" runat="server" Text='<%# Eval("[Координата X]") %>' />
            <br />
            Координата Y:
            <asp:Label ID="Координата_YLabel" runat="server" Text='<%# Eval("[Координата Y]") %>' />
            <br />
            Дата создания:
            <asp:Label ID="Дата_созданияLabel" runat="server" Text='<%# Eval("[Дата создания]") %>' />
            <br />
            Планируемая дата:
            <asp:Label ID="Планируемая_датаLabel" runat="server" Text='<%# Eval("[Планируемая дата]") %>' />
            <br />
            Комментарий:
            <asp:Label ID="КомментарийLabel" runat="server" Text='<%# Eval("Комментарий") %>' />
            <br />
            Важность:
            <asp:Label ID="ВажностьLabel" runat="server" Text='<%# Eval("Важность") %>' />
            <br />
            IDПользователя:
            <asp:Label ID="IDПользователяLabel" runat="server" Text='<%# Eval("IDПользователя") %>' />
            <br />
            Статус:
            <asp:Label ID="СтатусLabel" runat="server" Text='<%# Eval("Статус") %>' />
            <br />
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StreetWatchDataBaseConnectionString %>" SelectCommand="SELECT IDЗаказа, Коорд1 AS [Координата X], Коорд2 AS [Координата Y], ДатаСоздания AS [Дата создания], PlanDate AS [Планируемая дата], Комментарий, Urgent AS Важность, IDПользователя, Статус FROM Заказ WHERE (IDПользователя = @IDПользователя)">
            <SelectParameters>
                <asp:CookieParameter CookieName="id" Name="IDПользователя" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
