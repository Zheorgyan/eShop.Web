using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.TransactionsOrderScreen
{
    public interface IViewOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}