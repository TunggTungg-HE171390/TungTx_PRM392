using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<BusinessObject.Order> GetAll()
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var list = context.Orders.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BusinessObject.Order Get(int id)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var order = context.Orders.FirstOrDefault(m => m.OrderId == id);
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<BusinessObject.Order> GetListByMember(int MemberId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var order = context.Orders.Where(o => o.MemberId == MemberId).ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Boolean Add(BusinessObject.Order order)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Orders.Add(order);
                    int rows = context.SaveChanges();
                    if (rows > 0) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Delete(int id)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    BusinessObject.Order order = Get(id);
                    if (order != null)
                    {
                        context.Orders.Remove(order);
                        int rows = context.SaveChanges();
                        if (rows > 0) return true;
                        else return false;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAllByMember(int memberId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    List<BusinessObject.Order> order = GetListByMember(memberId);
                    if (order != null)
                    {
                        context.Orders.RemoveRange(order);
                        int rows = context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Update(BusinessObject.Order order)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Entry<BusinessObject.Order>(order).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int rows = context.SaveChanges();
                    if (rows > 0) return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
