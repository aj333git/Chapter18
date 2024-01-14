using Microsoft.EntityFrameworkCore;
namespace Chapter18.Models {
public static class SeedData {
        public static void SeedDatabase(DataContext context) {
            context.Database.Migrate();
            if (context.Books.Count() == 0 && context.Publishers.Count() == 0
                    && context.Classifications.Count() == 0) {
                Publisher s1 = new Publisher
                    { Name = "Tata Macgraw Hills", City = "San Jose"};
                Publisher s2 = new Publisher
                    { Name = "Arihant", City = "Chicago"};
                Publisher s3 = new Publisher
                    { Name = "BPB", City = "New York"};
                Classification c1 = new Classification { Name = "game programming" };
                Classification c2 = new Classification { Name = "embedded" };
                Classification c3 = new Classification { Name = "Cyber security" };
                context.Books.AddRange(
                    new Book {  Name = "unity", Price = 275,
                        Classification = c1, Publisher = s1},
                        
                    new Book {  Name = "embedded basic", Price = 48.95m,
                        Classification = c2, Publisher = s3},
                        
                    new Book {  Name = "linux debugging", Price = 19.50m,
                        Classification = c3, Publisher = s2 }
                   
                         );
                context.SaveChanges();
            }
        }
    }
    }
    
