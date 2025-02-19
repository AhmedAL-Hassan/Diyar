﻿namespace DiyarTask.Domain.Aggregates.CustomerrAggregate;

using DiyarTask.Domain.Aggregates.CustomerAggregate.Interfaces;
using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.NotificationAggregate;
using DiyarTask.Domain.Aggregates.Reminder;
using DiyarTask.Domain.Core;

public sealed class Customer : BaseEntity<Guid>, IAuditableEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public ICollection<Invoice> Invoices { get; private set; }
    public ICollection<Notification> Notifications { get; private set; }
    public string CreatedBy { get; private set; }
    public string ModifiedBy { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? ModifiedDate { get; private set; }
    public ICollection<ReminderUser> ReminderUsers { get; private set; }


    public static Customer AddCustomer(ICreateCustomerModel request)
    {
        var Customerr = new Customer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CreatedDate = DateTime.UtcNow,
        };

        return Customerr;
    }

    public void ChangeName(string name)
    {
        Name = name;
        // AddDomainEvent(new CustomerChangedEvent(Id, name));
    }

    public void Update(IUpdateCustomerCommand request)
    {
        if (request == null)
        {
            throw new KeyNotFoundException($"Customer with ID {request.Id} not found.");
        }

        Name = request.Name;
        Email = request.Email;
        PhoneNumber = request.PhoneNumber;
        ModifiedDate = DateTime.UtcNow;
    }
}