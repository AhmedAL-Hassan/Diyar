using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Models.Response.Customer;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Queries.GetFilteredCustomersQuery
{
    public sealed class GetFilteredCustomersQueryHandler : IRequestHandler<GetFilteredCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetFilteredCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetFilteredCustomersQuery request, CancellationToken cancellationToken)
        {
            var expression = request.BuildExpression();

            var customers = _customerRepository.GetFilteredAsync(expression);

            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}