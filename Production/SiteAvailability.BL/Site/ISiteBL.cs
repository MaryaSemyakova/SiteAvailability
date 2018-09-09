using System.Collections.Generic;
using SiteAvailability.BE;

namespace SiteAvailability.BL.Site
{
    public interface ISiteBL
    {
        List<string> GetSites();
        void AddSite(SiteInfo site);
        void DeleteSite(int siteId);
        void UpdateCheckedSites();
    }
}