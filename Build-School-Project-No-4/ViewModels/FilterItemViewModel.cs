using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class FilterItemViewModel
    {
        public List<string> Server { get; set; }

        public List<string> Language { get; set; }

        public List<string> Level { get; set; }

        public List<decimal> UnitPrice { get; set; }

        public List<int> Age { get; set; }

        public int Gender { get; set; }
    }
}