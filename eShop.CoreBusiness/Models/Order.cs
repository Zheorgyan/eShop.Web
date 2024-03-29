﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace eShop.CoreBusiness.Models
{
    public class Order
    {
        public Order()
        {
            LineItems = new List<OrderLineItem>();
        }

        public int? OrderId { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStateProvince { get; set; }
        public string CustomerCountry { get; set; }
        public string AdminUser { get; set; }
        public string UniqueId { get; set; }
        public string UserId { get; set; }
        public string AdditionalText { get; set; }

        [NotMapped]
        public List<OrderLineItem> LineItems { get; set; }
        public void AddProduct(int productId, int qty, decimal price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
                item.Quantity += qty;
            else
                LineItems.Add(new OrderLineItem { ProductId = productId, Quantity = qty, Price = price, OrderId = OrderId });
        }

        public void RemoveProduct(int productId)
        {
            foreach (var item in LineItems)
            {
                if (item.ProductId == productId)
                {
                    LineItems.Remove(item);
                    break;
                }
            }
        }

    }
}
