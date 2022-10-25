using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    Task<Product> Get(int id);

    Task AddProduct(Product newProduct);

    Task EditProduct(Product newProduct);

    Task RemoveProduct(int id);

}
