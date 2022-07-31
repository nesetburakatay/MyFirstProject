using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBlog.Models
{
    public class CarCategoryUnderList
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<CarCategoryUnderListPack> CarLists { get; set; }
    }
}