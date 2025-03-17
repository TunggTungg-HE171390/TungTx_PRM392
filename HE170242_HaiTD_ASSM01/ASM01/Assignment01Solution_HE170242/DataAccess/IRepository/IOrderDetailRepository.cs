using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetails> GetAll();
        OrderDetails Get(int orderId, int productId);
        Boolean Add(OrderDetails orderDetail);
        Boolean Delete(int orderId, int productId);
        Boolean Update(OrderDetails orderDetail);
        void DeleteByOrder(int oderId);
    }
}
