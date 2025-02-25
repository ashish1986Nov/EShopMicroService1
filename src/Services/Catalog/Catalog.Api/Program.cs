using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config => { 

    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});


builder.Services.AddMarten(opt=>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database"));

}).UseLightweightSessions();


var app = builder.Build();

//Configure the HTTP request pipeline

app.MapCarter();
app.Run();
