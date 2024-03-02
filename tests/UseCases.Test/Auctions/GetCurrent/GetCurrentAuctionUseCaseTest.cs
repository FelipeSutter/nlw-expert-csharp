using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest {

    [Fact] // anotação que diz que é um teste
    public void Success() {

        // Arrange
        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(new Auction());
        
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        // Act
        var auction = useCase.Execute();

        // Assert

        auction.Should().NotBeNull();

    }

}
