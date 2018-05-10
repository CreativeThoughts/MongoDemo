using System;
using System.Threading.Tasks;
using MongoDemo.Model;

namespace MongoDemo.Interfaces
{
    public interface ICustomerConsentService
    {
        Task<CustomerConsent> GetCustomerConsent(string customerId);
        Task<bool> UpdateConsent(string custId, CustomerConsent consent);
    }
}
