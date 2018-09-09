using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Quartz;
using SiteAvailability.BE;
using SiteAvailability.BL.Site;

namespace SiteAvailability.Jobs
{
    public class SiteChecker : IJob
    {
        private readonly ISiteBL _siteBl;

        public SiteChecker(ISiteBL siteBl)
        {
            _siteBl = siteBl;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var sites = _siteBl.GetSites();
            var siteAvailabilityList = new List<SiteInfo>();

            foreach (var siteUrl in sites)
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(siteUrl);
                    siteAvailabilityList.Add(
                        new SiteInfo
                            {
                                Url = siteUrl,
                                IsActive = response.Result.IsSuccessStatusCode

                            });
                }

            }

            return null;
        }
    }
}
