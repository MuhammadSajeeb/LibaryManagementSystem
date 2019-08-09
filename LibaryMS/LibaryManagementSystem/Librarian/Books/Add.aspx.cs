using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Librarian.Books
{
    public partial class Add1 : System.Web.UI.Page
    {
        private readonly CategoriesManager _CategoriesManager = new CategoriesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllCategories();
            }
        }

        public void GetAllCategories()
        {
            CategoryDropDownList.DataSource = _CategoriesManager.GetAll();
            CategoryDropDownList.DataTextField = "Name";
            CategoryDropDownList.DataValueField = "Code";
            CategoryDropDownList.DataBind();

            CategoryDropDownList.Items.Insert(0, new ListItem("Chose Category", "0"));
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}