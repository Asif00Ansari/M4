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
    public partial class Customer : System.Web.UI.Page
    {
        clsCustomer Dal = new clsCustomer();
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
            Customers obj = InitalizeObject();
            Dal.AddNewCustomer(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj = InitalizeObject();
            Dal.UpdateCustomer(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Customers obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteCustomer(userId);
            LoadGrid();
            ClearAll();
        }
        private Customers InitalizeObject()
        {
            Customers obj = new Customers();
            obj.CustomerId = Convert.ToInt32(ViewState["userId"]);
            obj.Address = txtAddress.Text;

            obj.CustomerName = txtFullName.Text;

            return obj;
        }
        public void ClearAll()
        {
            txtFullName.Text = string.Empty;
            txtAddress.Text = "";
            BtnSave.Enabled = true;
        }
        private void LoadGrid()
        {
            DataSet users = Dal.LoadCustomer();
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = hdnCustomerId.Value = row.Cells[1].Text;

            txtFullName.Text = row.Cells[2].Text;

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