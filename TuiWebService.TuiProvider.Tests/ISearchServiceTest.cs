using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TuiWebService.Common;
using TuiWebService.Common.Models;
using Xunit;

namespace TuiWebService.TuiProvider.Tests
{
    public class ISearchServiceTest
    {
        private class SearchService : ISearchService
        {
            public bool hasCalledGetTours = false;
            public Task<IList<Tour>> GetTours(int departureCityId, int tourCityId, DateTime begTourDate, int nightsFrom, int nightsTo, int numberPeople,
                SortinRules sortinRules)
            {
                hasCalledGetTours = true;
                return null;
            }
        }


        [Fact]
        public void TestCommonCallsGetTours()
        {
            var searchService = new SearchService();
            searchService.GetTours(1, 2, DateTime.Today, 5, 8, 2, 0);
            Assert.True(searchService.hasCalledGetTours);
        }
    }
}
