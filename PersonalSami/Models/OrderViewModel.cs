using personalsami.Entity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PersonalSami.Models
{
	public class OrderViewModel
	{
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public double Discount { get; set; }
        public string type { get; set; }

        public string CustomerName { get; set; }
        public string Location { get; set; }


    }
}
