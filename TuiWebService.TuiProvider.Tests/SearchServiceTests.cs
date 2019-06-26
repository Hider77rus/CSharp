using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuiWebService.Common;
using TuiWebService.Common.Models;
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
            var tourRequest = new TourSearchRequest();
            var hasTours = false;

            var tour = await _searchService.GetTours(tourRequest);

            if (tour.ToList().Count > 0)
                hasTours = true;

            Assert.True(hasTours);
        }
    }
}
