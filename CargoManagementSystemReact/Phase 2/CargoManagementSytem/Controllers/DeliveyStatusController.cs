using CargoManagementSytem.Data;
using CargoManagementSytem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveyStatusController : ControllerBase
    {
        DeliveryStatusData data = new DeliveryStatusData();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(data.GetAll());
        }
        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = data.GetById(id);

            if (result == null)
            {
                return NotFound($"Status ID {id} ma jiro.");
            }

            return Ok(result);
        }
        // INSERT
        [HttpPost]
        public IActionResult Insert(DeliveryStatus s)
        {
            if (data.Insert(s))
            {
                return Ok("Status waa la daray.");
            }

            return BadRequest("Lama darin.");
        }
        // upadte
        [HttpPut]
        public IActionResult Update(DeliveryStatus s)
        {
            if (data.Update(s))
            {
                return Ok("Status waa la update gareeyay.");
            }

            return NotFound("Status lama helin.");
        }
        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (data.Delete(id))
            {
                return Ok($"Status ID {id} waa la tirtiray.");
            }

            return NotFound($"Status ID {id} ma jiro.");
        }

    }
}
