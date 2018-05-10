using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDemo.Interfaces;
using MongoDemo.Model;
using static MongoDemo.Model.CustomerConsent;

namespace MongoDemo.Services
{
    public class CustomerConsentService : ICustomerConsentService
    {
        private IDataContext _dataContext = null;
        public CustomerConsentService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CustomerConsent> GetCustomerConsent(string customerId)
        {
            var filter = Builders<CustomerConsent>.Filter.Eq("customerId", customerId);
            try
            {
                var collection = await _dataContext.CustomerConsents.Find(filter).FirstOrDefaultAsync();
                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddNewConsent(CustomerConsent consent)
        {
            try
            {
                await _dataContext.CustomerConsents.InsertOneAsync(consent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateConsent(string custId, CustomerConsent consent)
        {
            var filter = Builders<CustomerConsent>.Filter.Eq(x => x.customerId, custId);
            var update = Builders<CustomerConsent>.Update.PushEach<Consent>(x => x.consents, consent.consents);

            try
            {
                UpdateResult res = await _dataContext.CustomerConsents.UpdateOneAsync(filter, update);
                return res.IsAcknowledged && res.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> UpdateExistingConsent(string custId, string consentType, string status)
        {
            var filter = Builders<CustomerConsent>.Filter.Where(x => x.customerId == custId && x.consents.Exists(i => i.consentType == consentType));
            var update = Builders<CustomerConsent>.Update.Set(x => x.consents[-1].status, status);

            try
            {
                UpdateResult res = await _dataContext.CustomerConsents.UpdateOneAsync(filter, update);
                return res.IsAcknowledged && res.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
