using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter {
    // Esse context eh toda a interface da minha requisição, como body, headers, parametros, tudo que tem na requisicao
    public void OnAuthorization(AuthorizationFilterContext context) {
    }

    private string TokenOnRequest(HttpContext context) {
        var authentication = context.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..]; // Serve para excluir o "Bearer " e somente retornar o token

    }

}
