using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDemo.Interfaces;
using MongoDemo.Model;

namespace MongoDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustConsentController : Controller
    {
        private readonly ICustomerConsentService _customerConsentService = null;
        public CustConsentController(ICustomerConsentService customerConsentService)
        {
            _customerConsentService = customerConsentService;
        }

        //Get api/custconsent/id
        [HttpGet("{id}")]
        public Task<CustomerConsent> Get(string id)
        {
            return GetCustomerConsentInternal(id);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]CustomerConsent consent)
        {
            var res = _customerConsentService.UpdateConsent(id, consent);
        }


        private async Task<CustomerConsent> GetCustomerConsentInternal(string customerId)
        {
            return await _customerConsentService.GetCustomerConsent(customerId) ?? new CustomerConsent();
        }

    }
}
