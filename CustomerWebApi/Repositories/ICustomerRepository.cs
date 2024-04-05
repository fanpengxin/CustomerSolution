using CustomerWebApi.Models;

namespace CustomerWebApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> DeleteAsync(int customerId);
        Task<Customer?> GetByIdAsync(int customerId);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> UpdateAsync(Customer customer);
    }
}
