using StreetWatch.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StreetWatch.Authentication
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserHelper uhelper = new UserHelper();
        }

        protected void ButtonNewOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders/MakeOrder.aspx");
        }

        protected void ButtonMyOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders/MyOrders.aspx");
        }

        protected void ButtonFindJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders/NewJobs.aspx");
        }

        protected void ButtonJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders/MyJobs.aspx");
        }
    }
}