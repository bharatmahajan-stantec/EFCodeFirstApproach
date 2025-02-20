using EFCodeFirst.Data.Repositories;
using EFCodeFirst.DTO;
using EFCodeFirst.EntityClasses;
using System.Collections.Generic;

namespace EFCodeFirst.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ApiResponse<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = _orderRepository.GetAll();
                return ApiResponse<IEnumerable<Order>>.Success(orders);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Order>>.Error(ex.Message);
            }
        }

        public ApiResponse<Order> GetOrderById(int id)
        {
            try
            {
                var order = _orderRepository.GetById(id);
                if (order == null)
                {
                    return ApiResponse<Order>.Error("Order not found", 404);
                }
                return ApiResponse<Order>.Success(order);
            }
            catch (Exception ex)
            {
                return ApiResponse<Order>.Error(ex.Message);
            }
        }

        public ApiResponse<Order> AddOrder(Order order)
        {
            try
            {
                _orderRepository.Add(order);
                return ApiResponse<Order>.Success(order);
            }
            catch (Exception ex)
            {
                return ApiResponse<Order>.Error(ex.Message);
            }
        }

        public ApiResponse<Order> UpdateOrder(int id, OrderDTO order)
        {
            try
            {
                var existingOrder = _orderRepository.GetById(id);
                if (existingOrder == null)
                {
                    return ApiResponse<Order>.Error("Order not found", 404);
                }

                bool isUpdated = false;

                if (!string.IsNullOrEmpty(order.CustomerName))
                {
                    existingOrder.CustomerName = order.CustomerName;
                    isUpdated = true;
                }

                if (order.OrderDate.HasValue)
                {
                    existingOrder.OrderDate = order.OrderDate.Value;
                    isUpdated = true;
                }

                if (!string.IsNullOrEmpty(order.PaymentStatus))
                {
                    existingOrder.PaymentStatus = order.PaymentStatus;
                    isUpdated = true;
                }

                if (!isUpdated)
                {
                    return ApiResponse<Order>.Error("No fields provided for update", 400);
                }

                _orderRepository.Update(existingOrder);

                return ApiResponse<Order>.Success(existingOrder);
            }
            catch (Exception ex)
            {
                return ApiResponse<Order>.Error(ex.Message);
            }
        }

        public ApiResponse<bool> DeleteOrder(int id)
        {
            try
            {
                var order = _orderRepository.GetById(id);
                if (order == null)
                {
                    return ApiResponse<bool>.Error("Order not found", 404);
                }

                _orderRepository.Delete(order);
                return ApiResponse<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error(ex.Message);
            }
        }
    }
}
