using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase {

    // Colocar ? para dizer que a entidade pode vir nula.
    public Auction? Execute() {

        var repository = new RocketseatAuctionDbContext();

        var today = DateTime.UtcNow;

        return repository
            .Auctions
            .Include(auction => auction.Items) // serve para incluir a listagem de itens associado ao leilao
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);

    }

}
