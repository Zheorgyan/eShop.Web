using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.TransactionsOrderScreen
{
    public class GetOrdersUseCase : IGetOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute(string customerName, DateTime startDate, DateTime endDate)
        {
            return orderRepository.SearchOrders(customerName, startDate, endDate);
        }
    }
}
