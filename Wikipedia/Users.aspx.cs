using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;

namespace Wikipedia
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserList.DataSource = Membership.GetAllUsers();
                UserList.DataBind();
            }
        }

        public void RoleChange(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string rolename = chk.ID;
            string username = chk.Attributes["Name"];

            if (chk.Checked)
                Roles.AddUserToRole(username, rolename);
            else
                if (rolename != "Admin" || Roles.GetUsersInRole("Admin").Count() > 1)
                    Roles.RemoveUserFromRole(username, rolename);
                else chk.Checked = true;
        }
        
    }
}