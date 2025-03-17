using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listCategories = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }
        public static Category FindCategoryById(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var category = context.Categories.FirstOrDefault(p => p.CategoryId == id);
                    return category;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
