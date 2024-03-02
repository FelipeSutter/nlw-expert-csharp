using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest {

    [Fact] // anotação que diz que é um teste
    public void Success() {

        // Arrange

        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 1500)) // cria uma regra para o id, para gerar numeros aleatorios
            .RuleFor(auction => auction.Name, f => f.Lorem.Word()) // gera palavra aleatoria
            .RuleFor(auction => auction.Starts, f => f.Date.Past()) // data passada
            .RuleFor(auction => auction.Ends, f => f.Date.Future()) // data futura
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item> { // gera uma nova lista de itens
                new Item { 
                    Id = f.Random.Number(1, 1500),
                    Name = f.Commerce.ProductName(), 
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(30, 1000),
                    Condition = f.PickRandom<Condition>(), // pega uma condition randomica do enum criado
                    AuctionId = auction.Id, // pega o id criado do auction
                    
                }
            }).Generate(); 
        
        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);
        
        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        // Act
        var auction = useCase.Execute();

        // Assert

        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);

    }

}
