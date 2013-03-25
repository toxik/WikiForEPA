using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wikipedia.Data
{
    public partial class Article
    {
        public string Name
        {
            get
            { return Versions.OrderByDescending(ver => ver.CreateDate).First().Name; }
        }
        public string Content
        {
            get
            { return Versions.OrderByDescending(ver => ver.CreateDate).First().Content; }
        }
    }
}
