using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using USDA.NET.Food;
using USDA.NET.Food.Search;

namespace USDA.NET.Tests
{
    public class FoodCompositionClientTests
    {
        private FoodCompositionClient _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new FoodCompositionClient("DEMO_KEY");
        }

        [Test]
        public async Task Should_find_dr_pepper_in_search()
        {
            var searchOptions = new SearchOptions { SearchTerm = "dr pepper" };

            var searchResult = await _classUnderTest.SearchAsync(searchOptions, new PaginationOptions());

            var firstSearchItem = searchResult.List.Item.Single(x => x.NDBNumber == "45255203");
            firstSearchItem.Name.Should().Be("DR PEPPER, SODA, UPC: 07897102");
            firstSearchItem.Group.Should().Be("Branded Food Products Database");
            firstSearchItem.DataSource.Should().Be(DataSource.Result.BrandedFoodProducts);
        }
    }
}