using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wikipedia
{
    /// <summary>
    /// Summary description for Image
    /// </summary>
    public class Image : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            using (var eds = new Data.WikipediaEntities())
            {
                string stringid = context.Request.QueryString["id"];
                int id;

                if (int.TryParse(stringid, out id))
                {
                    var image = eds.Images.Where(img => img.Id == id).First();
                    context.Response.ContentType = image.ContentType;
                    context.Response.OutputStream.Write(image.Content, 0, image.ContentLength);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}