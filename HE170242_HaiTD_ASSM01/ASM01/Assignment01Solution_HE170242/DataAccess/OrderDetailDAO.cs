using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static List<BusinessObject.OrderDetails> GetAll()
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var list = context.OrderDetails.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BusinessObject.OrderDetails Get(int orderId, int productId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var order = context.OrderDetails.FirstOrDefault(m => m.OrderId == orderId && m.ProductId == productId);
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<BusinessObject.OrderDetails> GetByorderId(int orderId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var order = context.OrderDetails.Where(m => m.OrderId == orderId).ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Add(BusinessObject.OrderDetails orderDetail)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.OrderDetails.Add(orderDetail);
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

        public static Boolean Delete(int orderId, int productId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    BusinessObject.OrderDetails orderDetail = Get(orderId, productId);
                    if (orderDetail != null)
                    {
                        context.OrderDetails.Remove(orderDetail);
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

        public static void DeleteAllByOrder(int orderId)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    List<BusinessObject.OrderDetails> orderDetail = GetByorderId(orderId);
                    if (orderDetail != null)
                    {
                        context.OrderDetails.RemoveRange(orderDetail);
                        int rows = context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Update(BusinessObject.OrderDetails orderDetail)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Entry<BusinessObject.OrderDetails>(orderDetail).State =
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
