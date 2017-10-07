using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unit;

        public SupplierController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Suppliers.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Suppliers.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Suppliers.Insert(supplier));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid && _unit.Suppliers.Update(supplier))
                return Ok(new { Message = "The Supplier is updated" });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unit.Suppliers.Delete(supplier));
            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}