namespace CarrierProj.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarrierProj.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarrierProj.Models.ApplicationDbContext context)
        {
            var carriers = new List<Carrier>
            {
                new Carrier { Code="001", Name="Total Express", CreatedDate=DateTime.Now},
                new Carrier { Code="002", Name="Vialog", CreatedDate=DateTime.Now},
                new Carrier {Code="003", Name="TAM", CreatedDate=DateTime.Now }
            };

            carriers.ForEach(s => context.Carriers.AddOrUpdate(p => p.Code, s));
            context.SaveChanges();

            var rates = new List<Rate>
            {
                new Rate {Description="Ruim" },
                new Rate {Description="Media" },
                new Rate {Description="Boa" },
                new Rate {Description="Excelente" }
            };

            rates.ForEach(s => context.Rates.AddOrUpdate(p => p.Description, s));
            context.SaveChanges();
            
        }
    }
}
