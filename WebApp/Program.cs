using DataContext;
using WebApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().
    AddQueryType<Query>();


var app = builder.Build();

app.MapGet("/", () => "Navigate to: https://localhost:5111/graphql");
app.MapGet("/employees", () =>
{
    MyAppContext context = new MyAppContext();
    return context.Employees.Take(20);
});
app.MapGraphQL();

app.Run();
