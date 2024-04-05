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
    public partial class updateStatus : System.Web.UI.Page
    {
        clsUpdateStatus Dal = new clsUpdateStatus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
                LoadStatus();
             
                ClearAll();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UpdateStatus1 obj = InitalizeObject();
            Dal.AddNewupdateStatus(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateStatus1 obj = new UpdateStatus1();
            obj = InitalizeObject();
            Dal.updateStatus(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            UpdateStatus1 obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteupdateStatus(userId);
            LoadGrid();
            ClearAll();
        }
        private UpdateStatus1 InitalizeObject()
        {
            UpdateStatus1 obj = new UpdateStatus1();
            obj.AssignToId = Convert.ToInt32(ViewState["userId"]);
            obj.Status = ddlStatus.SelectedValue != "" ? ddlStatus.SelectedItem.Text.ToString() : null;
            
            return obj;
        }
        public void ClearAll()
        {
            ddlStatus.SelectedIndex = 0;
          
        }
        private void LoadGrid()
        {
            DataSet users = Dal.LoadStatus1(Convert.ToInt32(Session["UserId"]));
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = hdnCustomerId.Value = row.Cells[1].Text;
            ddlStatus.Items.Clear();
         

            LoadStatus();
            

            ddlStatus.SelectedItem.Text = row.Cells[6].Text;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        private void LoadStatus()
        {
            clsOrderes Dal = new clsOrderes();
            DataSet Manuf = Dal.FillStatus();
            ddlStatus.DataTextField = "ParcelStatusName";
            ddlStatus.DataValueField = "ParcelStatusId";
            ddlStatus.DataSource = Manuf.Tables[0];
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--Select Status--", string.Empty));
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {





                if (e.Row.Cells[6].Text == "On destinaiton")//orderstatus index
                {


                    e.Row.Enabled = false;
                }

                else
                {

                    e.Row.Enabled = true;

                }

            }
        }

    }
}