using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class FilterItemViewModel
    {
        public int CategoryId { get; set; }

        public List<string> Server { get; set; }

        public List<string> Language { get; set; }

        public List<string> Level { get; set; }

        public List<decimal> UnitPrice { get; set; }

        public List<int> Age { get; set; }

        public List<int> Gender { get; set; }

        public List<string> Status { get; set; }

    }
}