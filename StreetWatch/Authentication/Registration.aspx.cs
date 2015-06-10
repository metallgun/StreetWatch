using StreetWatch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StreetWatch.Authentication
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn1_Click(object sender, EventArgs e)
        {
            var login = this.loginTb1.Text;
            var ppw = this.passTb1.Text;
            var fname = this.firstNameTb.Text;
            var sname = this.secondNameTb.Text;
            var delegation = this.delegationList.Text;


            UserServices service = new UserServices();

            Enc encoder = new Enc();
            int idu;
            ppw = encoder.Encode(ppw, "myhse!");
            service.CreateUser(login, ppw, sname, fname, delegation, out idu);
        }
    }
}