using DiyarTask.Domain.Aggregates.InvoiceAggregate;
using DiyarTask.Domain.Core;
using DiyarTask.Shared.Models.Response.Invoice;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Queries.Invoices.GetFilteredInvoicesQuery
{
    public sealed class GetFilteredInvoicesQueryHandler : IRequestHandler<GetFilteredInvoicesQuery, List<InvoiceResponse>>
    {
        private readonly IRepository<Invoice> _InvoiceRepository;
        private readonly IMapper _mapper;

        public GetFilteredInvoicesQueryHandler(IRepository<Invoice> InvoiceRepository, IMapper mapper)
        {
            _InvoiceRepository = InvoiceRepository;
            _mapper = mapper;
        }

        public async Task<List<InvoiceResponse>> Handle(GetFilteredInvoicesQuery request, CancellationToken cancellationToken)
        {
            var expression = request.BuildExpression();

            var Invoices = _InvoiceRepository.GetFilteredAsync(expression);

            return _mapper.Map<List<InvoiceResponse>>(Invoices);
        }
    }
}