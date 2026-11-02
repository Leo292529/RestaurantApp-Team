using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello TIT.1/2");

            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant(1, "Quanjude Roast Duck", "Beijing Cuisine", 4.5),
                new Restaurant(2, "Donglaishun Hot Pot", "Hot Pot", 4.6),
                new Restaurant(3, "papaya salad", "Thai food", 4.7),
                new Restaurant(4, "Lad Yso", "Thai food", 5.0),
                new Restaurant(5, "Phad thi", "Thai food", 4.9)

            };


            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.Name} Type:{item.Type} -- {item.Rate}");
            }
            Console.WriteLine($"Total restaurants: {restaurants.Count}");

            double averageRate = restaurants.Average(item => item.Rate);
            Console.WriteLine($"Average rating: {averageRate:F2}");

            Console.WriteLine("\n=== Add New Restaurant ===");
            Console.Write("Enter restaurant name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Enter restaurant type: ");
            string type = Console.ReadLine() ?? "";
            Console.Write("Enter restaurant rating: ");
            if (double.TryParse(Console.ReadLine(), out double rate)
                && rate >= 0 && rate <= 5
                && !string.IsNullOrWhiteSpace(name)
                && !string.IsNullOrWhiteSpace(type))
            {
                int newId = restaurants.Count + 1;
                restaurants.Add(
                    new Restaurant(newId, name, type, rate)
                );
                Console.WriteLine("Add restaurant successfully!");
                Console.WriteLine("\n=== Updated Restaurant List ===");
                foreach (var item in restaurants)
                {
                    Console.WriteLine(
                        $"{item.Name} Type:{item.Type} -- {item.Rate}"
                    );
                }
                Console.WriteLine($"Total restaurants: {restaurants.Count}");
            }
            else
            {
                Console.WriteLine("Invalid restaurant information!");
            }



        }

        // B: แสดงร้านอาหารที่มีคะแนน 4.5 ขึ้นไป
        static void DisplayGoodRating(List<Restaurant> restaurants)
        {
            Console.WriteLine("\n=== Restaurants Rating 4.5 Up ===");

            var goodRestaurants = restaurants
                .Where(item => item.Rate >= 4.5)
                .ToList();

            if (goodRestaurants.Count == 0)
            {
                Console.WriteLine("No restaurant found!");
                return;
            }

            foreach (var item in goodRestaurants)
            {
                Console.WriteLine(
                    $"{item.Name} Type:{item.Type} -- {item.Rate}");
            }

            Console.WriteLine($"Total good restaurants: {goodRestaurants.Count}");
        }

    }

    public class Restaurant
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public double Rate { get; set; }

            public Restaurant(int id, string name, string type, double rate)
            {
                this.Id = id;
                this.Name = name;
                this.Type = type;
                this.Rate = rate;
            }
        }
    }