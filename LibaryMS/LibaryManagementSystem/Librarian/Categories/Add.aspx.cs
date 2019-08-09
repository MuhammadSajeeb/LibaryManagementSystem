using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lms.Core.Models;

namespace LibaryManagementSystem.Librarian.Categories
{
    public partial class Add : System.Web.UI.Page
    {
        private readonly CategoriesManager _CategoriesManager = new CategoriesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoCodeGenerate();
                LoadCategories();
                IdHiddenField.Value = "";
                DeleteButton.Visible = false;
            }
        }
        public void AutoCodeGenerate()
        {
            decimal AlreadyExistData = _CategoriesManager.AlreadyExistData();
            int code = 000;
            if (AlreadyExistData>=1)
            {
                var GetLastCode = _CategoriesManager.GetLastCode();
                if(GetLastCode!=null)
                {
                    code = Convert.ToInt32(GetLastCode.Code);
                    code++;
                }
                txtCategoryCode.Text = code.ToString("000");
 
            }
            else
            {
                txtCategoryCode.Text = "001";
            }
        }
        public void LoadCategories()
        {
            CategoiresGridView.DataSource = _CategoriesManager.GetAll();
            CategoiresGridView.DataBind();
        }
        protected void AddButton_Click1(object sender, EventArgs e)
        {
            try
            {
                Category _Category = new Category();
                _Category.Code =(txtCategoryCode.Text);
                _Category.Name = txtCategoryName.Text;

                if(IdHiddenField.Value=="")
                {
                    int success = _CategoriesManager.Add(_Category);
                    if (success > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Saved Category');", true);

                        txtCategoryName.Text = "";
                        IdHiddenField.Value = "";
                        //Response.Redirect(Request.Url.AbsoluteUri);
                        AutoCodeGenerate();
                        LoadCategories();

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Saved Category');", true);
                    }
                }
                else
                {
                    int UpdateSuccess = _CategoriesManager.Update(_Category);
                    if(UpdateSuccess>0)
                    {
                         
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Update Category');", true);
                 
                        txtCategoryName.Text = "";
                        IdHiddenField.Value = "";
                        AutoCodeGenerate();
                        LoadCategories();
                        AddButton.Text = "Add";
                        DeleteButton.Visible = false;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed Update Category');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex.Message+"');", true);
            }
        }

        protected void CategoiresGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdHiddenField.Value = CategoiresGridView.SelectedRow.Cells[1].Text;
            txtCategoryCode.Text= CategoiresGridView.SelectedRow.Cells[1].Text;
            txtCategoryName.Text = CategoiresGridView.SelectedRow.Cells[2].Text;
            AddButton.Text = "Update";
            DeleteButton.Visible = true;
        }

        protected void CategoiresGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CategoiresGridView.PageIndex = e.NewPageIndex;
            LoadCategories();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Category _Category = new Category();
                _Category.Code = txtCategoryCode.Text;
                _Category.Name = txtCategoryName.Text;

                if (IdHiddenField.Value != "")
                {
                    int success = _CategoriesManager.Delete(_Category);
                    if (success > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successefully Delete Category');", true);
                         
                        txtCategoryName.Text = "";
                        IdHiddenField.Value = "";
                        AddButton.Text = "Add";
                        DeleteButton.Visible = false;
                        AutoCodeGenerate();
                        LoadCategories();

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed delete Category');", true);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}