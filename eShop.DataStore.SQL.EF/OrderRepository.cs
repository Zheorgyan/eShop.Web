using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataStore.SQL.EF
{
    public class OrderRepository
    {
        private readonly eShopContext db;

        public OrderRepository(eShopContext db)
        {
            this.db = db;
        }

        public int CreateOrder(Order order)
        {
            db.Order.Add(order);
            order.LineItems.ForEach(x => x.OrderId == );
            var sql =
                @"INSERT INTO [dbo].[Order]
                       ([DatePlaced]
                       ,[DateProcessing]
                       ,[DateProcessed]
                       ,[CustomerName]
                       ,[CustomerAddress]
                       ,[CustomerCity]
                       ,[CustomerStateProvince]
                       ,[CustomerCountry]
                       ,[AdminUser]
                       ,[UniqueId])
                 OUTPUT INSERTED.OrderId
                 VALUES
                       (@DatePlaced
                        ,@DateProcessing
                        ,@DateProcessed
                        ,@CustomerName
                        ,@CustomerAddress
                        ,@CustomerCity
                        ,@CustomerStateProvince
                        ,@CustomerCountry
                        ,@AdminUser
                        ,@UniqueId)";

            var orderId = dataAccess.QuerySingle<int, Order>(sql, order);

            sql = @"INSERT INTO [dbo].[OrderLineItem]
                           ([ProductId]
                           ,[OrderId]
                           ,[Quantity]
                           ,[Price])
                     VALUES
                           (@ProductId
                           ,@OrderId
                           ,@Quantity
                           ,@Price)";

            order.LineItems.ForEach(x => x.OrderId = orderId);
            dataAccess.ExecuteCommand(sql, order.LineItems);

            return orderId;

        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var sql = "SELECT * FROM OrderLineItem WHERE OrderId = @OrderId";
            var lineItems = dataAccess.Query<OrderLineItem, dynamic>(sql, new { OrderId = orderId });

            sql = "SELECT * FROM Product WHERE ProductId = @ProductId";
            lineItems.ForEach(x => x.Product = dataAccess.QuerySingle<Product, dynamic>(sql, new { ProductId = x.ProductId }));

            return lineItems;
        }

        public Order GetOrder(int id)
        {
            //var sql = "SELECT * FROM [ORDER] WHERE OrderId = @OrderId";
            //var order = dataAccess.QuerySingle<Order, dynamic>(sql, new { OrderId = id });
            //order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
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
            var sql = @"UPDATE [Order]
                          SET [DatePlaced] = @DatePlaced
                          ,[DateProcessing] = @DateProcessing
                          ,[DateProcessed] = @DateProcessed
                          ,[CustomerName] = @CustomerName
                          ,[CustomerAddress] = @CustomerAddress
                          ,[CustomerCity] = @CustomerCity
                          ,[CustomerStateProvince] = @CustomerStateProvince
                          ,[CustomerCountry] = @CustomerCountry
                          ,[AdminUser] = @AdminUser
                          ,[UniqueId] = @UniqueId
                      WHERE OrderId = @OrderId";

            dataAccess.ExecuteCommand<Order>(sql, order);

            sql = @"UPDATE [OrderLineItem]
                       SET [ProductId] = @ProductId
                          ,[OrderId] = @OrderId
                          ,[Quantity] = @Quantity
                          ,[Price] = @Price
                     WHERE LineItemId = @LineItemId";

            dataAccess.ExecuteCommand<List<OrderLineItem>>(sql, order.LineItems);
        }
    }
}
