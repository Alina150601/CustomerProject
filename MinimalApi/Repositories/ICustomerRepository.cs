using MinimalApi.Contracts.Data;

namespace MinimalApi.Repositories;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerDto customer);

    Task<CustomerDto?> GetAsync(Guid id);
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<bool> UpdateAsync(CustomerDto customer);
    Task<bool> DeleteAsync(Guid id);
}