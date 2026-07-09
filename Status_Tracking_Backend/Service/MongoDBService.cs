using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Status_Tracking_Backend.Configuration;
using Status_Tracking_Backend.Models;

namespace Status_Tracking_Backend.Service
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Customers> _customerCollection;

        public MongoDBService(IOptions<MongodbConfig> mongooes)
        {
            
            var mongooesClient = new MongoClient(mongooes.Value.Connection_Name);
            var DatabaseName = mongooesClient.GetDatabase(mongooes.Value.DB_Name);
            _customerCollection = DatabaseName.GetCollection<Customers>(mongooes.Value.Collections);
         }

        public void AddCustomer(Customers customer)
        {
            
             _customerCollection.InsertOne(customer);

        }

        public List<Customers> GetCustomerDetails()
        {
            var items = _customerCollection.Find(x=>true);
            return items.ToList();
        }
    }
}
