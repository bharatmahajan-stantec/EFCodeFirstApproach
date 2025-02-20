using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;
using System.Collections.Generic;

namespace EFCodeFirst.Services
{
    public interface IOrderService
    {
        ApiResponse<IEnumerable<Order>> GetAllOrders();
        ApiResponse<Order> GetOrderById(int id);
        ApiResponse<Order> AddOrder(Order order);
        ApiResponse<Order> UpdateOrder(int id, OrderDTO order);
        ApiResponse<bool> DeleteOrder(int id);
    }
}
