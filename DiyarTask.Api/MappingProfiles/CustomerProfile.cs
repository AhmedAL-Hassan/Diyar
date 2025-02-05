namespace DiyarTask.Api.MappingProfiles;

using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
using DiyarTask.Application.Queries.Customers.GetFilteredCustomersQuery;
using DiyarTask.Contracts.Customers.Request;

using Mapster;

public class CustomerProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerRequest, CreateCustomerCommand>();
        config.NewConfig<UpdateCustomerRequest, UpdateCustomerCommand>();
        config.NewConfig<SearchCustomerRequest, GetFilteredCustomersQuery>();
    }
}