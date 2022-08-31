namespace BlazorEcommerce.Client.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly HttpClient _http;

    public ProductTypeService(HttpClient http)
    {
        _http = http;
    }
    public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

    public event Action OnChanged;

    public async Task AddProductType(ProductType productType)
    {
        var resonse = await _http.PostAsJsonAsync("api/producttype", productType);
        ProductTypes = (await resonse.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>()).Data;

        OnChanged.Invoke();
    }

    public ProductType CreateNewProductType()
    {
        var newProdutType = new ProductType() { IsNew = true, Editing = true };
        ProductTypes.Add(newProdutType);
        OnChanged.Invoke();
        return newProdutType;
    }

    public async Task GetProductTypes()
    {
        var result = await _http
            .GetFromJsonAsync <ServiceResponse<List<ProductType>>> ("api/producttype");
        ProductTypes = result.Data;
    }

    public async Task UpdateProductType(ProductType productType)
    {
        var resonse = await _http.PutAsJsonAsync("api/producttype", productType);
        ProductTypes = (await resonse.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>()).Data;

        OnChanged.Invoke();
    }
}
