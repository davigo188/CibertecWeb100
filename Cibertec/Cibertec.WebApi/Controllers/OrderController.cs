using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unit;
        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Orders.GetList());

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Orders.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Orders.Insert(order));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (ModelState.IsValid && _unit.Orders.Update(order))
                return Ok(new { Message = "The Order is updated." });
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Order order)
        {
            if (order.Id > 0)
                return Ok(_unit.Orders.Delete(order));
            return BadRequest(new { Message = "Incorrect Data." });

        }

    }

}