using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Areas.Admin.ViewModel
{
    public class PanelViewModel
    {
        public int QuantityArticles { get; set; }
        public int QuantityCategories { get; set; }
        public int QuantityComments { get; set; }
        public int QuantityTags { get; set; }
    }
}