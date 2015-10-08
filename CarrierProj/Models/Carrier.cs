using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarrierProj.Models
{
    public class Carrier
    {
        public int ID { get; set; }

        [Display(Name = "Código"), Required, StringLength(5, MinimumLength = 3)]
        public string Code { get; set; }

        [Display(Name = "Nome"), Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Data de Criação"), DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }
    }
}