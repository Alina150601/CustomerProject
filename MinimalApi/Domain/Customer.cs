using MinimalApi.Domain.Common;

namespace MinimalApi.Domain;

public class Customer
{
    public CustomerId Id { get; init; } = CustomerId.From(Guid.NewGuid());
    public UserName UserName { get; init; } = default!;
    public FullName FullName { get; init; } = default!;
    public EmailAddress Email { get; init; } = default!;
    public DateOfBirth DateOfBirth { get; init; } = default!;
}