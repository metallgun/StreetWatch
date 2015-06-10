<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeOrder.aspx.cs" Inherits="StreetWatch.Orders.Find" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>StreetWatch</title>
    <script src="http://api-maps.yandex.ru/2.1/?lang=ru_RU" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="StyleSheet" type="text/css" href="../css/Style.css"/>
    <script src="../js/JavaScript1.js" type="text/javascript"></script>
    <style type="text/css">
        .buttonMO {}
    </style>
</head>
<body>  
    <form id="formMakeOrder" runat="server">
    <asp:ScriptManager runat="server" AjaxFrameworkMode="Enabled"></asp:ScriptManager>
    <script type="text/javascript">
        var map = null;
        ymaps.ready(setup);

        function setup() {
            map = new ymaps.Map("mapContainer", {
                center: [55.76, 37.64],
                zoom: 7
            });
            map.events.add('click', mapClick);
        }

        function mapClick(e) {
                var coords = e.get('coords');
                var oForm = new sv_order();
                oForm.coords.lattitude = coords[0].toPrecision(6);
                oForm.coords.longitude = coords[1].toPrecision(6);
                oForm.planDate = new Date();
                oForm.planDate.setDate(oForm.planDate.getDate() + 3);
                showForm(oForm);
        };

        function showForm(obj_form) {
            coords.innerHTML = obj_form.coords.lattitude + " " + obj_form.coords.longitude;
            var x = $get('<%= this.hiddenCoodrsX.ClientID%>');
            var y = $get('<%= this.hiddenCoordsY.ClientID%>');
            var dt = $get('<%= this.hiddenDateTime.ClientID%>');
            x.value = obj_form.coords.lattitude;
            y.value = obj_form.coords.longitude;
            dt.value = dateToStr(obj_form.planDate);
            //orderDate.value = obj_form.planDate;
            orderDate.innerHTML = obj_form.planDate;
            orderForm.style.display = "";
        };

        function padStr(i)
        {
            return (i < 10) ? "0" + i : "" + i;
        }

        function dateToStr(dt)
        {
            return (dt.getFullYear() + padStr(dt.getMonth()) + padStr(dt.getDate()) + padStr(dt.getHours()) + padStr(dt.getMinutes()));
        }

    </script>

    <header>
    <p class="title">StreetWatch
    </p>
    </header>
   
    <div id="mapContainer"></div>
    <div style="display:none;" id="orderForm">
        <p>Координаты: </p> <div class="data" id="coords"></div>
        <!--<p>Дата выполнения заказа <input id="orderDate" type="text" /></p> :-->
        <asp:HiddenField runat="server" id="hiddenCoodrsX"></asp:HiddenField>
        <asp:HiddenField runat="server" id="hiddenCoordsY"></asp:HiddenField>
        <asp:HiddenField runat="server" id="hiddenDateTime"></asp:HiddenField>
        <p>Дата выполнения заказа: </p> <div class="data" id="orderDate" ></div>
        <p>Срочность: <asp:CheckBox id="urgent" runat="server" /></p>
        <p>Комментарий:<asp:TextBox TextMode="MultiLine" id="comment" Columns="30" Rows="3" runat="server"></asp:TextBox></p>
        <asp:Button runat="server" CssClass="button" ID="ok" Text="OK" OnClick="ok_Click"></asp:Button>
        <asp:Button runat="server" CssClass="button" id="cancel" Text="Cancel"></asp:Button>
    </div>
        </form>
</body>
</html>