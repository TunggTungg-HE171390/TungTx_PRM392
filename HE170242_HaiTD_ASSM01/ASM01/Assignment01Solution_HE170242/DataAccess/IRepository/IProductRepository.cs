using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        Boolean Add(Product product);
        Boolean Delete(int id);
        Boolean Update(Product product);
        Product SearchByNameAndPrice(string name, decimal price);
    }
}
