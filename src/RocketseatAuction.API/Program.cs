using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    
    // Config do swagger para mostrar autorização na hora de rodar
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 1234abcdef56'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

});

builder.Services.AddScoped<AuthenticationUserAttribute>(); // configuracao para rodar o authentication criado
builder.Services.AddScoped<LoggedUser>(); // serve para colocar uma injeção de dependencia
builder.Services.AddScoped<CreateOfferUseCase>(); // essas configuracoes sao para colocar injecao de dependencia
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>(); // isso significa que sempre que usar a interface
                                                                     // vai fazer uma instancia do auctionRepository tbm
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Essa função diz onde está o banco de dados e configura ele para receber os dados da entidade
builder.Services.AddDbContext<RocketseatAuctionDbContext>(options => {
    options.UseSqlite("Data Source=C:\\devSerratec\\API_Restful\\workspace\\RocketseatAuction\\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
