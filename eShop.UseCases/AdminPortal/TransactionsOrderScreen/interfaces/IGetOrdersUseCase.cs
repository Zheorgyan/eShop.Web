using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;

namespace eShop.UseCases.TransactionsOrderScreen
{
    public interface IGetOrdersUseCase
    {
        IEnumerable<Order> Execute(string customerName, DateTime startDate, DateTime endDate);
    }
}