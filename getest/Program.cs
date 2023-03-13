using getest.Resolvers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// graphql
builder.Services
       .AddGraphQLServer()
       .AddQueryType<Query>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors",
      builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });
app.Run();
