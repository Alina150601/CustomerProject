using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalApi.Contracts.Requests;
using MinimalApi.Services;

namespace MinimalApi.Endpoints;

[HttpDelete("customers/{id:guid}"), AllowAnonymous]
public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(DeleteCustomerRequest req, CancellationToken ct)
    {
        var deleted = await _customerService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}