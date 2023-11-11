using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Interface;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class OrderDetailsBusiness:IOrderDetailsBusiness
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        public OrderDetailsBusiness(IOrderDetailRepo _orderDetailRepo)
        {
            this._orderDetailRepo = _orderDetailRepo;
        }
        public OrderDetails CreateOrder(CreateOrderDetails createOrder, int userId, int bookId)
        {
            try
            {
                return _orderDetailRepo.CreateOrder(createOrder, userId, bookId);
            }
            catch 
            {
                throw;
            }
        }
        public OrderDetails UpdateOrder(CreateOrderDetails createOrder, int userId, int bookId, int id)
        {
            try
            {
                return _orderDetailRepo.UpdateOrder(createOrder, userId, bookId, id);
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
                return _orderDetailRepo.GetAllOrders(userId);
            }
            catch
            {
                return null;
            }
        }
        public OrderDetails RemoveOrder(int id, int userId)
        {
            try
            {
                return _orderDetailRepo.RemoveOrder(id,userId);
            }
            catch 
            {
                return null;
            }
        }
    }
}
