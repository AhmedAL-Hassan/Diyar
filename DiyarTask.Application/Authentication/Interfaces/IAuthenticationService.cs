﻿using DiyarTask.Domain.Models.Authentication;

namespace DiyarTask.Application.Authentication.Interfaces;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);

    AuthenticationResult Login(string email, string password);
}