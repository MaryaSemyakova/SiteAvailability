using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SiteAvailability.BE;

namespace SiteAvailability.DAL.Site
{
    public class SiteDAL : ISiteDAL
    {
        private IMongoCollection<string> _collection;
        public SiteDAL()
        {
            string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("siteDB");
            _collection = database.GetCollection<string>("employees");
        }

        public void AddSite(string siteUrl)
        {
            _collection.InsertOneAsync(siteUrl);
        }

        public List<string> GetSiteList()
        {
            return _collection.FindSync("").ToList();
        }

        public void DeleteSite(string siteUrl)
        {
            _collection.DeleteOneAsync(siteUrl);
        }
    }
}