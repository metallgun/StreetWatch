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
    public partial class NewJob : System.Web.UI.Page
    {
        [WebMethod]
        public static string populateMap()
        {
            var uhelper = new UserHelper();
            var db = new Data.StreetWatchDataBaseEntities1();
            var query = db.Заказ.Where(x => x.Статус == 0 && x.IDПользователя != uhelper.CurrentUser.id)
                .OrderByDescending(x => x.IDЗаказа)
                .Take(100);
            List<Order> orderlist = new List<Order>();
            foreach (var c in query)
            {
                var k = c.Исполнение_заказа.Where(x => x.Заказ.IDЗаказа == c.IDЗаказа && x.Исполнитель.IDПользователя == uhelper.CurrentUser.id).Count();
                if (k > 0)
                { }
                else
                {
                    Order order = new Order();
                    order.Coord1 = float.Parse(c.Коорд1.Value.ToString());
                    order.Coord2 = float.Parse(c.Коорд2.Value.ToString());
                    order.IDorder = int.Parse(c.IDЗаказа.ToString());
                    orderlist.Add(order);
                }
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

        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void Do_Click(object sender, EventArgs e)
        {
            UserHelper uhelper = new UserHelper();
            UserServices uservices = new UserServices();
            user u = uhelper.CurrentUser;
            if (uservices.CheckExecutionerById(uhelper.CurrentUser.id) == false)
            {
                Executioner exec = new Executioner();
                exec.Id = uhelper.CurrentUser.id;
                exec.ready = 1;
                uservices.CreateExecutioner(exec);
            }
            Job j = new Job();
            j.ExecutorId = uhelper.CurrentUser.id;
            j.confirmDate = DateTime.Now;
            j.JobId = int.Parse(this.hiddenIdOrder.Value);
            j.Status = 0;
            j.executDate = DateTime.Now;
            JobService.NewJob(j);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }
    }
}