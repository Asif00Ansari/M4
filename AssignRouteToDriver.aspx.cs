using FleetTrack.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FleetTrack
{
    public partial class AssignRouteToDriver : System.Web.UI.Page
    {
        clsAssignToDriver Dal = new clsAssignToDriver();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
                LoadddlVehicle();
                LoadddlSecurity();
                LoadddlRoute();
                LoadddlDriver();
                ClearAll();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            AssignToDriver obj = InitalizeObject();
            Dal.AddNewAssignToDriver(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            AssignToDriver obj = new AssignToDriver();
            obj = InitalizeObject();
            Dal.UpdateAssignToDriver(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            AssignToDriver obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteAssignToDriver(userId);
            LoadGrid();
            ClearAll();
        }
        private AssignToDriver InitalizeObject()
        {
            AssignToDriver obj = new AssignToDriver();
            obj.AssignToId = Convert.ToInt32(ViewState["userId"]);
            obj.STId = ddlST.SelectedValue != "" ? Convert.ToInt32(ddlST.SelectedValue) : 0;
            obj.RouteId = ddlRoute.SelectedValue != "" ? Convert.ToInt32(ddlRoute.SelectedValue) : 0;
            obj.DriverId = ddlDriver.SelectedValue != "" ? Convert.ToInt32(ddlDriver.SelectedValue) : 0;
            obj.VehicleId = ddlVehicle.SelectedValue != "" ? Convert.ToInt32(ddlVehicle.SelectedValue) : 0;

            return obj;
        }
        public void ClearAll()
        {
            ddlDriver.SelectedIndex = 0;
            ddlST.SelectedIndex = 0;
            ddlRoute.SelectedIndex = 0;
            ddlVehicle.SelectedIndex = 0;
            BtnSave.Enabled = true;
        }
        private void LoadGrid()
        {
            DataSet users = Dal.LoadAssignToDriver();
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = hdnCustomerId.Value = row.Cells[1].Text;
            ddlDriver.Items.Clear();
            ddlST.Items.Clear();
            ddlRoute.Items.Clear();
            ddlVehicle.Items.Clear();

            LoadddlVehicle();
            LoadddlSecurity();
            LoadddlRoute();
            LoadddlDriver();

            ddlDriver.SelectedItem.Text = row.Cells[2].Text;
            ddlST.SelectedItem.Text = row.Cells[5].Text;
            ddlRoute.SelectedItem.Text = row.Cells[4].Text;
            ddlVehicle.SelectedItem.Text = row.Cells[3].Text;


            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        private void LoadddlVehicle()
        {
            clsOrderes Dal = new clsOrderes();
            DataSet Manuf = Dal.Fillvehicle();
            ddlVehicle.DataTextField = "VehicleNumber";
            ddlVehicle.DataValueField = "VehicleId";
            ddlVehicle.DataSource = Manuf.Tables[0];
            ddlVehicle.DataBind();
            ddlVehicle.Items.Insert(0, new ListItem("--Select Vehicle--", string.Empty));
        }

        private void LoadddlDriver()
        {
            clsOrderes Dal = new clsOrderes();
            DataSet Manuf = Dal.Filldriver();
            ddlDriver.DataTextField = "FullName";
            ddlDriver.DataValueField = "UserId";
            ddlDriver.DataSource = Manuf.Tables[0];
            ddlDriver.DataBind();
            ddlDriver.Items.Insert(0, new ListItem("--Select Driver--", string.Empty));
        }

        private void LoadddlRoute()
        {
            clsOrderes Dal = new clsOrderes();
            DataSet Manuf = Dal.FillRoute();
            ddlRoute.DataTextField = "RouteNumber";
            ddlRoute.DataValueField = "RouteId";
            ddlRoute.DataSource = Manuf.Tables[0];
            ddlRoute.DataBind();
            ddlRoute.Items.Insert(0, new ListItem("--Select Route--", string.Empty));
        }

        private void LoadddlSecurity()
        {
            clsOrderes Dal = new clsOrderes();
            DataSet Manuf = Dal.FillST();
            ddlST.DataTextField = "SecurityTeamName";
            ddlST.DataValueField = "SecurityTeamId";
            ddlST.DataSource = Manuf.Tables[0];
            ddlST.DataBind();
            ddlST.Items.Insert(0, new ListItem("--Select Team--", string.Empty));
        }
    }
}