using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter {
    // Esse context eh toda a interface da minha requisição, como body, headers, parametros, tudo que tem na requisicao
    public void OnAuthorization(AuthorizationFilterContext context) {
        
        try {
            var token = TokenOnRequest(context.HttpContext);

            var repository = new RocketseatAuctionDbContext();

            // pega o email ja convertido
            var email = FromBase64String(token);

            // verifica se existe um email na tabela de usuario com o mesmo email da variavel
            var exist = repository.Users.Any(user => user.Email.Equals(email));

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
