using EFCodeFirst.EntityClasses;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; 

namespace EFCodeFirst.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _context;

        public OrderRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                   .Include(o => o.OrderItems).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                           .Include(o => o.OrderItems) // Include the related OrderItems
                           .FirstOrDefault(o => o.OrderId == id);
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
