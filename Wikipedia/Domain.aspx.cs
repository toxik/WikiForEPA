using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Wikipedia
{
    public partial class Domain : System.Web.UI.Page
    {
        /* Properties */
        private SortDirection GV_SortDirection
        {
            get
            {
                if (ViewState["sort_direction"] == null)
                    ViewState["sort_direction"] = SortDirection.Ascending;
                return (SortDirection) ViewState["sort_direction"];
            }
            set
            { ViewState["sort_direction"] = value; }
        }

        /* Functions */
        private void GV_Sort(string sort_expression)
        {
            var articles = ViewState["articles"] as DataTable;

            DataView view = new DataView(articles);
            view.Sort = sort_expression;
            ArticlesGridView.DataSource = view;
            ArticlesGridView.DataBind();
        }

        /* Events */
        protected void GV_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (GV_SortDirection == SortDirection.Ascending)
            {
                GV_SortDirection = SortDirection.Descending;
                GV_Sort (e.SortExpression + " DESC");
            }
            else
            {
                GV_SortDirection = SortDirection.Ascending;
                GV_Sort (e.SortExpression + " ASC");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var eds = new Data.WikipediaEntities())
                {
                    string stringid = Request.QueryString["id"];
                    int id;

                    if (int.TryParse(stringid, out id))
                    {
                        NewAction.Visible = true;
                        NewLink.HRef = "ArticleNew.aspx?id=" + id;

                        var domain = eds.Domains.Where(dom => dom.Id == id).FirstOrDefault();
                        if (domain != null)
                        {
                            Page.Title = "Wikipedia:" + domain.Name;
                            DomainName.InnerText = domain.Name;
                            DomainName.Visible = true;
                        }

                        var articles = eds.Articles.Where(art => art.DomainId == id);

                        DataTable table = new DataTable();
                        table.Columns.Add("Id");
                        table.Columns.Add("Name");
                        table.Columns.Add("UserName");
                        table.Columns.Add("IsProtected");
                        table.Columns.Add("CreateDate");

                        table.Columns["Id"].DataType = System.Type.GetType("System.Int32");
                        table.Columns["Name"].DataType = System.Type.GetType("System.String");
                        table.Columns["UserName"].DataType = System.Type.GetType("System.String");
                        table.Columns["IsProtected"].DataType = System.Type.GetType("System.Boolean");
                        table.Columns["CreateDate"].DataType = System.Type.GetType("System.DateTime");

                        foreach (var art in articles)
                        {
                            DataRow row = table.NewRow();
                            row["Id"] = art.Id;
                            row["Name"] = art.Name;
                            row["UserName"] = art.UserName;
                            row["IsProtected"] = art.IsProtected;
                            row["CreateDate"] = art.CreateDate;

                            table.Rows.Add(row);
                        }
                        
                        ViewState["articles"] = table;
                        DataView view = new DataView(table);
                        view.Sort = "Name ASC";

                        ArticlesGridView.DataSource = view;
                        ArticlesGridView.DataBind();
                    }
                }
            }
        }

       
    }
}