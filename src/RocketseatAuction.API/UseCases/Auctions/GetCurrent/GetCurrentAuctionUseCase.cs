using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase {

    public Auction execute() {

        var repository = new RocketseatAuctionDbContext();

        return repository
            .Auctions
            .Include(auction => auction.Items) // serve para incluir a listagem de itens associado ao leilao
            .First();

    }

}
