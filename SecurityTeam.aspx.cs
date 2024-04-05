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
    public partial class SecurityTeam : System.Web.UI.Page
    {
        clsSecurityTeam Dal = new clsSecurityTeam();
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
            ST obj = InitalizeObject();
            Dal.AddNewST(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            ST obj = new ST();
            obj = InitalizeObject();
            Dal.UpdateST(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            ST obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteST(userId);
            LoadGrid();
            ClearAll();
        }
        private ST InitalizeObject()
        {
            ST obj = new ST();
            obj.SecurityTeamId = Convert.ToInt32(ViewState["userId"]);
            obj.NoOfGuards = Convert.ToInt32(NoOfGuards.Text);

            obj.SecurityTeamName = txtSTName.Text;

            return obj;
        }
        public void ClearAll()
        {
            txtSTName.Text = string.Empty;
            NoOfGuards.Text = "";
            BtnSave.Enabled = true;
        }
        private void LoadGrid()
        {
            DataSet users = Dal.LoadST();
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = hdnCustomerId.Value = row.Cells[1].Text;

            txtSTName.Text = row.Cells[2].Text;

            NoOfGuards.Text = row.Cells[3].Text;
            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}