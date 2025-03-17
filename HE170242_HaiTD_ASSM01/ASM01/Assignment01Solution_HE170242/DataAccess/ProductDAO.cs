using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<BusinessObject.Product> GetAll()
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var list = context.Products.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BusinessObject.Product Get(int id)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var pro = context.Products.FirstOrDefault(m => m.ProductId == id);
                    return pro;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Add(BusinessObject.Product product)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Products.Add(product);
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
                    BusinessObject.Product product = Get(id);
                    if (product != null)
                    {
                        context.Products.Remove(product);
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

        public static Boolean Update(BusinessObject.Product product)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Entry<BusinessObject.Product>(product).State =
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

        public static Product SearchByNameAndPrice(string name, decimal unitPrice) {
            try
            {
                using (var context = new EStoreContext())
                {
                    var pro = context.Products.FirstOrDefault(m => m.ProductName == name && m.UnitPrice >= (unitPrice - 100000) && m.UnitPrice <= (unitPrice + 100000));
                    return pro;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
