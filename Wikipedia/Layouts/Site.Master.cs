using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikipedia
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.IsInRole("Admin"))
            {
                admin.Visible = false;
            }

            if (!IsPostBack)
                SearchBar.Text = Request.QueryString["q"];
        }



        protected void SearchButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Search.aspx?q=" + SearchBar.Text);

        }


    }
}
