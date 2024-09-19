using MinimalApi.Contracts.Requests;
using MinimalApi.Domain;
using MinimalApi.Domain.Common;

namespace MinimalApi.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CreateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.NewGuid()),
            Username = UserName.From(request.Username),
            FullName = FullName.From(request.FullName),
            Email = EmailAddress.From(request.Email),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(request.Id),
            Username = UserName.From(request.Username),
            FullName = FullName.From(request.FullName),
            Email = EmailAddress.From(request.Email),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
}