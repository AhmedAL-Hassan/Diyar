using DiyarTask.Shared.Models.Response.Invoice;
using MediatR;

namespace DiyarTask.Application.Queries.Invoices.GetInvoiceQuery
{
    public sealed class GetInvoiceQuery : IRequest<InvoiceDto>
    {
        public Guid InvoiceId { get; }

        public GetInvoiceQuery(Guid invoiceId)
        {
            invoiceId = InvoiceId;
        }
    }

}
