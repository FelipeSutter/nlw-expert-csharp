namespace RocketseatAuction.API.Entities;

public class Auction {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // serve para colocar a variavel como vazia caso nao passe nada nela
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }

    public List<Item> Items { get; set; } = []; // caso tenha uma relacao entre uma tabela e outra o entityFramework
                                                // detecta automaticamente caso os nomes passados estejam corretos,
                                                // fazendo assim a associação automatica entre as duas entidades

}
