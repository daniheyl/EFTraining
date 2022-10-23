namespace Portal.Models;
using Core.Domain;
public static class ViewModelHelper
{
    public static List<ProductViewModel> ToViewModel(this IEnumerable<Product> products) 
    { 
        var result = new List<ProductViewModel>();

        foreach (var product in products)
        {
            result.Add(product.ToViewModel());
        }

        return result;
    }

    public static ProductViewModel ToViewModel(this Product product) 
    {
        var result = new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            ContainsAlcohol = product.ContainsAlcohol,
            Picture = product.Picture,
        };

        return result;
        
    }
}
