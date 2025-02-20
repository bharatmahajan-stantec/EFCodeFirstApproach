using EFCodeFirst.EntityClasses;
using System.Collections.Generic;

namespace EFCodeFirst.Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
