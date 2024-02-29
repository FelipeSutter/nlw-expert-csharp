using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext {

    // Aqui é colocado o nome da entidade entre <> e o nome da variavel tem que dar igual ao nome da tabela no Banco.
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

    // Essa função diz onde está o banco de dados e configura ele para receber os dados da entidade
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=C:\\devSerratec\\API_Restful\\workspace\\RocketseatAuction\\leilaoDbNLW.db");
    }

}
