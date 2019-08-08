using Lms.Core.Models;
using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Librarian
{
    public partial class Login : System.Web.UI.Page
    {

        LibrarianLoginManager _LibrarianLoginManager = new LibrarianLoginManager();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtusername.Text = Request.Cookies["UserName"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    RememeberCheckBox.Checked = true;
                }
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LibrarianLogin _LibrarianLogin = new LibrarianLogin();
                _LibrarianLogin.UserName = txtusername.Text;
                _LibrarianLogin.Password = txtpassword.Text;

                decimal successLogin = _LibrarianLoginManager.Login(_LibrarianLogin);
                if (successLogin >= 1)
                {
                    if (RememeberCheckBox.Checked)
                    {

                        Response.Cookies["UserName"].Value = _LibrarianLogin.UserName;
                        Response.Cookies["Password"].Value = _LibrarianLogin.Password;

                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);

                        Session["UserName"] = _LibrarianLogin.UserName;
                        ShowMessage("Login", MessageType.Success);
                        Response.Redirect("~/Librarian/Books/Add");
                         

                    }
                    else
                    {

                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                        Session["UserName"] = _LibrarianLogin.UserName;
                        ShowMessage("Login", MessageType.Success);

                    }


                }
                else
                {
                    ShowMessage("Login", MessageType.Failed);
                }

            }
            catch(Exception ex)
            {
                ShowMessage("Catch : " +ex.Message, MessageType.Error);
            }
            
        }
    }
}