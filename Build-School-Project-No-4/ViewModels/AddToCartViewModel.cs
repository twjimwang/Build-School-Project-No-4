using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Build_School_Project_No_4.ViewModels
{
    public class AddToCartViewModel
    {
        [Required]
        [Range(1, 999, ErrorMessage = "Must be a valid number")]
        public int Rounds { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        public decimal UnitPrice { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int PlayerId { get; set; }
  

    }
}