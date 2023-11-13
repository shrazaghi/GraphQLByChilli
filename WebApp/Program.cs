using DataContext;
using WebApp;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMyDbContext();

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<MyDbContext>()
    .AddQueryType<Query>();


var app = builder.Build();

app.MapGet("/", () => "Navigate to: https://localhost:5111/graphql");
app.MapGet("/employees", () =>
{
    MyDbContext context = new MyDbContext();
    return context.Employees.Take(20);
});
app.MapGraphQL();

app.Run();
