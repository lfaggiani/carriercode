using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrierProj.Models
{
    public class UserRating
    {
        public int ID { get; set; }
        
        [Display(Name = "Classificação"), Required]
        public int RateID { get; set; }

        [Display(Name = "Transportadora"), Required]
        public int CarrierID { get; set; }

        [Display(Name = "Usuário")]
        public string ApplicationUserID { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Rate Rate { get; set; }
        public virtual Carrier Carrier { get; set; }
    }
}