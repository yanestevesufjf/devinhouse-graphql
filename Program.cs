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
        // .AddMutationType()
        // .AddTypeExtension<ReviewMutations>()
        // .AddSubscriptionType()
        // .AddTypeExtension<ReviewSubscriptions>()

    .AddType<Human>()
    .AddType<Droid>()
    .AddType<Starship>()
    .AddTypeExtension<CharacterResolvers>()

    .AddFiltering()
    .AddSorting()

    .AddApolloTracing();

var app = builder.Build();

app.MapGraphQL();

app.Run();

/*
escola

- alunos AlunosQuery
- professores ProfessoresQuery

*/