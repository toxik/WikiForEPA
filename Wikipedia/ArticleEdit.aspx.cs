using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikipedia
{
    public partial class ArticleEdit : System.Web.UI.Page
    {
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
                        var article = eds.Articles.Where(art => art.Id == id).First();
                        ViewState["article"] = article;

                        if (article.IsProtected && !Request.IsAuthenticated)
                        { Response.Redirect("~/Article.aspx?id=" + article.Id); }

                        ArticleName.Text = article.Name;
                        ArticleContent.Text = article.Content;
                    }
                    else
                    { Response.Redirect("~"); }
                }
            }
        }

        protected void SubmitClick(object sender, EventArgs e)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                Data.Article art = ViewState["article"] as Data.Article;

                if ((ArticleName.Text != art.Name || ArticleContent.Text != art.Content) &&
                    (!art.IsProtected || Request.IsAuthenticated))
                {
                    Data.Version ver = new Data.Version();
                    ver.ArticleId = art.Id;
                    ver.Name = ArticleName.Text;
                    ver.Content = ArticleContent.Text;
                    ver.CreateDate = DateTime.Now;

                    eds.Versions.AddObject(ver);
                    eds.SaveChanges();
                }

                Response.Redirect("~/Article.aspx?id=" + art.Id);
            }
        }
    }
}
