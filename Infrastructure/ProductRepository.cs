using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly FoodPackageDbContext _context;

    public ProductRepository(FoodPackageDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public async Task AddProduct(Product newProduct) { 
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveProduct(Product removedProduct)
    {
        _context.Products.Remove(removedProduct);
        await _context.SaveChangesAsync();
    }
}
