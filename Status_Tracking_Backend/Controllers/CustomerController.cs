using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Status_Tracking_Backend.Models;
using Status_Tracking_Backend.Service;

namespace Status_Tracking_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("addCustomer")]
        public IActionResult AddCustomer(Customers customer)
        {
            _customerService.AddCustomer(customer);
            return Ok(customer);
        }

        [HttpGet]
        public IActionResult GetCustomerDetails()
        {
            var items = _customerService.GetCustomers();
            return Ok(items);
        }

        [HttpGet("export")]
        public IActionResult ExportExcel()
        {
            var excel = _customerService.ExportExcel();

            return File(
                     excel,
                     "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                     "CustomerDetails.xlsx"
);
        }
    }
}
