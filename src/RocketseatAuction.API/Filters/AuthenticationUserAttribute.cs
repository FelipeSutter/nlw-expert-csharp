using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Contracts;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter {
    
    private readonly IUserRepository _userRepository;
    public AuthenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;
    
    // Esse context eh toda a interface da minha requisição, como body, headers, parametros, tudo que tem na requisicao
    public void OnAuthorization(AuthorizationFilterContext context) {
        
        try {
            var token = TokenOnRequest(context.HttpContext);

            // pega o email ja convertido
            var email = FromBase64String(token);

            // verifica se existe um email na tabela de usuario com o mesmo email da variavel
            var exist = _userRepository.ExistUserWithEmail(email);

            if (exist == false) {
                context.Result = new UnauthorizedObjectResult("E-mail not valid"); // exception
            }
        } catch (Exception ex) {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }

    }

    private string TokenOnRequest(HttpContext context) {
        
        var authentication = context.Request.Headers.Authorization.ToString();

        if(string.IsNullOrEmpty(authentication) ) {
            throw new Exception("Token is missing.");
        }

        return authentication["Bearer ".Length..]; // Serve para excluir o "Bearer " e somente retornar o token

    }

    // Método que converte o base64 no email original
    private string FromBase64String(string base64) {
        
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }

}
