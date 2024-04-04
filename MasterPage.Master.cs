using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FleetTrack
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect("Login.aspx");
            else
                loginuser.Text = Convert.ToString(Session["FullName"]) + "" + (Convert.ToInt32(Session["IsAdmin"]) == 1 ? "(Admin)" : "(Driver)") + "";
            if (Convert.ToInt32(Session["IsAdmin"]) != 1)
            {
                userType.InnerText = "Driver";
            }
            if (Convert.ToInt32(Session["IsAdmin"]) == 0)
            {
                user.Visible = false;

                customer.Visible = false;

                Route.Visible = false;

                SecurityTeam.Visible = false;

                AssignRouteToDriver.Visible = false;

                updateStatus.Visible = true;

            }
            else if (Convert.ToInt32(Session["IsAdmin"]) == 1)
            {
                updateStatus.Visible = false;
            }

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}