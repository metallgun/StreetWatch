using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using StreetWatch.Service;
using StreetWatch.Classes;

namespace StreetWatch.Orders
{
    public partial class Find : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ok_Click(object sender, EventArgs e)
        {
            UserHelper uhelper = new UserHelper();
            user u = uhelper.CurrentUser;
            Classes.Order order = new Classes.Order();
            order.CreationDate = DateTime.Now;
            DateTime dt = new DateTime();
            dt = order.CreationDate.AddDays(3);
            order.PlanDate = dt;
            order.Coord1 = float.Parse(this.hiddenCoodrsX.Value.Replace('.', ','));
            order.Coord2 = float.Parse(this.hiddenCoordsY.Value.Replace('.', ','));
            order.Comment = this.comment.Text;
            if (this.urgent.Checked == true)
            {
                order.Urgent = 1;
            }
            else order.Urgent = 0;
            //статус обозначает выполненость заказа. 0 - невыполнен, 1 - выполнен
            order.Status = 0;
            Services.OrderService _orders = new Services.OrderService();
            _orders.NewOrder(uhelper.CurrentUser.id, order);
        }
    }
}