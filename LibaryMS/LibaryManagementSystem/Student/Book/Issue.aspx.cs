using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Student.Book
{
    public partial class Issue : System.Web.UI.Page
    {
        public enum MessageType { Success, Failed, Error, নোটিশ, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowMessage("তুমি এক মাসে পাঁচটির বেশি বই ইস্যু করতে পারবে না ", MessageType.নোটিশ);
                lblAvailableQty.Text = DateTime.Now.Year.ToString();
            }
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void BookIssueButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}