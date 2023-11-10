using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Services
{
    public class OrderDetailRepo
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IConfiguration configuration;
        public OrderDetailRepo(BookStoreDBContext bookStoreDB, IConfiguration configuration)
        {
            this._dbContext = bookStoreDB;
            this.configuration = configuration;
        }
        public OrderDetails CreateOrder(CreateOrderDetails createOrder,int userId,int bookId)
        {
            try
            {
                OrderDetails order = new OrderDetails();
                order.UserId = userId;
                order.BookId = bookId;
                order.Discount = createOrder.Discount;
                order.Quantity = createOrder.Quantity;
                order.Price = createOrder.Price;
                order.DeliveryFee = createOrder.DeliveryFee;
                order.TotalAmount = createOrder.TotalAmount;
                order.OrderDate = DateTime.Now;
                _dbContext.OrderDetails.Add(order);
                _dbContext.SaveChanges();
                return order;
            }
            catch 
            {
                throw;
            }
        }
    }
}
