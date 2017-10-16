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
    public class OrderControllerTests
    {
        private readonly OrderController _orderController;
        private readonly IUnitOfWork _unitMocked;

        public OrderControllerTests()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _orderController = new OrderController(_unitMocked);
        }

        [Fact(DisplayName ="[OrderController] Get List")]
        public void Get_All_Test()
        {
            var result = _orderController.GetList() as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Order>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName ="[OrderController] Insert")]
        public void Insert_Order_Test()
        {
            var order = new Order
            {
                Id = 853,
                OrderDate = DateTime.Now,
                OrderNumber = "777",
                CustomerId = 1,
                TotalAmount = 7777
            };

            var result = _orderController.Post(order) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(853);
        }

        [Fact(DisplayName = "[OrderController] Update")]
        public void Update_Order_Test()
        {
            var order = new Order
            {
                Id = 851,
                OrderDate = DateTime.Now,
                OrderNumber = "777",
                CustomerId = 1,
                TotalAmount = 7788
            };

            var result = _orderController.Put(order) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);
            model.Should().Be("The Order is updated.");

            var currentOrder = _unitMocked.Orders.GetById(851);
            currentOrder.Should().NotBeNull();
            currentOrder.Id.Should().Be(order.Id);
            currentOrder.OrderDate.Should().Be(order.OrderDate);
            currentOrder.OrderNumber.Should().Be(order.OrderNumber);
            currentOrder.CustomerId.Should().Be(order.CustomerId);
            currentOrder.TotalAmount.Should().Be(order.TotalAmount);


        }

        [Fact(DisplayName = "[OrderController] Delete")]
        public void Delete_Order_Test()
        {
            var order = new Order
            {
                Id = 853
            };

            var result = _orderController.Delete(order) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();
            var currentOrder = _unitMocked.Orders.GetById(853);
            currentOrder.Should().BeNull();

        }

        [Fact(DisplayName = "[OrderController] Get By Id")]
        public void GetById_Order_Test()
        {
            var result = _orderController.GetById(1) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            var model = result.Value as Order;
            model.Should().NotBeNull();
            model.Id.Should().BeGreaterThan(0);

        }
    }
}
