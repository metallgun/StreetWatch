using StreetWatch.Classes;
using StreetWatch.Service;
using StreetWatch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StreetWatch.Orders
{
    public partial class FulfilledOrders : System.Web.UI.Page
    {
        [WebMethod]
        public static string populateMap()
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var uhelper = new UserHelper();
            var userid = uhelper.CurrentUser.id;
            var query = db.Исполнение_заказа.Where(x=> x.Заказ.IDПользователя == userid && x.СделаноНесделано==1)
                .OrderByDescending(x => x.IDЗаказа)
                .Take(100);
            List<Order> orderlist = new List<Order>();
            foreach (var c in query)
            {
                Order order = new Order();
                order.Coord1 = float.Parse(c.Заказ.Коорд1.Value.ToString());
                order.Coord2 = float.Parse(c.Заказ.Коорд2.Value.ToString());
                order.IDorder = int.Parse(c.IDЗаказа.ToString());
                orderlist.Add(order);
            }
            string jsonString = orderlist.ToJSON();
            return jsonString;
        }

        [WebMethod]
        public static string populateDiv(int orderId)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var c = db.Заказ.Where(x => x.IDЗаказа == orderId).First();
                Order order = new Order();
                Result res = new Result();
                order.Coord1 = float.Parse(c.Коорд1.Value.ToString());
                order.Coord2 = float.Parse(c.Коорд2.Value.ToString());
                order.CreationDateStr = c.ДатаСоздания.Value.ToString();
                order.PlanDateStr = c.PlanDate.Value.ToString();
                order.IDorder = int.Parse(c.IDЗаказа.ToString());
                order.IDuser = int.Parse(c.IDПользователя.Value.ToString());
                order.Urgent = int.Parse(c.Статус.Value.ToString());
                order.Comment = c.Комментарий.ToString();
                order.Status = int.Parse(c.Статус.Value.ToString());
                var finder = db.ДеталиРезультата.Where(x => x.IDЗаказа == orderId).First();
                res.photoLink = finder.Фото.ПутьКФото;
                res.photoComment = finder.КомментКФотке;
                order.result = res;
            string jsonString = order.ToJSON();
            return jsonString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void payOrder_Click(object sender, EventArgs e)
        {
            OrderService.payForOrder(int.Parse(this.hiddenIdOrder.Value));
        }
    }
}