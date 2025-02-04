﻿using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Shared.Core.Errors;
using DiyarTask.Shared.Models.Response.Customer;
using MapsterMapper;
using MediatR;

namespace DiyarTask.Application.Queries.Invoices.GetInvoiceQuery
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
