using CargoManagementSytem.Data;
using CargoManagementSytem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {

        ShipmentData data = new ShipmentData();

        [HttpGet]
        public IActionResult GetShipments()
        {
            var result = data.GetShipments();
            return Ok(result);
        }
        // get by id
        [HttpGet("{id}")]
        public IActionResult GetShipmentById(int id)
        {
            var result = data.GetShipmentById(id);

            if (result == null)
            {
                return NotFound($"Shipment ID {id} ma jiro.");
            }

            return Ok(result);
        }

        // ✅ INSERT
        [HttpPost]
        public IActionResult AddShipment(Shipments s)
        {
            if (data.AddShipment(s))
            {
                return Ok("Shipment waa la diray.");
            }

            return BadRequest("Lama darin shipment.");
        }

        // ✅ UPDATE
        [HttpPut]
        public IActionResult UpdateShipment(Shipments s)
        {
            if (data.UpdateShipment(s))
            {
                return Ok("Shipment waa la update gareeyay.");
            }

            return NotFound("Shipment lama helin.");
        }
        // delete by id
        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(int id)
        {
            if (data.DeleteShipment(id))
            {
                return Ok($"Shipment ID {id} waa la tirtiray.");
            }

            return NotFound($"Shipment ID {id} ma jiro.");
        }
    }
}
