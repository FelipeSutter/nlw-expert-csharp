using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase {

    private readonly LoggedUser _loggedUser; // readonly significa que somente o construtor poderá mudar o valor da variavel

    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

    public int Execute(int itemId, RequestCreateOfferJson request) {

        var repository = new RocketseatAuctionDbContext();

        var user = _loggedUser.User();

        // Recuperou o user logado e esta criando o objeto offer

        var offer = new Offer {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Offers.Add(offer);

        repository.SaveChanges(); // serve para persistir as mudanças e salvar no banco

        return offer.Id;



    }

}
