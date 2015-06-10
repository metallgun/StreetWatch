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
    public partial class MyJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string populateMap()
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var uhelper = new UserHelper();
            var userid = uhelper.CurrentUser.id;
            var query = db.Исполнение_заказа.Where(x => x.IDИсполнителя == userid && x.СделаноНесделано == 0)
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
            var query = db.Заказ.Where(x => x.IDЗаказа == orderId);
            List<Order> orderlist = new List<Order>();
            foreach (var c in query)
            {
                Order order = new Order();
                order.Coord1 = float.Parse(c.Коорд1.Value.ToString());
                order.Coord2 = float.Parse(c.Коорд2.Value.ToString());
                order.CreationDateStr = c.ДатаСоздания.Value.ToString();
                order.PlanDateStr = c.PlanDate.Value.ToString();
                order.IDorder = int.Parse(c.IDЗаказа.ToString());
                order.IDuser = int.Parse(c.IDПользователя.Value.ToString());
                order.Urgent = int.Parse(c.Статус.Value.ToString());
                order.Comment = c.Комментарий.ToString();
                orderlist.Add(order);
            }
            string jsonString = orderlist.ToJSON();
            return jsonString;
        }

        protected void submitPhoto_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            var uhelper = new UserHelper();
            result.executorId = uhelper.CurrentUser.id;
            result.orderId = int.Parse(this.hiddenIdOrder.Value);
            result.photoComment = this.photoComment.Text;
            result.photoLink = this.photoLinkTb.Text;
            JobService.FulfillJob(result);
        }
    }
}