using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.ViewOrdersByCustomerScreen
{
    public interface IViewOrdersByCustomerUseCase
    {
        IEnumerable<Order> Execute(string userId);
    }
}