using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public bool Add(Order order) => OrderDAO.Add(order);

        public bool Delete(int id) => OrderDAO.Delete(id);

        public void DeleteByMember(int memberId) => OrderDAO.DeleteAllByMember(memberId);

        public Order Get(int id) => OrderDAO.Get(id);

        public List<Order> GetAll() => OrderDAO.GetAll();

        public bool Update(Order order) => OrderDAO.Update(order);
    }
}
