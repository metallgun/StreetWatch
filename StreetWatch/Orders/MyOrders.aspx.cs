﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StreetWatch.Orders
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void toFulfilled_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Orders/FulFilledOrders.aspx");
        }
    }
}