// igual o import
using Microsoft.AspNetCore.Mvc;

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
        return Ok("Felipe Sutter");
    }

    [HttpGet]
    public IActionResult Test() {
        return Ok("Felipe Sutter");
    }

}
