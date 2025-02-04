namespace DiyarTask.Application.Commands.Invoices.CreateInvoiceCommand;

using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Aggregates.InvoiceAggregate.Interfaces;
using DiyarTask.Shared.Models.Response.Invoice;
using MediatR;
using System;

public sealed class CreateInvoiceCommand : IRequest<InvoiceDto>, ICreateInvoiceCommand
{
    public int CustomerId { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatusEnum PaymentStatus { get; set; }
}
