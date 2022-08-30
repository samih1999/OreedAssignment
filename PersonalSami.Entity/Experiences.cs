using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSami.Entity
{
   public class Experiences
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDesc { get; set; }
        public DateTime DateFrom  { get; set; }
        public DateTime DateTo { get; set; }
        public UserInfo userInfo { get; set; }

    }
}
