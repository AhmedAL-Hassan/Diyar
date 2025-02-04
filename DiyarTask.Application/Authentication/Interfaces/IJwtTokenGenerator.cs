using DiyarTask.Domain.Aggregates.CustomerAggregate;

namespace DiyarTask.Application.Authentication.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Customer user);
}
