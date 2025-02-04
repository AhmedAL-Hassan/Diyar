using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Shared.Models.Response.Invoice;
using MediatR;
using System.Linq.Expressions;

namespace DiyarTask.Application.Queries.Invoices.GetFilteredInvoicesQuery
{
    public sealed class GetFilteredInvoicesQuery : BaseQuery<Invoice>, IRequest<List<InvoiceDto>>
    {
        public int? CustomerId { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public PaymentStatusEnum? PaymentStatus { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public Expression<Func<Invoice, bool>> BuildExpression()
        {
            Expression<Func<Invoice, bool>> filter = i => true; // Default to always true condition

            if (CustomerId.HasValue)
                filter = CombineExpressions(filter, i => i.CustomerId == CustomerId.Value);

            if (DueDate.HasValue)
                filter = CombineExpressions(filter, i => i.DueDate.Date == DueDate.Value.Date);

            if (MinAmount.HasValue)
                filter = CombineExpressions(filter, i => i.Amount >= MinAmount.Value);

            if (MaxAmount.HasValue)
                filter = CombineExpressions(filter, i => i.Amount <= MaxAmount.Value);

            if (PaymentStatus.HasValue)
                filter = CombineExpressions(filter, i => i.PaymentStatus == PaymentStatus.Value);

            return filter;
        }
    }
}