using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        return View(_productRepository.GetAll().ToViewModel());
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> NewProduct(NewProductViewModel newProduct)
    {
        var productToCreat = new Product(newProduct.Name, newProduct.ContainsAlcohol, newProduct.Picture);

        await _productRepository.AddProduct(productToCreat);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveProduct(int id)
    {
        await _productRepository.RemoveProduct(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        Product product = await _productRepository.Get(id);
        return View(product.ToViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(NewProductViewModel newProduct)
    {
        var productToEdit = new Product(newProduct.Id, newProduct.Name, newProduct.ContainsAlcohol, newProduct.Picture);

        await _productRepository.EditProduct(productToEdit);
        return RedirectToAction("Index");
    }
}
