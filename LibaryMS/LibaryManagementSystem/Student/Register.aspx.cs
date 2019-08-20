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
    public partial class Register : System.Web.UI.Page
    {
        StudentRegisterManager _StudentRegisterManager = new StudentRegisterManager();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowMessage("Welcome!!..Complete Your Registration...Now Login", MessageType.Success);
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                StudentRegister _StudentRegister = new StudentRegister();
                _StudentRegister.EnrollId = txtEnrollId.Text;

                decimal AlreadyRegister = _StudentRegisterManager.AlreadyRegister(_StudentRegister);
                if(AlreadyRegister>=1)
                {
                    ShowMessage("You Are Already Registered", MessageType.Warning);
                }
                else
                {
                    _StudentRegister.Email = txtemail.Text;
                    _StudentRegister.Password = txtpassword.Text;

                    int successRegister = _StudentRegisterManager.Register(_StudentRegister);
                    if(successRegister>0)
                    {
                        txtEnrollId.Text = "";
                        txtemail.Text = "";
                        ShowMessage("Welcome!!..Complete Your Registration...Now Login", MessageType.Success);
                    }
                    else
                    {
                        ShowMessage("Failed Your Registration", MessageType.Failed);
                    }
                }
            }
            catch(Exception ex)
            {
                ShowMessage("Catch : "+ex.Message, MessageType.Error);
            }
        }
    }
}