using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;

namespace FlooringProject.Data
{
    public interface IOrderRepository
    {
        bool SaveOrderToFile(Order order);

        bool RemoveOrderfromFile(Order order);

        List<Order> GetOrdersbyDate(DateTime date);

        List<Order> GetOrderFromDatabyDateandNumber(DateTime date, string orderNumber);

       
    }
}
