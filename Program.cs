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
        .AddTypeExtension<DeveloperQueries>()
        // .AddMutationType()
        // .AddTypeExtension<ReviewMutations>()
        // .AddSubscriptionType()
        // .AddTypeExtension<ReviewSubscriptions>()

    .AddType<Human>()
    .AddType<Droid>()
    .AddType<Starship>()
    .AddType<DeveloperQueries>()
    .AddTypeExtension<CharacterResolvers>()

    .AddFiltering()
    .AddSorting()

    .AddApolloTracing();

var app = builder.Build();

app.MapGraphQL();

app.Run();

[ExtendObjectType(OperationTypeNames.Query)]
public class DeveloperQueries
{
    public Developer GetApi_Info()
    {
        return new Developer { Author  = "Yan Esteves", Github = "https://github.com/yanestevesufjf", Course = "DevInHouse" };
    }
}

public class Developer
{
    public string? Author {get; set;}
    public string? Github {get;set;}
    public string? Course {get;set;}
}