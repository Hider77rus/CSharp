using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuiWebService.Common;
using TuiWebService.Common.Models;
using Xunit;

namespace TuiWebService.TuiProvider.Tests
{
    public class SearchServiceInterfaceTests
    {
        private class SearchService : ISearchService
        {
            public bool HasCalledGetTours { get; private set; } = false;
            public Task<IEnumerable<TourPriceOffer>> GetTours(TourSearchRequest request)
            {
                HasCalledGetTours = true;
                return null;
            }
        }


        [Fact]
        public void TestCommonCallsGetTours()
        {
            var tourRequest  = new TourSearchRequest();

            var searchService = new SearchService();
            searchService.GetTours(tourRequest);
            Assert.True(searchService.HasCalledGetTours);
        }
    }
}
