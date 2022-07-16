namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories == null)
            {
                return new ServiceResponse<List<Category>>();
            }
            else
                return new ServiceResponse<List<Category>>()
                {
                    Data = categories,
                };
        }
    }
}
