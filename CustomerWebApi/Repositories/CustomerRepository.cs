using CustomerWebApi.Data;
using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _customerDbContext;

    public CustomerRepository(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }
    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _customerDbContext.Customers.AddAsync(customer);
        await _customerDbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> DeleteAsync(int customerId)
    {
        var customer = await _customerDbContext.Customers.FirstOrDefaultAsync(item => item.Id == customerId);
        if (customer is not null)
        {
            _customerDbContext.Customers.Remove(customer!);
            await _customerDbContext.SaveChangesAsync();
        }

        return customer;
    }

    public async Task<Customer?> GetByIdAsync(int customerId)
    {
        return await _customerDbContext.Customers.FirstOrDefaultAsync(item => item.Id == customerId);
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _customerDbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> UpdateAsync(Customer customer)
    {
        _customerDbContext.Customers.Update(customer);
        await _customerDbContext.SaveChangesAsync();
        return customer;
    }
}
