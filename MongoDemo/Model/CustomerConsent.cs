using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDemo.Model
{
    public class CustomerConsent
    {
        public ObjectId Id { get; set; }
        public string customerId { get; set; }
        public string customerIdType { get; set; } = string.Empty;
        public List<Consent> consents { get; set; } = null;

        public class ProcessPath
        {
            public string sourceSystem { get; set; }
            public string timeStamp { get; set; }
        }

        public class RelatedParty
        {
            public string customerId { get; set; }
            public string customerIdType { get; set; }
            public string roleType { get; set; }
        }

        public class ConsentParam
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class Consent
        {           
            public string consentId { get; set; }
            public string consentType { get; set; }
            public string status { get; set; }
            public string timeStamp { get; set; }
            public List<ProcessPath> processPath { get; set; }
            public List<RelatedParty> relatedParties { get; set; }
            public List<ConsentParam> consentParams { get; set; }
        }


    }
}
