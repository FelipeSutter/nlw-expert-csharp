// igual o import
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

// namespace eh tipo o pacote
namespace RocketseatAuction.API.Controllers;

// As anotacoes em csharp sao passadas entre colchetes
// Route eh a mesma coisa que o requestMapping, o caminho do endpoint
// [controller] eh o nome que sera inserido baseado no nome do controller. Ex. AuctionController - api/Auction
[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase {

    [HttpGet]
    public IActionResult GetCurrentAuction() {

        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.execute();

        // statusCode.ok() passando o objeto result
        return Ok(result);
    }

}
