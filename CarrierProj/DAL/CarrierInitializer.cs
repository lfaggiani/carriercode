using CarrierProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrierProj.DAL
{
    public class CarrierInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var carriers = new List<Carrier>
            {
                new Carrier { Code="001", Name="Total Express", CreatedDate=DateTime.Now},
                new Carrier { Code="002", Name="Vialog", CreatedDate=DateTime.Now},
                new Carrier {Code="003", Name="TAM", CreatedDate=DateTime.Now }
            };

            carriers.ForEach(s => context.Carriers.Add(s));
            context.SaveChanges();

            var rates = new List<Rate>
            {
                new Rate {Description="Ruim" },
                new Rate {Description="Media" },
                new Rate {Description="Boa" },
                new Rate {Description="Excelente" }
            };

            rates.ForEach(s => context.Rates.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}