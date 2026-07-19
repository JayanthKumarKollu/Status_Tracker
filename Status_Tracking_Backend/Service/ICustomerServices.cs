using Status_Tracking_Backend.Models;

namespace Status_Tracking_Backend.Service
{
    public interface ICustomerServices
    {
        public void AddCustomer(Customers customer);

        public List<Customers> GetCustomers();

        public PageResponse GetCustomersDetails(int pageNumber, int pageSize, string search);

        public byte[] ExportExcel();

        public bool UpdateCustomer(Customers customer);

        public bool DeleteCustomer(String id);
    }
}
