namespace BlazorEcommerce.Client.Services.AddressService
{
    public interface IAddressService
    {
        Task<Address> GetAddress();
        Task<Address> AddOrUpdateAddress(Address address);
    }

    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Address> AddOrUpdateAddress(Address address)
        {
            var response = await _httpClient.PostAsJsonAsync("api/address", address);
            return (await response.Content
                .ReadFromJsonAsync<ServiceResponse<Address>>()).Data;
        }

        public async Task<Address> GetAddress()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Address>>("api/address");
            return response.Data;
        }
    }
}
