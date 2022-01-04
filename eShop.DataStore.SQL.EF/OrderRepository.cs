using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.SQL.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly eShopContext db;

        public OrderRepository(eShopContext db)
        {
            this.db = db;
        }

        public int CreateOrder(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();

            order.LineItems.ForEach(x => db.OrderLineItem.Add(x));
            db.SaveChanges();

            int.TryParse(db.Order.Where(x => x.OrderId == order.OrderId).Max(x => x.OrderId == order.OrderId).ToString(), out int orderId);
            return orderId;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var oli = db.OrderLineItem.Where(x => x.OrderId == orderId);

            var orderLi = oli.Where(x => x.Product.ProductId == x.ProductId);

            return orderLi;
        }

        public Order GetOrder(int id)
        {
            return db.Order.Where(x => x.OrderId == id) as Order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            return db.Order.Where(x => x.UniqueId == uniqueId) as Order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return db.Order.ToList();
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            return db.Order.Where(x => x.DateProcessed == null).ToList();
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            return db.Order.Where(x => x.DateProcessed != null).ToList();
        }

        public IEnumerable<Order> SearchOrders(string customerName, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            int.TryParse(order.OrderId.ToString(), out int orderId);
            var ord = GetOrder(orderId);
            if (ord == null) return;

            db.Order.Update(ord);
            db.SaveChanges();

            order.LineItems.ForEach(x => { db.OrderLineItem.Update(x); });
            db.SaveChanges();

        }
    }
}
