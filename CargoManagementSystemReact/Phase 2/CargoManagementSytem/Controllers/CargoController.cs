using CargoManagementSytem.Data;
using CargoManagementSytem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCargos()
        {
            CargoData data = new CargoData();
            var cargos = data.GetCargos();

            return Ok(cargos);
        }

        //insert
        [HttpPost]
        public IActionResult AddCargo(Cargo add)
        {

            CargoData data=new CargoData();
            data.AddCargo(add);
            return Ok("insert successfuly, please ka fiiri database");
        }

        //update
        [HttpPut]
        public IActionResult UpdateCargo(Cargo customer)
        {
            CargoData data = new CargoData();

            data.UpdateCargo(customer);

            return Ok("Customer Updated Successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoById(int id)
        {
            CargoData data = new CargoData();

            var result = data.GetCargoById(id);

            if (result == null)
            {
                return NotFound($"Cargo ID {id} ma jiro.");
            }

            return Ok(result);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargo(int id)
        {
            CargoData data = new CargoData();

            bool result = data.DeleteCargo(id);

            if (!result)
            {
                return NotFound($"Cargo ID {id} ma jiro, lama tirtiri karo.");
            }

            return Ok("Cargo waa la tirtiray.");
        }
    }

    }
