using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Munchies.Data.EF
{
    internal class MunchiesDbInitializer : DropCreateDatabaseAlways<MunchiesDbContext> // DropCreateDatabaseIfModelChanges<MunchiesDbContext>
    {
        protected override void Seed(MunchiesDbContext context)
        {
            CreateFoodTypes(context);
            CreateRestaurants(context);
        }


        private void CreateFoodTypes(MunchiesDbContext context)
        {
            context.FoodTypes.Add(new FoodType { Name = "cake" });
            context.FoodTypes.Add(new FoodType { Name = "chicken" });
            context.FoodTypes.Add(new FoodType { Name = "chinese food" });
            context.FoodTypes.Add(new FoodType { Name = "indian food" });
            context.FoodTypes.Add(new FoodType { Name = "pasta" });
            context.FoodTypes.Add(new FoodType { Name = "pie" });
            context.FoodTypes.Add(new FoodType { Name = "pizza" });
            context.FoodTypes.Add(new FoodType { Name = "shoarma" });
            context.FoodTypes.Add(new FoodType { Name = "sushi" });

            context.SaveChanges();
        }

        private void CreateRestaurants(MunchiesDbContext context)
        {
            var json = "";
            using (var sr = new System.IO.StreamReader(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "seed.json")))
            {
                json = sr.ReadToEnd();
            }

            var restaurants = JsonConvert.DeserializeObject<ICollection<Restaurant>>(json);
            //Replace food types with the existing ones
            var dbFoodTypes = context.FoodTypes.ToList();
            foreach (var restaurant in restaurants)
            {
                var newFoodTypes = dbFoodTypes.Where(df => restaurant.FoodTypes.Select(f => f.Id).ToList().Contains(df.Id)).ToList();
                restaurant.FoodTypes = newFoodTypes;
            }

            context.Restaurants.AddRange(restaurants);
            context.SaveChanges();
        }
    }
}