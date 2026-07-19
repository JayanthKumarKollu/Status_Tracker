using Status_Tracking_Backend.Models;

namespace Status_Tracking_Backend.Service
{
    public class CustomerService:ICustomerServices
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
        public PageResponse GetCustomersDetails(int pageNumber, int pageSize,string search="")
        {
            return _mongodbService.GetCustomerDetails1(pageNumber, pageSize,search);
        }

        public byte[] ExportExcel()
        {
            var customers = _mongodbService.GetCustomerDetails();
            return _exportService.ExportExcel(customers);
        }

        public bool UpdateCustomer(Customers customer)
        {
            var isCustomerUpdated = _mongodbService.UpdateCustomers(customer);
            return isCustomerUpdated;
        }

        public bool DeleteCustomer(String id)
        {
            var isDeleted = _mongodbService.DeleteCustomer(id);
            return isDeleted;
        }
    }
}
