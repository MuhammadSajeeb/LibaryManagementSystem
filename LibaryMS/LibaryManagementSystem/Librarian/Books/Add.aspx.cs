using Lms.Core.Models;
using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Librarian.Books
{
    public partial class Add1 : System.Web.UI.Page
    {
        private readonly BooksManager _BooksManager = new BooksManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllCategories();
            }
        }

        public void GetAllCategories()
        {
            CategoryDropDownList.DataSource = _BooksManager.GetAll();
            CategoryDropDownList.DataTextField = "Name";
            CategoryDropDownList.DataValueField = "Code";
            CategoryDropDownList.DataBind();

            CategoryDropDownList.Items.Insert(0, new ListItem("Chose Category", "0"));
        }
        public void Clear()
        {
            txtBookName.Text = "";
            txtBookAuthorName.Text = "";
            txtBookQty.Text = "";
            CategoryDropDownList.ClearSelection();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFileUpload.SaveAs(Server.MapPath("~/Librarian/Books/BookImages") + Path.GetFileName(ImageFileUpload.FileName));
                String GetImagePath = "~/Librarian/Books/BookImages" + Path.GetFileName(ImageFileUpload.FileName);

                Book _Book = new Book();
                _Book.Name = txtBookName.Text;
                _Book.AuthorName = txtBookAuthorName.Text;
                _Book.AvailableQty = Convert.ToDecimal(txtBookQty.Text);
                _Book.Images = GetImagePath;
                _Book.CategoriesCode = CategoryDropDownList.SelectedValue.ToString();

                decimal AlreadyExistBook = _BooksManager.AlreadyExistBook(_Book);
                if(AlreadyExistBook>=1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Book Already Exist!!..');", true);
                }
                else
                {
                    int successAdd = _BooksManager.Add(_Book);
                    if(successAdd>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Saved Book Successefully!!..');", true);
                        Clear();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed saved!!..');", true);
                    }
                }

            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex.Message+"');", true);
            }
        }
    }
}