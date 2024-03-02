using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest {

    [Theory] // caso queira testar diversos testes, colocar esse theory e o inlineData para o parâmetro dentro da funcao
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId) {

        // Arrange

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 1500)).Generate();

        var offerRepository = new Mock<IOfferRepository>(); // funcoes que nao devolvem nada (void) nao precisa de setup

        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        // Act
        var act = () => useCase.Execute(itemId, request);

        // Assert
        act.Should().NotThrow();

    }

}
