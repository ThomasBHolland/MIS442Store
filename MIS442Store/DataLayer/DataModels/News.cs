using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class News
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string Author { get; set; }
        public string DatePosted { get; set; }

        
    }
}