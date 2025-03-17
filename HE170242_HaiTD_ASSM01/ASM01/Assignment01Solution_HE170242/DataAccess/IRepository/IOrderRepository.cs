using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order Get(int id);
        Boolean Add(Order order);
        Boolean Delete(int id);
        Boolean Update(Order order);
        void DeleteByMember(int memberId);
    }
}
