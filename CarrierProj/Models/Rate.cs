using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrierProj.Models
{
    public class Rate
    {
        public int ID { get; set; }

        [Display(Name = "Descrição"), Required, StringLength(30, MinimumLength = 3)]
        public string Description { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }
    }
}