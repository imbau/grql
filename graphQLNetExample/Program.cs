using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using graphQLNetExample.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// add notes schema
builder.Services.AddSingleton<ISchema, NotesSchema>(services => new NotesSchema(new SelfActivatingServiceProvider(services)));
// register graphQL
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<NotesSchema>()  // schema
    .AddSystemTextJson());   // serializer
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("graphql");
    endpoints.MapGraphQLVoyager("ui/voyager");
});
app.Run();
