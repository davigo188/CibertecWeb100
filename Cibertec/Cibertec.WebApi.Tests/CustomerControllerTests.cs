using Cibertec.Mocked;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cibertec.WebApi.Tests
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _customerController;
        private readonly IUnitOfWork _unitMocked;

        public CustomerControllerTests()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerController = new CustomerController(_unitMocked);
        }

        [Fact(DisplayName ="[CustomerController] Get List")]
        public void Get_All_Test()
        {
            var result = _customerController.GetList() as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CustomerController] Insert")]
        public void Insert_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 101,
                City = "Lima",
                Country = "Peru",
                FirstName = "David",
                LastName = "Godoy Huaman",
                Phone = "7777777"
            };

            var result = _customerController.Post(customer) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);

        }

        [Fact(DisplayName = "[CustomerController] Update")]
        public void Update_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1,
                City = "Lima",
                Country = "Peru",
                FirstName = "David",
                LastName = "Godoy Huaman",
                Phone = "7777778"
            };

            var result = _customerController.Put(customer) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);
            model.Should().Be("The Customer is updated");

            var currentCustomer = _unitMocked.Customers.GetById(1);
            currentCustomer.Should().NotBeNull();
            currentCustomer.Id.Should().Be(customer.Id);
            currentCustomer.City.Should().Be(customer.City);
            currentCustomer.Country.Should().Be(customer.Country);
            currentCustomer.FirstName.Should().Be(customer.FirstName);
            currentCustomer.LastName.Should().Be(customer.LastName);
            currentCustomer.Phone.Should().Be(customer.Phone);


        }

        [Fact(DisplayName = "[CustomerController] Delete")]
        public void Delete_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1
            };
            var result = _customerController.Delete(customer) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();
            var currentCustomer = _unitMocked.Customers.GetById(1);
            currentCustomer.Should().BeNull();
        }

        [Fact(DisplayName = "[CustomerController] Get By Id")]
        public void GetById_Customer_Test()
        {
            var result = _customerController.GetById(1) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            var model = result.Value as Customer;
            model.Should().NotBeNull();
            model.Id.Should().BeGreaterThan(0);
        }


    }
}
