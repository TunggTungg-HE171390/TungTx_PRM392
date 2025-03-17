using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var context = new MyDbContext())
                {
                    products = context.Products.Include(p => p.Category).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static Product FindProductById(int proId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == proId);
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }


        public static void UpdateProduct(Product product)
        {
            try
            {
                using(var context = new MyDbContext())
                {
                    //Product pro = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    //if(pro != null)
                    //{
                    //    pro.ProductName = product.ProductName;
                    //    pro.CategoryId = product.CategoryId;
                    //    pro.UnitsInStock = product.UnitsInStock;
                    //    pro.UnitPrice = product.UnitPrice;
                    //    context.Products.Update(pro);
                    //    context.SaveChanges();
                    //}
                    context.Entry<Product>(product).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product product) {
            try
            {
                using (var context = new MyDbContext())
                {
                    Product pro = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
                    if (pro != null)
                    {
                        context.Products.Remove(pro);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
