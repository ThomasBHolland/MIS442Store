using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal ProductVersion { get; set; }

        public DateTime ProductReleaseDate { get; set; }

    }
}