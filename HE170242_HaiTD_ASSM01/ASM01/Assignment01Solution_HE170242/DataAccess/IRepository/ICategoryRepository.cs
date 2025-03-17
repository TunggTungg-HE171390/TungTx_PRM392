using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        Boolean Add(Category category);
        Boolean Delete(int id);
        Boolean Update(Category category);
    }
}
