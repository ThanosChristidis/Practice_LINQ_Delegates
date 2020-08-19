using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQpart4
{
    class Program
    {
        public static bool IsEven(int num) => num % 2 == 0;

        public static bool IsLong(string word) => word.Length > 8;

        static bool HitGround(string s) => s == "meteorite";


        static void Main(string[] args)
        {
            List<string> heroes = new List<string> { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };

            // Approach 1: without LINQ
            List<string> longLoudHeroes = new List<string>();

            foreach (string hero in heroes)
            {
                if (hero.Length > 6)
                {
                    string formatted = hero.ToUpper();
                    longLoudHeroes.Add(formatted);
                    Console.WriteLine(formatted);
                }
            }

            // Approach 2: with LINQ
            var longLoudHeroes2 = from h in heroes
                                  where h.Length > 6
                                  select h.ToUpper();

            // Printing...
            Console.WriteLine("Your long loud heroes are...");

            foreach (string hero in longLoudHeroes2)
            {
                Console.WriteLine(hero);
            }
            //second way
            heroes.Where(h => h.Length > 6).ToList().ForEach(h => Console.WriteLine(h.ToUpper()));
            //or
            heroes.Where(h=>h.Length > 6).Select(h=>h.ToUpper()).ToList().ForEach(h=>Console.WriteLine(h));

            var shortHeroes = from h in heroes
                              where h.Length < 8
                              select h;
            shortHeroes.ToList().ForEach(h => Console.WriteLine(h));

            var longHeroes = heroes.Where(h => h.Length > 8);
            Console.WriteLine(longHeroes.Count());
            //-----------------------------------------------------

            // Query syntax
            var queryResult = from h in heroes
                              where h.Contains("a")
                              select $"{h} contains an 'a'";

            // Method syntax

            var methodResult = heroes.Where(h => h.Contains("a")).Select(h=>$"{h} contains an 'a'");

            // Printing...
            Console.WriteLine("queryResult:");
            foreach (string s in queryResult)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nmethodResult:");
            foreach (string s in methodResult)
            {
                Console.WriteLine(s);
            }
           
            var heroesWithI = from h in heroes
                              where h.Contains("i")
                              select $"{h} contains an 'i'";

            var underscored = from h in heroes
                              select h.Replace(' ', '_');

            var heroeswithI = heroes.Where(h => h.Contains("i"));
            foreach (string hero in heroeswithI)
            {
                Console.WriteLine(hero);
            }

            var lowerHeroesWithC = heroes.Where(h => h.Contains("c")).Select(h => h.ToLower());
            heroes.Where(h => h.Contains("c")).Select(h => h.ToLower()).ToList().ForEach(h => Console.WriteLine(h));

            var allHeroes = heroes.Select(h => $"Introducing...{h}!");

            var heroeSpaceNames = from h in heroes
                                  where h.Contains(" ")
                                  select h.IndexOf(" ");

            heroes.Select(h => $"Introducing...{h}!").ToList().ForEach(h => Console.WriteLine(h));

            foreach (var hero in heroeSpaceNames)
            {
                Console.WriteLine(hero);
            }

            heroes.Where(h => h.Contains(".") || h.Contains("7")).ToList().ForEach(h => Console.WriteLine(h));


            //----------------------------------------------------------------------------------------------------

            List<string> heroesList = new List<string> { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };

            // Query syntax
            var queryResulti = from h in heroesList
                                   where h.Contains("a")
                                   select $"{h} contains an 'a'";

            // Printing...
            Console.WriteLine($"queryResult has {queryResulti.Count()} elements");

            foreach (string s in queryResult)
            {
                Console.WriteLine(s);
            }

            List<int> numbers = new List<int> { 3, 6, 9, 17, 21 };

           Console.WriteLine(numbers.Count);

            var triplets = numbers.Where(x => x % 3 == 0);

            Console.WriteLine(triplets.Count());


            int[] digits = { 1, 3, 5, 6, 7, 8 };
            //first way
            //bool hasEvenNumber = Array.Exists(numbers, IsEven);

            //second way
            //bool hasEvenNumber = Array.Exists(numbers, (int num) => num % 2 == 0);

            //third way
            bool hasEvenNumber = Array.Exists(digits, num => num % 2 == 0);
            bool hasBigDozen = Array.Exists(digits, (int num) =>
            {
                bool isDozenMultiple = num % 12 == 0;
                bool greaterThan20 = num > 20;
                return isDozenMultiple && greaterThan20;
            });

            Console.WriteLine(hasEvenNumber);

            string[] adjectives = { "rocky", "mountainous", "cosmic", "extraterrestrial" };

            //first solution
            //string firstLongAdjective = Array.Find(adjectives, IsLong);

            //second solution
            string firstLongAdjective = Array.Find(adjectives, w => w.Length > 8);

            Console.WriteLine($"The first long word is {firstLongAdjective}");


            string[] spaceRocks = { "meteoroid", "meteor", "meteorite" };

            //bool makesContact = Array.Exists(spaceRocks, (string s) => s == "meteorite");

            //second way
            bool makesContact = Array.Exists(spaceRocks, s => s == "meteorite");


            if (makesContact) { Console.WriteLine("At least one space rock has reached the Earth's surface!"); }

            string[] summerStrut;

            summerStrut = new string[] { "Juice", "Missing U", "Raspberry Beret", "New York Groove", "Make Me Feel", "Rebel Rebel", "Despacito", "Los Angeles" };

            int[] ratings = { 5, 4, 4, 3, 3, 5, 5, 4 };

            int findthree = Array.IndexOf(ratings, 3);

            Console.WriteLine($"Song number {findthree + 1} is rated three stars");

            string tenword = Array.Find(summerStrut, w => w.Length > 10);



        }
        
    }
}
