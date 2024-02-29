﻿using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;

namespace RocketseatAuction.API.Controllers;

public class OfferController : RocketseatAuctionBaseController {

    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request) {
        return Created();
    }

}
