using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalApi.Contracts.Requests;
using MinimalApi.Contracts.Responses;
using MinimalApi.Mapping;
using MinimalApi.Services;

namespace MinimalApi.Endpoints;

[HttpPut("customers/{id:guid}"), AllowAnonymous]
public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private ICustomerService _customerService;

    public UpdateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var existingCustomer = await _customerService.GetAsync(req.Id);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customer = req.ToCustomer();
        await _customerService.UpdateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}