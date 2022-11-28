using Microsoft.EntityFrameworkCore;
using personalsami.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalsami.Services
{
    public interface IOrderService
    {
        Task Create(OrderModel order,CustomerModel customerModel,double discount);
       




    }
}
