namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http)
        {
            _http = http; 
        }
        public List<Category> Categories { get ; set ; }
        public List<Category> AdminCategories { get; set; } = new List<Category>();

        public event Action OnChanged;

        public async Task AddCategory(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/Category/admin", category);
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;
            await GetCategories();
            OnChanged.Invoke();
        }

        public Category CreateNewCategory(int id)
        {
            var newCategory = new Category
            {
                IsNew = true,
                Editing = true,
            };
            AdminCategories.Add(newCategory);
            OnChanged.Invoke();
            return newCategory;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/Category/admin/{categoryId}");
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;
            await GetCategories();
            OnChanged.Invoke();
        }

        public async Task GetAdminCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/admin");
            if (response != null && response.Data != null)
                AdminCategories = response.Data;
        }

        public async Task GetCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (response != null && response.Data != null)
                Categories = response.Data;            
        }

        public async Task UpdateCategory(Category category)
        {
            var response = await _http.PutAsJsonAsync("api/Category/admin", category);
            AdminCategories = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;
            await GetCategories();
            OnChanged.Invoke();
        }

        public Category CreateNewCategory()
        {
            var newCategory = new Category() { IsNew = true, Editing = true };
            AdminCategories.Add(newCategory);
            OnChanged.Invoke();
            return newCategory;
        }
    }
}
