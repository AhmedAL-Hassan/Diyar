namespace DiyarTask.Api.Mapping
{
    using Mapster;
    using DiyarTask.Contracts.Customers;
    using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
    using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
    using DiyarTask.Domain.Aggregates.CustomerrAggregate;
    using DiyarTask.Shared.Models.Response.Customer;

    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CustomerForCreationDto, CreateCustomerCommand>();
            config.NewConfig<CustomerForUpdateDto, UpdateCustomerCommand>();

            config.NewConfig<Customer, CustomerDto>();
        }
    }
}
