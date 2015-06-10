<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewJobs.aspx.cs" Inherits="StreetWatch.Orders.NewJob" %>

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
    <form id="formNewJobs" runat="server">
    <asp:ScriptManager runat="server" AjaxFrameworkMode="Enabled" ID="manager" EnablePageMethods="true" EnablePartialRendering="true"></asp:ScriptManager>
    <script type="text/javascript">

        var map = null;

        ymaps.ready(setup);

        function setup() {
            map = new ymaps.Map("mapContainer", {
                center: [55.76, 37.64],
                zoom: 7
            });
            getOrders();
        }

        function getOrders() {
            PageMethods.populateMap(onGetOrders);
        }

        function onPlacemarkClick(id) {
            detailsForm.style.display = "";
            PageMethods.populateDiv(id,onGetJob);
        }

        function onGetJob(result)
        {
            var thisOrder = JSON.parse(result);
            var y = $get('<%= this.hiddenIdOrder.ClientID%>');
            y.value = thisOrder[0].IDorder;
            coords.innerHTML = thisOrder[0].Coord1 + "; " + thisOrder[0].Coord2;
            date.innerHTML = thisOrder[0].PlanDateStr;
            if (thisOrder[0].Urgent == 1)
                urgent.innerHTML = "Срочный заказ"
            else urgent.innerHTML = "Несрочный заказ";
            var x = $get('<%= this.hiddenUrgent.ClientID%>');
            x.value = thisOrder[0].Urgent;
            commentary.innerHTML = thisOrder[0].Comment;
        }

        function onGetOrders(result) {
            var ordersArray = JSON.parse(result);
            for (var i = 0; i < ordersArray.length; i++)
            {
                var x = ordersArray[i].Coord1;
                var y = ordersArray[i].Coord2;
                var id = ordersArray[i].IDorder;
                var myPlacemark = new ymaps.Placemark([x, y]);
                myPlacemark.id_order = id;
                (function (id_) {
                    myPlacemark.events.add('click',function () {
                        onPlacemarkClick(id_, myPlacemark.id_order);
                    });
                })(id);

                map.geoObjects.add(myPlacemark);
            }
        }    
        </script>

    <header>
    <p class="title">StreetWatch</p>
    </header>
    
    <div id="mapContainer"></div>
    <div style="display:none; position: absolute; padding-left:10px; width: 230px; height: auto; top: 20px; right: 50px; background-color:white;" id="detailsForm">
        <p>Координаты: </p> <div class="data" id="coords"></div>
        <p>Дата ожидания заказа: </p><div class="data" id="date"></div>
        <asp:HiddenField runat="server" id="hiddenIdOrder"></asp:HiddenField>
        <p>Срочность:</p> <asp:Label runat="server" id="urgent" />
        <asp:HiddenField runat="server" id="hiddenUrgent"></asp:HiddenField>
        <p>Комментарий: </p><div class="data" id="commentary" runat="server"></div>
        <asp:Button runat="server" CssClass="button" ID="Do" Text="DO!" OnClick="Do_Click"></asp:Button>
        <asp:Button runat="server" CssClass="button" id="cancel" Text="Cancel" OnClick="cancel_Click"></asp:Button>
    </div>
   </form>
</body>
</html>
