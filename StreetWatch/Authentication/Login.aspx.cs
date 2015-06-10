using StreetWatch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StreetWatch.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            var login = this.loginTb.Text;
            var ppw = this.passTb.Text;

            UserServices service = new UserServices();

            Enc encoder = new Enc();
            ppw = encoder.Encode(ppw, "myhse!");
            Classes.user result = service.LogonUser(login, ppw);

            HttpCookie authcoockie = new HttpCookie("id");
            HttpCookie sessioncoockie = new HttpCookie("session");

            if (result != null)
            {
                authcoockie.Value = result.id + "";
                sessioncoockie.Value = result.userSession.code;

                Response.SetCookie(authcoockie);
                Response.SetCookie(sessioncoockie);

                Response.Redirect("~/Authentication/Menu.aspx");
            }
            else
            {
                authcoockie.Value = "-1";
                sessioncoockie.Value = "";
                Response.SetCookie(authcoockie);
                Response.SetCookie(sessioncoockie);
            }
        }
    }
}