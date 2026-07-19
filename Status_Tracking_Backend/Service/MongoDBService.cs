using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
        public PageResponse GetCustomerDetails1(int pageNumber, int pageSize,string search) {
            var skip = (pageNumber - 1) * pageSize;
            FilterDefinition<Customers> filter;
            if (string.IsNullOrWhiteSpace(search))
            {
                filter = Builders<Customers>.Filter.Empty;
            }
            else
            {
                filter = Builders<Customers>.Filter.Or(
                    Builders<Customers>.Filter.Regex(
                        x => x.Customer_Name,
                        new BsonRegularExpression(search, "i")
                        ),
             Builders<Customers>.Filter.Regex(
                x => x.RM_Name,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.TM_Name,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Mobile_Number,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Status,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Remarks,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Remarks1,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Remarks2,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Month,
                new BsonRegularExpression(search, "i")
            ),

            Builders<Customers>.Filter.Regex(
                x => x.Date,
                new BsonRegularExpression(search, "i")
            )

                  );

            }
            var customers = _customerCollection.Find(filter).Skip(skip).Limit(pageSize).ToList();

            var totalRecords = _customerCollection.CountDocuments(filter);
            return new PageResponse
            {
                Data = customers,
                TotalRecords = (int)totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
              
        }

        public bool UpdateCustomers(Customers customer)
        {
            var item = _customerCollection.ReplaceOne(x => x.Id == customer.Id, customer);
            
            return item.IsAcknowledged && item.ModifiedCount>0;
        }

        public bool DeleteCustomer(String id)
        {
            var item = _customerCollection.DeleteOne(x => x.Id == id);
            return item.IsAcknowledged && item.DeletedCount > 0;
            

        }
    }
}
