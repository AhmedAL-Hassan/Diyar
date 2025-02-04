using DiyarTask.Application.Authentication.Interfaces;
using DiyarTask.Domain.Aggregates.CustomerAggregate.Models;
using DiyarTask.Domain.Common.Interfaces.Persistence;
using DiyarTask.Domain.Models.Authentication;

namespace DiyarTask.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public readonly ICustomerRepository _CustomerRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(
        ICustomerRepository CustomerRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _CustomerRepository = CustomerRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_CustomerRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User With given email already existed");
        }

        var user = new CustomerModel
        {
            Name = firstName + " " + lastName,
            Email = email,
            Password = password
        };

        var userEntity = _CustomerRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(userEntity);

        return new AuthenticationResult(
            userEntity.Id.Value,
            firstName,
            lastName,
            email,
            token
            );
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
            );
    }
}
