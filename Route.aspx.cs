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
    public partial class Route : System.Web.UI.Page
    {
        clsRoute Dal = new clsRoute();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
                ClearAll();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Router obj = InitalizeObject();
            Dal.AddNewRoute(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Router obj = new Router();
            obj = InitalizeObject();
            Dal.UpdateRoute(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Router obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteRoute(userId);
            LoadGrid();
            ClearAll();
        }
        private Router InitalizeObject()
        {
            Router obj = new Router();
            obj.RouteId = Convert.ToInt32(ViewState["userId"]);
            obj.Address = txtAddress.Text;

            obj.RouteName = txtRouteName.Text;

            return obj;
        }
        public void ClearAll()
        {
            txtRouteName.Text = string.Empty;
            txtAddress.Text = "";
            BtnSave.Enabled = true;
        }
        private void LoadGrid()
        {
            DataSet users = Dal.LoadRoute();
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = hdnCustomerId.Value = row.Cells[1].Text;

            txtRouteName.Text = row.Cells[2].Text;

            txtAddress.Text = row.Cells[3].Text;
            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}