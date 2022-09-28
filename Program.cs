using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiDevInHouse.Characters;
using ApiDevInHouse.Repositories;
using ApiDevInHouse.Reviews;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<ICharacterRepository, CharacterRepository>()
    .AddSingleton<IReviewRepository, ReviewRepository>()
    .AddGraphQLServer()

    .AddQueryType()
        .AddTypeExtension<CharacterQueries>()
        .AddTypeExtension<ReviewQueries>()
        .AddTypeExtension<DeveloperQueries>() // adicionando uma nova anotação para queries
                                              // .AddMutationType()
                                              // .AddTypeExtension<ReviewMutations>()
                                              // .AddSubscriptionType()
                                              // .AddTypeExtension<ReviewSubscriptions>()

    .AddType<Human>()
    .AddType<Droid>()
    .AddType<Starship>()
    .AddType<DeveloperQueries>() // adiciono um novo tipo de dado a ser retornado.

    .AddTypeExtension<CharacterResolvers>()

    .AddFiltering()
    .AddSorting()

    .AddApolloTracing();


// cors

// services.AddResponseCaching();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsapp");
app.MapGraphQL();

app.Run();

[ExtendObjectType(OperationTypeNames.Query)]
public class DeveloperQueries
{
    [GraphQLName("api_info")] // alterando nome da operação da query.
    [GraphQLDescription("Função para retornar dados do autor da api.")] // definindo uma descrição para a operação.
    public Developer GetApi_Info()
    {
        return new Developer { Author = "Yan Esteves", Github = "https://github.com/yanestevesufjf", Course = "DevInHouse" };
    }
}
[GraphQLDescription("Um objeto do tipo Developer")]
public class Developer
{
    [GraphQLDescription("Nome do responsável pela API.")]
    public string? Author { get; set; }
    [GraphQLDescription("Github do desenvolvedor.")]
    public string? Github { get; set; }
    [GraphQLDescription("Nome do curso que foi aplicado este conteúdo.")]
    public string? Course { get; set; }
}