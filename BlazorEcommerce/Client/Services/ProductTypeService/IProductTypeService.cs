namespace BlazorEcommerce.Client.Services.ProductTypeService;

public interface IProductTypeService
{
    event Action OnChanged;
    public List<ProductType> ProductTypes { get; set; }

    Task GetProductTypes();
    Task AddProductType(ProductType productType);

    Task UpdateProductType(ProductType productType);

    ProductType CreateNewProductType();
}
