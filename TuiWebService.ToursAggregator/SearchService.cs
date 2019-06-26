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

        public async Task<IEnumerable<TourPriceOffer>> GetTours(TourSearchRequest request)
        {
            var tasks = _searchServices.Select(s =>
                TryGetTours(
                    s.GetTours(request),
                    _timeout));

            var tasksResult = await Task.WhenAll(tasks);

            if (tasksResult.Any(x => x.HasError == false))
            {
                return tasksResult.Where(x => x.HasError == false)
                    .SelectMany(s => s.Tours)
                    .OrderBy(request.SortingRules)
                    .Take(1000);
            }
            else 
            {
                throw tasksResult.First().Exception;
            }

        }

        private static async Task<TryGetToursResult> TryGetTours(Task<IEnumerable<TourPriceOffer>> task, int timeout)
        {
            try
            {
                using (var tokenSource = new CancellationTokenSource())
                {
                    var completedTask = await Task.WhenAny(task, Task.Delay(timeout, tokenSource.Token));
                    if (completedTask == task)
                    {
                        tokenSource.Cancel();
                        var tours = await task;

                        //Проверка туров на null
                        if (tours == null)
                        {
                            return new TryGetToursResult { HasError = true, Exception = new NullReferenceException() };
                        }

                        return new TryGetToursResult { Tours = tours , HasError = false};
                    }
                    else
                    {
                        return new TryGetToursResult { HasError = true, Exception = new TimeoutException("The operation has timed out.") };
                    }
                }
            }
            catch (Exception e)
            {
                return new TryGetToursResult {HasError = true, Exception = e};
            }
        }
    }
}
