using DocumentFormat.OpenXml.Wordprocessing;
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
        private readonly ICustomerServices _customerService;

        public CustomerController(ICustomerServices customerService)
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
        [HttpGet("page")]
        public IActionResult GetDetails(int pageNumber =1, int pageSize=10,string search="")
        {
            var items = _customerService.GetCustomersDetails(pageNumber, pageSize,search);

            return Ok(items);
        }

        [HttpPost("update")]
        public IActionResult UpdateCustomer(Customers customer)
        {
            var isUpdated = _customerService.UpdateCustomer(customer);
            if (isUpdated)
            {
                return Ok(new { message = "Customer Added Successfully!", Success = true });
            }

            return BadRequest(new { message = "Customer not found", Success = false });

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(String id)
        {
            if (_customerService.DeleteCustomer(id))
            {
                return Ok(new { message = "Customer Deleted Successfully!", Success = true });
            }
            return BadRequest(new { message = "Customer not found", Success = false });

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
