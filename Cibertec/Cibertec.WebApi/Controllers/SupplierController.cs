using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Supplier")]
    public class SupplierController : BaseController
    {
        public SupplierController(IUnitOfWork unit) : base(unit)
        {
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
        [Route("{id:int}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.Suppliers.Delete(new Supplier { Id = id.Value }));
            return BadRequest(new { Message = "Incorrect data." });
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Suppliers.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Suppliers.PagedList(startRecord, endRecord));
        }
    }
}