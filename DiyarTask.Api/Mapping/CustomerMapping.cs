namespace DiyarTask.Api.Mapping
{
    using Mapster;
    using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
    using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
    using DiyarTask.Domain.Aggregates.CustomerrAggregate;
    using DiyarTask.Shared.Models.Response.Customer;
    using DiyarTask.Contracts.Customers.Request;

    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCustomerRequest, CreateCustomerCommand>();
            config.NewConfig<UpdateCustomerRequest, UpdateCustomerCommand>();

            config.NewConfig<Customer, CustomerResponse>();
        }
    }
}
