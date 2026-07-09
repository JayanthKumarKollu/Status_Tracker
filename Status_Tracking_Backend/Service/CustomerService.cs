using Status_Tracking_Backend.Models;

namespace Status_Tracking_Backend.Service
{
    public class CustomerService
    {
        private readonly MongoDBService _mongodbService;
        private readonly ExportService _exportService;
       public CustomerService(MongoDBService mongoDBService, ExportService exportService) {
            _mongodbService = mongoDBService;
            _exportService = exportService;

        }

        public void AddCustomer(Customers customer)
        {
            _mongodbService.AddCustomer(customer);
        }

        public List<Customers> GetCustomers()
        {
            return _mongodbService.GetCustomerDetails();
        }

        public byte[] ExportExcel()
        {
            var customers = _mongodbService.GetCustomerDetails();
            return _exportService.ExportExcel(customers);
        }
    }
}
