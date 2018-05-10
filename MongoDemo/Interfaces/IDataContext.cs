using System;
using MongoDB.Driver;
using MongoDemo.Model;

namespace MongoDemo.Interfaces
{
    public interface IDataContext
    {
        IMongoCollection<CustomerConsent> CustomerConsents { get; }
    }
}
