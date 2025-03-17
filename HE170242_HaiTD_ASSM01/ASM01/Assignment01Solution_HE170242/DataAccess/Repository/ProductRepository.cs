using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool Add(Product product) => ProductDAO.Add(product);

        public bool Delete(int id) => ProductDAO.Delete(id);

        public Product Get(int id) => ProductDAO.Get(id);

        public List<Product> GetAll() => ProductDAO.GetAll();

        public Product SearchByNameAndPrice(string name, decimal price) => ProductDAO.SearchByNameAndPrice(name, price);
        public bool Update(Product product) => ProductDAO.Update(product);
    }
}
