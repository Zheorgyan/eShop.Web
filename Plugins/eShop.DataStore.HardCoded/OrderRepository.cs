using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            order.UniqueId = Guid.NewGuid().ToString();
            orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue);
        }

        public Order GetOrder(int id)
        {
            return orders[id];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            foreach(var order in orders)
                if (order.Value.UniqueId == uniqueId) return order.Value;            

            return null;
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue) return;

            var ord = orders[order.OrderId.Value];
            if (ord == null) return;

            orders[order.OrderId.Value] = order;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> SearchOrders(string customerName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return orders.Where(x => x.Value.DatePlaced >= startDate && x.Value.DatePlaced <= endDate.AddDays(1).Date) as IEnumerable<Order>;
            }
            else
            {
                return orders.Where(x => string.Equals(x.Value.CustomerName, customerName, StringComparison.OrdinalIgnoreCase) &&
                                    x.Value.DatePlaced >= startDate && x.Value.DatePlaced <= endDate.AddDays(1).Date) as IEnumerable<Order>;
            }
        }
    }
}
