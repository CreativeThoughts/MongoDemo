using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDemo.Interfaces;
using MongoDemo.Model;

namespace MongoDemo.Services
{
    public class CustomerConsentDataContext : IDataContext
    {
        private readonly IMongoDatabase _db = null;

        public CustomerConsentDataContext(IOptions<Settings> settings)
        {
            //MongoClientSettings st = new MongoClientSettings();

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<CustomerConsent> CustomerConsents
        {
            get{
                
                if(_db != null)
                    return _db.GetCollection<CustomerConsent>("custConsents");
                
                return null;
            }
           
        }
    }
}
