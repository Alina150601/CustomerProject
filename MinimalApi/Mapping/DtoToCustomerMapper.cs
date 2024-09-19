using MinimalApi.Contracts.Data;
using MinimalApi.Domain;
using MinimalApi.Domain.Common;

namespace MinimalApi.Mapping;

public static class DtoToCustomerMapper
{
    public static Customer ToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.Parse(customerDto.Id)),
            Username = UserName.From(customerDto.Username),
            FullName = FullName.From(customerDto.FullName),
            Email = EmailAddress.From(customerDto.Email),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(customerDto.DateOfBirth))
        };
    }
}