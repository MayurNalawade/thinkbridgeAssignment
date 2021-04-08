using System;
using System.Collections.Generic;
using System.Text;
using thinkbridgeAssignment;
using thinkbridgeAssignment.Model;

namespace CoreServiceTest
{
   public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {

        }

        public void Seed(DataBaseConnectionContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.products.AddRange(
                new Product() { Name = "TEST1", Description = "TEST1", Prise = 2300 },
                new Product() { Name = "TEST2", Description = "TEST2", Prise = 2500},
                new Product() { Name = "TEST3", Description = "TEST3", Prise = 2600 } );

            context.SaveChanges();
        }
    }
}
