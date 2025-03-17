using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<BusinessObject.Category> GetAll()
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var list = context.Categories.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BusinessObject.Category Get(int id)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    var cate = context.Categories.FirstOrDefault(m => m.CategoryId == id);
                    return cate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Boolean Add(BusinessObject.Category category)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Categories.Add(category);
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
                    BusinessObject.Category cate = Get(id);
                    if (cate != null)
                    {
                        context.Categories.Remove(cate);
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

        public static Boolean Update(BusinessObject.Category category)
        {
            try
            {
                using (var context = new EStoreContext())
                {
                    context.Entry<BusinessObject.Category>(category).State =
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
