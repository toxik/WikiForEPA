using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wikipedia.Data
{
    public partial class Domain
    {
        public dynamic LatestArticles
        {
            get
            { return Articles.OrderByDescending(art => art.CreateDate).Take(5); }
        }
    }
}