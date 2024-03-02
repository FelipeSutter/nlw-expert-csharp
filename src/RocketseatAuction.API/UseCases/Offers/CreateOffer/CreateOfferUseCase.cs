using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase {

    private readonly ILoggedUser _loggedUser; // readonly significa que somente o construtor poderá mudar o valor da variavel

    private readonly IOfferRepository _offerRepository;

    // Aqui é criado um construtor para createOffer contendo um usuario logado. Sempre que for criar um leilao,
    // significa que o usuario já esta logado
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository) {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request) {

        var user = _loggedUser.User();

        // Recuperou o user logado e esta criando o objeto offer

        var offer = new Offer {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };
        
        _offerRepository.Add(offer);

        return offer.Id;



    }

}
