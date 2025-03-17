using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public bool Add(OrderDetails orderDetail) => OrderDetailDAO.Add(orderDetail);

        public bool Delete(int orderId, int productId) => OrderDetailDAO.Delete(orderId, productId);

        public void DeleteByOrder(int oderId) => OrderDetailDAO.DeleteAllByOrder(oderId);

        public OrderDetails Get(int orderId, int productId) => OrderDetailDAO.Get(orderId, productId);
        public List<OrderDetails> GetAll() => OrderDetailDAO.GetAll();

        public bool Update(OrderDetails orderDetail) => OrderDetailDAO.Update(orderDetail);
    }
}
