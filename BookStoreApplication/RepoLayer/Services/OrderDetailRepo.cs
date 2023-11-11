using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Services
{
    public class OrderDetailRepo:IOrderDetailRepo
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
                var result = _dbContext.Books.FirstOrDefault(x=>x.BookId == bookId);
                if (result != null)
                {
                    OrderDetails order = new OrderDetails();
                    order.UserId = userId;
                    order.BookId = bookId;
                    order.Discount = createOrder.Discount;
                    order.Quantity = createOrder.Quantity;
                    order.Price = result.Price;
                    order.DeliveryFee = createOrder.DeliveryFee;
                    order.TotalAmount = result.Price * order.Quantity;
                    order.OrderDate = DateTime.Now;
                    _dbContext.OrderDetails.Add(order);
                    _dbContext.SaveChanges();
                    return order;
                }
                return null;
            }
            catch 
            {
                throw;
            }
        }
        public OrderDetails UpdateOrder(CreateOrderDetails createOrder,int userId,int bookId,int id)
        {
            try
            {
                var order = _dbContext.OrderDetails.Where(x => x.OrderDetailId == id).FirstOrDefault();
                if (order != null)
                {
                    var result = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
                    if (result != null)
                    {
                        order.UserId = userId;
                        order.BookId = bookId;
                        order.Discount = createOrder.Discount;
                        order.Quantity = createOrder.Quantity;
                        order.Price = result.Price;
                        order.DeliveryFee = createOrder.DeliveryFee;
                        order.TotalAmount = result.Price*order.Quantity;
                        order.OrderDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return order;
                    }
                    return null;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        public List<OrderDetails> GetAllOrders(int userId)
        {
            try
            {
                var result = _dbContext.OrderDetails.Where(x => x.UserId == userId).ToList();
                if(result != null)
                {
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public OrderDetails RemoveOrder(int id,int userId)
        {
            try
            {
                var result = _dbContext.OrderDetails.Where(x => x.OrderDetailId == id && x.UserId==userId).FirstOrDefault();
                if(result!=null)
                {
                    _dbContext.OrderDetails.Remove(result);
                    _dbContext.SaveChanges();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
