using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2020.Days
{
    class Day21
    {
        public static int PartOne(string[] input)
        {
            var allergens = new List<(string[] Allergens, List<string> Ingredients)>();
            var foodsWithAllergens = new Dictionary<string, List<string>>();
            allergens = input.Select(x => (Allergens: x.Replace(")", "").Split(" (contains ")[1].Replace(" ", "").Split(","), Ingredients: x.Split("(contains")[0].Trim().Split(" ").ToList())).ToList();
            var allAllergens = allergens.SelectMany(x => x.Allergens).Distinct();
            foreach(var allergen in allAllergens)
            {
                var match = allergens.Where(x => x.Allergens.Contains(allergen)).Select(x => x.Ingredients).ToList();
                foodsWithAllergens.Add(allergen, match.Aggregate((x, y) => x.Intersect(y).ToList()));
            }
            return allergens.SelectMany(x => x.Ingredients).Where(x => !foodsWithAllergens.SelectMany(x => x.Value).Distinct().Contains(x)).Count();
        }

        public static string PartTwo(string[] input)
        {
            var allergens = new List<(string[] Allergens, List<string> Ingredients)>();
            var foodsWithAllergens = new Dictionary<string, List<string>>();
            allergens = input.Select(x => (Allergens: x.Replace(")", "").Split(" (contains ")[1].Replace(" ", "").Split(","), Ingredients: x.Split("(contains")[0].Trim().Split(" ").ToList())).ToList();
            var allAllergens = allergens.SelectMany(x => x.Allergens).Distinct();
            foreach (var allergen in allAllergens)
            {
                var match = allergens.Where(x => x.Allergens.Contains(allergen)).Select(x => x.Ingredients).ToList();
                foodsWithAllergens.Add(allergen, match.Aggregate((x, y) => x.Intersect(y).ToList()));
            }
            while(foodsWithAllergens.Values.Any(x => x.Count != 1))
            {
                var currentFood = foodsWithAllergens.Where(x => x.Value.Count() == 1).SelectMany(x => x.Value).ToList();
                var multipleFood = foodsWithAllergens.Where(x => x.Value.Count() > 1).Select(x => x.Key).ToList();
                multipleFood.ForEach(x => foodsWithAllergens[x] = foodsWithAllergens[x].Where(x => !currentFood.Contains(x)).ToList());
            }
            return string.Join(",", foodsWithAllergens.OrderBy(x => x.Key).SelectMany(x => x.Value));
        }
    }
}
