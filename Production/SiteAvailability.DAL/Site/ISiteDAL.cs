using System.Collections.Generic;
using SiteAvailability.BE;

namespace SiteAvailability.DAL.Site
{
    public interface ISiteDAL
    {
        void AddSite(string siteUrl);
        List<string> GetSiteList();
        void DeleteSite(string siteUrl);
    }
}
