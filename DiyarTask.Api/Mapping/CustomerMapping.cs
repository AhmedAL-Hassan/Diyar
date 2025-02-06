namespace DiyarTask.Api.Mapping
{
    using Mapster;
    using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
    using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
    using DiyarTask.Domain.Aggregates.CustomerrAggregate;
    using DiyarTask.Shared.Models.Response.Customer;
    using DiyarTask.Contracts.Customers.Request;
    using DiyarTask.Shared.Models.Response.Reminder;
    using DiyarTask.Shared.Models.Notification;

    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCustomerRequest, CreateCustomerCommand>();
            config.NewConfig<UpdateCustomerRequest, UpdateCustomerCommand>();

            config.NewConfig<Customer, CustomerResponse>();
            config.NewConfig<CustomerReminderModel, NotificationData>();
        }
    }
}
