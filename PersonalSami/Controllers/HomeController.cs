using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using personalsami.Entity;

using personalsami.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PersonalSami.Data;
using PersonalSami.Models;

namespace personalsami.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService ;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger,IOrderService orderService, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _orderService = orderService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }




            public IActionResult Ordertable()
        {


            var orders =  _context.Orders.Select(orders => new OrderModel
            {
                Id = orders.Id,
                OrderDate = orders.OrderDate,   
                OrderNumber = orders.OrderNumber,
                Customer=orders.Customer,   
                type=orders.type
           

            }).ToList();







            return View(orders);

        }


        [HttpPost]
        public IActionResult Index(OrderViewModel order)
        {
            var Order = new OrderModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
             
               Customer = new CustomerModel { CustomerName = order.CustomerName, Location = order.Location
               }
            };


            _orderService.Create(Order,Order.Customer,order.Discount);
            return RedirectToAction("Ordertable");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
