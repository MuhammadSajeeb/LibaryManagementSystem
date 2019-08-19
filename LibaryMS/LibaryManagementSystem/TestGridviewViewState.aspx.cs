using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem
{
    public partial class TestGridviewViewState : System.Web.UI.Page
    {
        //DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //if (ViewState["Details"] == null)
                //{
                //    dataTable.Columns.Add("Name", typeof(string));
                //    dataTable.Columns.Add("Roll", typeof(int));
                //    dataTable.Columns.Add("Gender", typeof(string));

                //    ViewState["Details"] = dataTable;
                //}
            }
        }
        public void LoadGridview()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if(ViewState["Row"] != null)
                {
                    dataTable = (DataTable)ViewState["Row"];
                    DataRow dr = null;
                    if(dataTable.Rows.Count > 0)
                    {
                        dr["Name"] = txtusername.Text;
                        dr["Roll"] = txtRoll.Text;
                        dr["Gender"] = txtGender.Text;
                        dataTable.Rows.Add(dr);
                        ViewState["Row"] = dataTable;
                        DetailsGridView.DataSource = ViewState["Row"];
                        DetailsGridView.DataBind();
                    }
                         
                }
                else
                {
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Roll", typeof(int));
                    dataTable.Columns.Add("Gender", typeof(string));

                    DataRow dr1 = dataTable.NewRow();
                    dr1 = dataTable.NewRow();

                    dr1["Name"] = txtusername.Text;
                    dr1["Roll"] = txtRoll.Text;
                    dr1["Gender"] = txtGender.Text;
                    dataTable.Rows.Add(dr1);
                    ViewState["Row"] = dataTable;
                    DetailsGridView.DataSource = ViewState["Row"];
                    DetailsGridView.DataBind();

                }

            }
            catch(Exception ex)
            {

            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            //    dataTable = (DataTable)ViewState["Details"];

            //    dataTable.Rows.Add(txtusername.Text,txtRoll.Text,txtGender.Text);
            //    DetailsGridView.DataSource = dataTable;
            //    DetailsGridView.DataBind();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Roll", typeof(int));
            dataTable.Columns.Add("Gender", typeof(string));
            DataRow dr = null;
            if(ViewState["Details"]!=null)
            {
                for (int i=0; i<1; i++)
                {
                    dataTable = (DataTable)ViewState["Details"];
                    if (dataTable.Rows.Count > 0)
                    {
                        dr = dataTable.NewRow();
                        dr["Name"] = txtusername.Text;
                        dr["Roll"] = txtRoll.Text;
                        dr["Gender"] = txtGender.Text;
                        dataTable.Rows.Add(dr);

                        DetailsGridView.DataSource = dataTable;
                        DetailsGridView.DataBind();
                    }
                }
            }
            else
            {
                dr = dataTable.NewRow();
                dr["Name"] = txtusername.Text;
                dr["Roll"] = txtRoll.Text;
                dr["Gender"] = txtGender.Text;
                dataTable.Rows.Add(dr);

                DetailsGridView.DataSource = dataTable;
                DetailsGridView.DataBind();
            }
            ViewState["Details"] = dataTable;
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            DetailsGridView.DataSource = null;
            DetailsGridView.DataBind();
            ViewState["Details"] = null;
        }
    }
}