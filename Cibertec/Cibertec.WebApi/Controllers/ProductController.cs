using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        public ProductController(IUnitOfWork unit)
        {
            _unit = unit;
        }


        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Products.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Products.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Products.Insert(product));
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid && _unit.Products.Update(product))
                return Ok(new { Message = "The Product is updated" });
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            if (product.Id > 0)
                return Ok(_unit.Products.Delete(product));
            return BadRequest(new { Message = "Incorrect data." });
        }
    }



}