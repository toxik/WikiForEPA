using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace Wikipedia
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var eds = new Data.WikipediaEntities())
                {
                    var articles = eds.Articles;

                    DataTable table = new DataTable();
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("UserName");
                    table.Columns.Add("Domain");
                    table.Columns.Add("IsProtected");
                    table.Columns.Add("CreateDate");

                    table.Columns["Id"].DataType = System.Type.GetType("System.Int32");
                    table.Columns["Name"].DataType = System.Type.GetType("System.String");
                    table.Columns["UserName"].DataType = System.Type.GetType("System.String");
                    table.Columns["Domain"].DataType = System.Type.GetType("System.String");
                    table.Columns["IsProtected"].DataType = System.Type.GetType("System.Boolean");
                    table.Columns["CreateDate"].DataType = System.Type.GetType("System.DateTime");

                    foreach (var art in articles)
                    {
                        DataRow row = table.NewRow();
                        row["Id"] = art.Id;
                        row["Name"] = art.Name;
                        row["UserName"] = art.UserName;
                        row["Domain"] = art.Domain.Name;
                        row["IsProtected"] = art.IsProtected;
                        row["CreateDate"] = art.CreateDate;

                        table.Rows.Add(row);
                    }

                    ViewState["articles"] = table;
                }
            }

            string searchtext = Request.QueryString["q"];

            var view = new DataView (ViewState["articles"] as DataTable);
            view.RowFilter = String.Format("Name LIKE '%{0}%'", searchtext);
            view.Sort = "Name ASC";

            ArticlesGridView.DataSource = view;
            ArticlesGridView.DataBind();
        }
    }
}
