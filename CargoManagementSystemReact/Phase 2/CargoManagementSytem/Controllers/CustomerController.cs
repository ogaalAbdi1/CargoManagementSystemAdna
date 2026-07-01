using CargoManagementSytem.Data;
using CargoManagementSytem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        //create funcitom used loo waco controller meeshii uu addi lahaay

        public IActionResult GetDataCustomer()
        {
            return Ok(new CustomerData().GetDataCustomer());
        }


        //insert

        [HttpPost]
        public IActionResult insertdata(Customer add)
        {
            CustomerData data=new CustomerData();
            data.insertdata(add);
            return Ok("insert successfuly, please ka fiiri database");
        }

        //update
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            CustomerData data = new CustomerData();

            data.UpdateCustomer(customer);

            return Ok("Customer Updated Successfully");
        }
        //delete
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            CustomerData data = new CustomerData();

            bool result = data.DeleteCustomer(id);

            if (!result)
            {
                return NotFound($"Customer ID {id} ma jiro, lama tirtiri karo.");
            }

            return Ok("Customer waa la tirtiray.");
        }
        //get customer by id 

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            CustomerData data = new CustomerData();

            var customer = data.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound($"Customer ID {id} ma jiro.");
            }

            return Ok(customer);
        }


    }
}
