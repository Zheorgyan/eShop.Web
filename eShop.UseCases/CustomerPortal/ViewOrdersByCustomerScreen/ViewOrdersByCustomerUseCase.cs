using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.ViewOrdersByCustomerScreen
{
    public class ViewOrdersByCustomerUseCase : IViewOrdersByCustomerUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrdersByCustomerUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute(string userId)
        {
            return orderRepository.GetOrdersByUser(userId);
        }
    }
}
