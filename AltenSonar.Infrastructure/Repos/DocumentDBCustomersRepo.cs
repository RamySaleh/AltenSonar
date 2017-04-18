using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Core.Entities;
using AltenSonar.Core.Interfaces;
using Microsoft.Azure.Documents.Client;

namespace AltenSonar.Infrastructure.Repos
{
    public class DocumentDBCustomersRepo : ICustomersRepo
    {
        DocumentClient _dbClient;
        Uri _customersLink;

        public DocumentDBCustomersRepo()
        {
            // The database url and a read-only key
            _dbClient = new DocumentClient(new Uri("https://altensonarserver.documents.azure.com:443/"), "XCEeLTiTbR8TViwqpSwWTbWM2dZ5Y2xwqKeyJ6nmtnFluSLox5ulz5biFt7hLYYE9lwD5TnYeXCBrAd2Sl0iDA==");
            _customersLink = UriFactory.CreateDocumentCollectionUri("altenSonarDB", "Customers");
        }

        public List<Customer> GetCustomers()
        {
            var customers = _dbClient.CreateDocumentQuery<Customer>(_customersLink).OrderBy(c => c.Name).ToList();
            return customers;
        }
    }
}
