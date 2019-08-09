using Lms.Core.Models;
using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Librarian.Categories
{
    public partial class ChangeStatus : System.Web.UI.Page
    {
        private readonly CategoriesManager _CategoriesManager = new CategoriesManager();
        string Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetDataByCode();
            }
        }
        public void GetDataByCode()
        {
            Code = Request.QueryString["Code"];

            var GetDataByCode = _CategoriesManager.GetDataByCode(Code);
            if (GetDataByCode != null)
            {
                txtCategoryCode.Text = GetDataByCode.Code.ToString();
                txtCategoryName.Text = GetDataByCode.Name.ToString();
                txtStatus.Text = GetDataByCode.Status.ToString();
                
                if(txtStatus.Text=="Running")
                {
                    StatusButton.Text = "Stop";
                }
                else
                {
                    StatusButton.Text = "Running";
                }
            }
            else
            {
                
            }

        }
        protected void StatusButton_Click(object sender, EventArgs e)
        {
            Category _Category = new Category();
            _Category.Code = (txtCategoryCode.Text);
            if (txtStatus.Text == "Running")
            {
                int SuccessRunning = _CategoriesManager.StopStatus(_Category);
                if(SuccessRunning>0)
                {
                    Response.Redirect("~/Librarian/Categories/Status.aspx");
                }
                
            }
            else
            {
                int SuccessStop = _CategoriesManager.RunningStatus(_Category);
                if (SuccessStop > 0)
                {
                    Response.Redirect("~/Librarian/Categories/Status.aspx");
                }
            }
        }
    }
}