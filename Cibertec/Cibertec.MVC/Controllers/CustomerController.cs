using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Insert(customer)>0)
            {
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customers.Update(customer))
            {
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public IActionResult Details(int id)
        {
          
            return View(_unit.Customers.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            return View(_unit.Customers.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            // realizar eliminacion de cascada.
            //List<Order> order = _unit.Orders.GetList().ToList();
            return View();
        }

    }
}