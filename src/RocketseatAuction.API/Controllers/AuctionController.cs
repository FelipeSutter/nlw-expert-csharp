// igual o import
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

// namespace eh tipo o pacote
namespace RocketseatAuction.API.Controllers;

// As anotacoes em csharp sao passadas entre colchetes
// Route eh a mesma coisa que o requestMapping, o caminho do endpoint
// [controller] eh o nome que sera inserido baseado no nome do controller. Ex. AuctionController - api/Auction
public class AuctionController : RocketseatAuctionBaseController { // Agora o controller base está sendo herdado por
                                                                   // RocketseatAuctionBaseController que esta sendo herdado
                                                                   // por todos os controllers da aplicacao

    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)] // configurando o swagger para ele mostrar um
                                                                     // response do tipo Auction com o status code 200OK
    [ProducesResponseType(StatusCodes.Status204NoContent)]           // status code 204 caso não tenha auction
    public IActionResult GetCurrentAuction() {

        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        if (result is null) {
            return NoContent();
        }

        return Ok(result);
    }

}
