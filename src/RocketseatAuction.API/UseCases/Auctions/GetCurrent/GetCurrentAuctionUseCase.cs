using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase {

    // Colocar ? para dizer que a entidade pode vir nula.

    private readonly IAuctionRepository _repository; // foi criado uma interface de auctionRepository para o metodo getCurrent

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
    public Auction? Execute() => _repository.GetCurrent();  

}
