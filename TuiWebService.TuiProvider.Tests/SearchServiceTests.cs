using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuiWebService.Common;
using Xunit;

namespace TuiWebService.TuiProvider.Tests
{
    public class SearchServiceTests
    {
        private readonly ISearchService _searchService;
        public SearchServiceTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDictService, DictService>()
                .AddSingleton<ISearchService, SearchService>()
                .BuildServiceProvider();

            _searchService = serviceProvider.GetService<ISearchService>();

        }

        [Fact]
        public async void TestCommonCallsGetTours()
        {
            var searchDay = DateTime.Today.AddDays(1);
            var hasTours = false;

            var tour = await _searchService.GetTours(departureCityId: 1, tourCityId: 1, begTourDate: searchDay, nightsFrom: 4,
                nightsTo: 12, numberPeople: 2, sortinRules: 0);

            if (tour.ToList().Count > 0)
                hasTours = true;

            Assert.True(hasTours);
        }
    }
}
