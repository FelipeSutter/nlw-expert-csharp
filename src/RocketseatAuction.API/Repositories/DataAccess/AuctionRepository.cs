using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository {

    private readonly RocketseatAuctionDbContext _dbContext; // esse é o repository global

    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent() {

        var today = DateTime.UtcNow;

        return _dbContext 
            .Auctions
            .Include(auction => auction.Items) // serve para incluir a listagem de itens associado ao leilao
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }

}
