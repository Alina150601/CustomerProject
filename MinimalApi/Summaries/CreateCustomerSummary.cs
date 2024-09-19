using FastEndpoints;
using MinimalApi.Contracts.Responses;
using MinimalApi.Endpoints;

namespace MinimalApi.Summaries;

public class CreateCustomerSummary : Summary<CreateCustomerEndpoint>
{
    public CreateCustomerSummary()
    {
        Summary = "Creates a new customer in the system";
        Description = "Creates a new customer in the system";
        Response<CustomerResponse>(201, "Customer was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}