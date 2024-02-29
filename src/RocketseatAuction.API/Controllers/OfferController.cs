using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))] // um filtro de autenticação que o controller terá que validar
                                                     // antes de qualquer request
public class OfferController : RocketseatAuctionBaseController {

    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase) {

        //[FromServices] chama um metodo com injecao de dependecias

        var id = useCase.Execute(itemId, request);
        
        return Created(string.Empty, id);
    }

}
