using Lms.Core.Models;
using Lms.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Student
{
    public partial class Login : System.Web.UI.Page
    {
        StudentRegisterManager _StudentRegisterManager = new StudentRegisterManager();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["EnrollId"] != null && Request.Cookies["Password"] != null)
                {
                    txtEnrollId.Text = Request.Cookies["EnrollId"].Value;
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
                StudentRegister _StudentRegister = new StudentRegister();

                _StudentRegister.EnrollId = txtEnrollId.Text;
                _StudentRegister.Password = txtpassword.Text;

                decimal successLogin = _StudentRegisterManager.Login(_StudentRegister);

                if (successLogin >= 1)
                {
                    decimal checkingStatus = _StudentRegisterManager.CheckStatus(_StudentRegister);

                    if(checkingStatus >= 1)
                    {
                        if (RememeberCheckBox.Checked)
                        {

                            Response.Cookies["EnrollId"].Value = _StudentRegister.EnrollId;
                            Response.Cookies["Password"].Value = _StudentRegister.Password;

                            Response.Cookies["EnrollId"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);

                            Session["EnrollId"] = _StudentRegister.EnrollId;
                            ShowMessage("Login", MessageType.Success);
                            //Response.Redirect("~/Librarian/Books/Add");

                        }
                        else
                        {

                            Response.Cookies["EnrollId"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                            Session["EnrollId"] = _StudentRegister.EnrollId;
                            ShowMessage("কফ", MessageType.Success);

                        }
                    }
                    else
                    {
                        ShowMessage("Sorry!!...Your Account Still Pending....", MessageType.Failed);
                    }
                }
                else
                {
                    ShowMessage("Login", MessageType.Failed);
                }

            }
            catch (Exception ex)
            {
                ShowMessage("Catch : " + ex.Message, MessageType.Error);
            }
        }
    }
}