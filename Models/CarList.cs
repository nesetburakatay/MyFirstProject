using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBlog.Models
{
    public class CarList
    {        
        [Key]
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarUnicId { get; set; }
        public string ModelYear { get; set; }
        public string CarColor { get; set; }
        public string CarPicture { get; set; }
        public bool CarState { get; set; }

        public int CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }

        //public List<CarSupplier> CarSuppliers { get; set; }
    }
}