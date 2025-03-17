using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool Add(Category category) => CategoryDAO.Add(category);

        public bool Delete(int id) => CategoryDAO.Delete(id);

        public Category Get(int id) => CategoryDAO.Get(id);

        public List<Category> GetAll() => CategoryDAO.GetAll();

        public bool Update(Category category) => CategoryDAO.Update(category);
    }
}
