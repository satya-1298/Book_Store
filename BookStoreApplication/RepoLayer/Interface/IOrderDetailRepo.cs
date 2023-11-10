using CommonLayer.Model;
using RepoLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IOrderDetailRepo
    {
        public OrderDetails CreateOrder(CreateOrderDetails createOrder, int userId, int bookId);
    }
}
