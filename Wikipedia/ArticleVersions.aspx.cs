using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikipedia
{
    public partial class ArticleVersions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void VersionDeleted(object sender, EntityDataSourceChangedEventArgs e)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                Data.Version ver = e.Entity as Data.Version;
                var art = eds.Articles.Where(article => article.Id == ver.ArticleId).First();

                if (art.Versions.Count == 0)
                {
                    eds.Articles.DeleteObject(art);
                    eds.SaveChanges();
                }
            }
        }
    }
}