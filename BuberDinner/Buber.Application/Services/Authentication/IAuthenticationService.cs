namespace Buber.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);

    AuthenticationResult Login(string password, string email);  
}