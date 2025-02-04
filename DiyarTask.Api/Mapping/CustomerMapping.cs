namespace DiyarTask.Api.Mapping
{
    using Mapster;
    using DiyarTask.Contracts.Customers;
    using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
    using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;

    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CustomerForCreationDto, CreateCustomerCommand>();
            config.NewConfig<CustomerForUpdateDto, UpdateCustomerCommand>();
        }
    }

}
