using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBlog.Models
{
    public class CarCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<CarList> CarLists { get; set; }

    }
}