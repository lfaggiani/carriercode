using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrierProj.ViewModel
{
    public class CarrierViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Código")]
        public string Code { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public int? UserRatingID { get; set; }

        [Display(Name = "Classificação")]
        public string RateDescription { get; set; }
    }
}