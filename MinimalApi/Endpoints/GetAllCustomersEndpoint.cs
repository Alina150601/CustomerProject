using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalApi.Contracts.Responses;
using MinimalApi.Mapping;
using MinimalApi.Services;

namespace MinimalApi.Endpoints;

[HttpGet("customers"), AllowAnonymous]
public class GetAllCustomersEndpoint : EndpointWithoutRequest<GetAllCustomersResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var customers = await _customerService.GetAllAsync();
        var customerResponse = customers.ToCustomersResponse();
        await SendOkAsync(customerResponse, ct);
    }
}