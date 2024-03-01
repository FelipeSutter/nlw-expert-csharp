using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Services;

public class LoggedUser {

    private readonly IHttpContextAccessor _httpContextAssessor; // por ser uma variavel privada colocar _ no inicio

    private readonly IUserRepository _userRepository;

    // Essa interface acessa o HttpContext da aplicacao 
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) {
        _httpContextAssessor = httpContext;
        _userRepository = repository;
    }

    // Método que recupera o email do usuario logado
    public User User () {
        var token = TokenOnRequest();

        var email = FromBase64String(token);

        return _userRepository.GetUserByEmail(email);
    }

    private string TokenOnRequest() {

        var authentication = _httpContextAssessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..]; // Serve para excluir o "Bearer " e somente retornar o token

    }

    // Método que converte o base64 no email original
    private string FromBase64String(string base64) {

        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }

}
