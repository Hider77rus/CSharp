using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.ToursAggregator
{
    public class SearchService: ISearchServiceAggregator
    {
        private readonly IEnumerable<ISearchService> _searchServices;
        private readonly int _timeout;

        public SearchService(IEnumerable<ISearchService> searchServices, IOptionsMonitor<ServiceSettings> options)
        {
            _searchServices = searchServices;
            _timeout = options.CurrentValue.Timeout;
        }

        public async Task<IEnumerable<Tour>> GetTours(int departureCityId, int tourCityId, DateTime begTourDate,
            int nightsFrom, int nightsTo, int numberPeople,
            SortingRules sortingRules)
        {
            var tasks = _searchServices.Select(s =>
                TryGetTours(
                    s.GetTours(departureCityId, tourCityId, begTourDate, nightsFrom, nightsTo, numberPeople,
                        sortingRules),
                    _timeout));

            var tasksResult = await Task.WhenAll(tasks);

            if (tasksResult.Any(x => x.IsTimeout == false))
            {
                return tasksResult.Where(x => x.IsTimeout == false)
                    .SelectMany(s => s.Tours)
                    .OrderBy(sortingRules)
                    .Take(1000);
            }
            else
            {
                throw new TimeoutException("The operation has timed out.");
            }

        }

        private async Task<TryGetToursResult> TryGetTours(Task<IEnumerable<Tour>> task, int timeout)
        {
            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return new TryGetToursResult(){IsTimeout = false, Tours = await task };
                }
                else
                {
                    return new TryGetToursResult(){IsTimeout = true};
                }
            }
        }
    }
}
