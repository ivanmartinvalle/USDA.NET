using System;

namespace USDA.NET.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Needed for debugging for some reason...
            var foodCompositionClientTests = new FoodCompositionClientTests();
            foodCompositionClientTests.SetUp();
            foodCompositionClientTests.Should_find_dr_pepper_in_search().Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
