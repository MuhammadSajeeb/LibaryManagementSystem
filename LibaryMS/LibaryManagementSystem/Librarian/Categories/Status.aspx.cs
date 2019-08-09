using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Librarian.Categories
{
    public partial class Status : System.Web.UI.Page
    {
        private readonly CategoriesManager _CategoriesManager = new CategoriesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadCategories();
            }
        }
        public void LoadCategories()
        {
            CategoiresGridView.DataSource = _CategoriesManager.GetAllWithStatus();
            CategoiresGridView.DataBind();
        }
        protected void CategoiresGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = CategoiresGridView.SelectedRow.Cells[1].Text;
            Response.Redirect("~/Librarian/Categories/ChangeStatus.aspx?code=" + code);
        }

        protected void CategoiresGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CategoiresGridView.PageIndex = e.NewPageIndex;
            LoadCategories();
        }
    }
}