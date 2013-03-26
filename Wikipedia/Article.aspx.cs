using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikipedia
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                string stringid = Request.QueryString["id"];
                int id;

                if (int.TryParse(stringid, out id))
                {
                    var article = eds.Articles.Where(art => art.Id == id).First();

                    ArticleName.Text = article.Name;
                    ArticleContent.Text = Textile.TextileFormatter.FormatString(article.Content);

                    if (!article.IsProtected || Request.IsAuthenticated)
                    {
                        EditAction.Visible = true;
                        EditLink.HRef = "~/ArticleEdit.aspx?id=" + article.Id;
                    }
                    if (article.UserName == User.Identity.Name || User.IsInRole("Editor"))
                    {
                        ProtectAction.Visible = true;
                        if (article.IsProtected) { ProtectLink.Text = "UnProtect"; }
                    }
                    if (User.IsInRole("Editor"))
                    {
                        VersionAction.Visible = true;
                        VersionsLinks.HRef = "~/ArticleVersions.aspx?id=" + article.Id;
                    }
                }
                else
                { Response.Redirect("~"); }
            }
        }

        protected void ProtectToggle(object sender, EventArgs e)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                string stringid = Request.QueryString["id"];
                int id;

                if (int.TryParse(stringid, out id))
                {
                    var article = eds.Articles.Where(art => art.Id == id).First();

                    if (article.UserName == User.Identity.Name || User.IsInRole("Editor"))
                    {
                        if (article.IsProtected)
                        {
                            article.IsProtected = false;
                            ProtectLink.Text = "Protect";
                        }
                        else
                        {
                            article.IsProtected = true;
                            ProtectLink.Text = "UnProtect";
                        }
                    }

                    eds.SaveChanges();
                }
            }

        }
    }
}