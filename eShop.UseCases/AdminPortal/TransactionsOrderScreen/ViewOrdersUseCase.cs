using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.TransactionsOrderScreen
{
    public class ViewOrdersUseCase : IViewOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOrders();
        }
    }
}
