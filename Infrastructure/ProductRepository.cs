using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

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

    
    public async Task EditProduct(Product Product)
    {
        _context.Products.Update(Product);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveProduct(int id)
    {
        var productToRemove = new Product { Id = id }; 
        _context.Products.Remove(productToRemove);
        await _context.SaveChangesAsync();

    }

    public async Task<Product> Get(int id)
    {
       Product product = await _context.Products.Where(e => e.Id == id).FirstOrDefaultAsync();
       return product;
    }
}
