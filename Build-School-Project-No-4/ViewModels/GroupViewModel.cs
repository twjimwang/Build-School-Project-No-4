using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<MemberViewModel> MeetLikes { get; set; }
        //public IEnumerable<ProductViewModel> EPalIndex { get; set; }
        public ProductViewModel ProductCards { get; set; }
        public CategoryViewModel GamesDetails{ get; set; }
        public MemberViewModel MemberData { get; set; }
        public DetailViewModel Deets { get; set; }
        public AddToCartViewModel AddCart { get; set; }
        public CheckoutViewModel Checkout { get; set; }
        public OrderViewModel OrderDetails { get; set; }
    }

}