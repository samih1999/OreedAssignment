using Microsoft.EntityFrameworkCore;
using personalsami.Entity;
using personalsami.Services;
using PersonalSami.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSami.Services.implementayion
{
	public class OrderService : IOrderService
	{
        private readonly ApplicationDbContext _context;

		public OrderService(ApplicationDbContext context)
		{
			_context = context;
		}

		public  Task Create(OrderModel order, CustomerModel customerModel,double discount)
		{
            if (order.type==personalsami.Entity.Type.Special)
            {

                order = new SpeccialOrderModel
                {Discount=discount,
                OrderDate=order.OrderDate,
                OrderNumber=order.OrderNumber, 
                Customer=new CustomerModel { CustomerName=customerModel.CustomerName,
                Location=customerModel.Location,
                Orders=customerModel.Orders},
                
                   
                };

               _context.Orders.Add(order);
               _context.customerModels.Add(customerModel);
               _context.SaveChanges();
            }
            else
            {
                order = new NormalOrderModel();

              _context.Orders.AddAsync(order);
              _context.SaveChangesAsync();
            }
           return Task.CompletedTask;

        }



        
          

        
    }
}
