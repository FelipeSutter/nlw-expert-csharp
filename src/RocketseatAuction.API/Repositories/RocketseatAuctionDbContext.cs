using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext {

    public RocketseatAuctionDbContext(DbContextOptions options) : base(options) { }

    // Aqui é colocado o nome da entidade entre <> e o nome da variavel tem que dar igual ao nome da tabela no Banco.
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
