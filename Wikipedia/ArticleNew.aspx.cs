using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikipedia
{
    public partial class ArticleNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                string stringid = Request.QueryString["id"];
                int id;

                if (!int.TryParse(stringid, out id))
                {
                    Response.Redirect("~");
                }
        }

        protected void SubmitClick(object sender, EventArgs e)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                string stringid = Request.QueryString["id"];
                int id;

                if (int.TryParse(stringid, out id))
                {
                    /* create article */
                    Data.Article art = new Data.Article();
                    art.DomainId = id;
                    art.CreateDate = DateTime.Now;
                    if (Request.IsAuthenticated)
                        art.UserName = User.Identity.Name;
                    eds.Articles.AddObject(art);
                    eds.SaveChanges();

                    /* create article version */
                    Data.Version ver = new Data.Version();
                    ver.ArticleId = art.Id;
                    ver.Name = ArticleName.Text;
                    ver.Content = ArticleContent.Text;
                    ver.CreateDate = DateTime.Now;

                    eds.Versions.AddObject(ver);
                    eds.SaveChanges();

                    /* redirect to new article */
                    Response.Redirect("~/Article.aspx?id=" + art.Id);
                }
            }
        }
    }
}